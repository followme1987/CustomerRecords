using CustomerRecords.Domain;

namespace CustomerRecords.Start.Test
{
    internal class CustomersWithOutOfRangeLongitude
    {
        private static object[] _customerArray =
        {
            new Customer
            {
                Id = 1,
                Name = "Christina McArdle",
                Latitude = 91,
                Longitude = 181
            },
            new Customer
            {
                Id = 2,
                Name = "Ian McArdle",
                Latitude = 53,
                Longitude = -181
            }
        };
    }
}