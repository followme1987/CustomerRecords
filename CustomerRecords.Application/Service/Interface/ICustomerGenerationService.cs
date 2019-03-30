using System.Collections.Generic;
using CustomerRecords.Domain;

namespace CustomerRecords.Application.Service.Interface
{
    public interface ICustomerGenerationService
    {
        IEnumerable<Customer> GenerateCustomerObject();
    }
}