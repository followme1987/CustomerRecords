using CustomerRecords.Application.Service.Interface;
using CustomerRecords.Application.Util;
using CustomerRecords.Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace CustomerRecords.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerRecordsController : ControllerBase
    {
        private const double WithinDistance = 100;

        private readonly ICustomerGenerationService _customerGenerationService;

        private readonly IGenericDistanceCalculatorService _genericDistanceCalculatorService;

        public CustomerRecordsController(ICustomerGenerationService customerGenerationService, IGenericDistanceCalculatorService genericDistanceCalculatorService)
        {
            _customerGenerationService = customerGenerationService;

            _genericDistanceCalculatorService = genericDistanceCalculatorService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var customerListFromJsonFile = GetFullCustomerListFromJasonFile();

            if (customerListFromJsonFile.Any())
            {
                var getInvitedCustomerQueue = GetInvitedCustomers(customerListFromJsonFile);

                return new JsonResult(getInvitedCustomerQueue);
            }
            else
            {
                return new JsonResult("No customers retrieved from the file");
            }
        }

        private List<Customer> GetFullCustomerListFromJasonFile()
        {
            var customerListFromJsonFile = _customerGenerationService.GenerateCustomerObject().ToList();

            return customerListFromJsonFile;
        }

        private Queue<string> GetInvitedCustomers(List<Customer> customerListFromJsonFile)
        {
            var getInvitedCustomerQueue = new Queue<string>();

            customerListFromJsonFile.ForEach((customer) =>
            {
                if (ValidationHelper.IsCustomerObjectValid(customer))
                {
                    var customerDistanceToInterComOffice = CalculateCustomerToOfficeDistance(customer);

                    if (ValidationHelper.IsCustomerPositionWithInDistance(customerDistanceToInterComOffice,
                        WithinDistance))
                    {
                        var serializedString = SerializeToJsonString(customer);

                        getInvitedCustomerQueue.Enqueue(serializedString);
                    }
                }
            });

            return getInvitedCustomerQueue;
        }

        private static string SerializeToJsonString(Customer customer)
        {
            var serializedString = JsonConvert.SerializeObject(new
            {
                Id = customer.Id,
                Name = customer.Name
            });

            return serializedString;
        }

        private double CalculateCustomerToOfficeDistance(Customer customer)
        {
            var customerDistanceToInterComOffice =
                _genericDistanceCalculatorService.CalculateGreatCircleDistance(
                    new Position
                    {
                        Latitude = customer.Latitude,
                        Longitude = customer.Longitude
                    });

            return customerDistanceToInterComOffice;
        }
    }
}
