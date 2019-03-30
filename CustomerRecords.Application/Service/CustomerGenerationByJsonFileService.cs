using System.Collections.Generic;
using CustomerRecords.Application.Service.Interface;
using CustomerRecords.Domain;
using CustomerRecords.Infrastructure.Service;

namespace CustomerRecords.Application.Service
{
    public class CustomerGenerationByJsonFileService : ICustomerGenerationService
    {
        private readonly IFileOperationService _fileOperationService;

        public CustomerGenerationByJsonFileService(IFileOperationService fileOperationService)
        {
            _fileOperationService = fileOperationService;
        }


        public IEnumerable<Customer> GenerateCustomerObject()
        {
            var inputFile = _fileOperationService.ReadInputFile();

            return _fileOperationService.DeserializeJsonFileToObject(inputFile);
        }
    }
}