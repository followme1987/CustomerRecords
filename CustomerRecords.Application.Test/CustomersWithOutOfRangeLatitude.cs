using CustomerRecords.Domain;

namespace CustomerRecords.Application.Test
{
    internal class CustomersWithOutOfRangeLatitude
    {
        private static object[] _customerArray =
        {
            new Customer
            {
                Id = 1,
                Name = "Christina McArdle",
                Latitude = 91,
                Longitude = 1
            },
            new Customer
            {
                Id = 2,
                Name = "Ian McArdle",
                Latitude = -91,
                Longitude = 1
            }
        };
    }
}