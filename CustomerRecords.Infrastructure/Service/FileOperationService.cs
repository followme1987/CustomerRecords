using CustomerRecords.Domain;
using CustomerRecords.Infrastructure.Extension;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CustomerRecords.Infrastructure.Service
{
    public class FileOperationService : IFileOperationService
    {
        private readonly string _file;

        public FileOperationService(string file)
        {
            _file = file;
        }

        public FileOperationService()
        {
        }

        public IEnumerable<string> ReadInputFile()
        {
            try
            {
                var filePath = Path.Combine(
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ??
                    throw new InvalidOperationException(), _file);

                var customerCollection = new List<string>();

                using (var sr = new StreamReader(filePath))
                {
                    while (sr.Peek() >= 0)
                    {
                        var customerLine = sr.ReadLine();

                        customerCollection.Add(customerLine);
                    }
                }

                return customerCollection;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public IEnumerable<Customer> DeserializeJsonFileToObject(IEnumerable<string> customerCollection)
        {
            var sortedList = new SortedList<int, Customer>();

            foreach (var customerLine in customerCollection)
            {
                var customer = customerLine.DeserializeJsonStringToObj();

                sortedList.Add(customer.Id, customer);
            }

            return sortedList.Values;
        }
    }
}