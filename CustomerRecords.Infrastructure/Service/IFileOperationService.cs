using System.Collections.Generic;
using CustomerRecords.Domain;

namespace CustomerRecords.Infrastructure.Service
{
    public interface IFileOperationService
    {
        IEnumerable<string> ReadInputFile();

        IEnumerable<Customer> DeserializeJsonFileToObject(IEnumerable<string> customerCollection);
    }
}