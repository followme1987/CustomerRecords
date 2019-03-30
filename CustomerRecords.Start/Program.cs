using System;
using System.Collections.Generic;
using System.Linq;
using CustomerRecords.Application.Service;
using CustomerRecords.Application.Service.Interface;
using CustomerRecords.Domain;
using CustomerRecords.Infrastructure.Service;
using CustomerRecords.Start.Util;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerRecords.Start
{
    internal class Program
    {
        private const double WithinDistance = 100;
        private const string FilePath = @"File\customers.txt";

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddSingleton<ICustomerGenerationService, CustomerGenerationByJsonFileService>()
                .AddSingleton<IGenericDistanceCalculatorService, DistanceCalculatorDefaultFormulasService>()
                .AddSingleton<IFileOperationService, FileOperationService>(_ => new FileOperationService(FilePath))
                .BuildServiceProvider();
        }

        private static void Main(string[] args)
        {
            try
            {
                var serviceCollection = new ServiceCollection();

                ConfigureServices(serviceCollection);

                IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

                var customerListFromJsonFile = GetFullCustomerListFromJasonFile(serviceProvider);

                if (customerListFromJsonFile.Any())
                    GetInvitedCustomers(customerListFromJsonFile, serviceProvider);
                else
                    Console.WriteLine("No customers retrieved from the file");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static List<Customer> GetFullCustomerListFromJasonFile(IServiceProvider serviceProvider)
        {
            var customerGenerationService = serviceProvider.GetService<ICustomerGenerationService>();

            var customerListFromJsonFile = customerGenerationService.GenerateCustomerObject().ToList();

            return customerListFromJsonFile;
        }

        private static void GetInvitedCustomers(List<Customer> customerListFromJsonFile,
            IServiceProvider serviceProvider)
        {
            var genericDistanceCalculatorService =
                serviceProvider.GetService<IGenericDistanceCalculatorService>();

            customerListFromJsonFile.ForEach(customer =>
            {
                if (ValidationHelper.IsCustomerObjectValid(customer))
                {
                    var customerDistanceToInterComOffice =
                        genericDistanceCalculatorService.CalculateGreatCircleDistance(
                            new Position
                            {
                                Latitude = customer.Latitude,
                                Longitude = customer.Longitude
                            });

                    if (ValidationHelper.IsCustomerPositionWithInDistance(customerDistanceToInterComOffice,
                        WithinDistance)) Console.WriteLine($"{customer.Id} - {customer.Name}");
                }
                else
                {
                    Console.WriteLine("Customer object is not valid, please check input file");
                }
            });
        }
    }
}