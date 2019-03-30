using System;
using CustomerRecords.Domain;

namespace CustomerRecords.Start.Util
{
    public static class ValidationHelper
    {
        public static bool IsCustomerObjectValid(Customer customer)
        {
            if (customer == null)
            {
                Console.WriteLine("Customer object is null - invalid");

                return false;
            }

            if (string.IsNullOrEmpty(customer.Name))
            {
                Console.WriteLine("Customer name is empty - invalid");

                return false;
            }

            if (customer.Latitude > 90 || customer.Latitude < -90)
            {
                Console.WriteLine("Customer latitude is out of range - invalid");

                return false;
            }

            if (customer.Longitude > 180 || customer.Longitude < -180)
            {
                Console.WriteLine("Customer longitude is out of range - invalid");

                return false;
            }

            return true;
        }

        public static bool IsCustomerPositionWithInDistance(double customerDistanceToInterComOffice,
            double withinDistance)
        {
            return customerDistanceToInterComOffice < withinDistance;
        }
    }
}