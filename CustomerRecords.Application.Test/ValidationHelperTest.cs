using CustomerRecords.Application.Util;
using CustomerRecords.Domain;
using NUnit.Framework;

namespace CustomerRecords.Application.Test
{
    [TestFixture]
    public class ValidationHelperTests
    {
        [Test]
        public void IsCustomerObjectValid_Should_Return_False_when_Customer_Name_Is_Empty()
        {
            var customer = new Customer
            {
                Id = 1,
                Name = "",
                Latitude = 1,
                Longitude = 1
            };

            var returned = ValidationHelper.IsCustomerObjectValid(customer);

            Assert.IsFalse(returned);
        }

        [Test]
        public void IsCustomerObjectValid_Should_Return_False_when_Customer_Is_Null()
        {
            Customer customer = null;

            var returned = ValidationHelper.IsCustomerObjectValid(customer);

            Assert.IsFalse(returned);
        }

        [TestCaseSource(typeof(CustomersWithOutOfRangeLatitude), "_customerArray")]
        public void IsCustomerObjectValid_Should_Return_False_when_Customer_Latitude_Is_Out_Of_Range(Customer customer)
        {
            var returned = ValidationHelper.IsCustomerObjectValid(customer);

            Assert.IsFalse(returned);
        }

        [TestCaseSource(typeof(CustomersWithOutOfRangeLongitude), "_customerArray")]
        public void IsCustomerObjectValid_Should_Return_False_when_Customer_Longitude_Is_Out_Of_Range(Customer customer)
        {
            var returned = ValidationHelper.IsCustomerObjectValid(customer);

            Assert.IsFalse(returned);
        }

        [Test]
        public void IsCustomerObjectValid_Should_Return_True_when_Customer_is_Valid()
        {
            var customer = new Customer
            {
                Id = 1,
                Name = "test",
                Latitude = 1,
                Longitude = 1
            };

            var returned = ValidationHelper.IsCustomerObjectValid(customer);

            Assert.IsTrue(returned);
        }

        [Test]
        public void
            IsCustomerPositionWithInDistance_Should_Return_False_When_CustomerDistance_GreaterAndEqual_Than_WithinDistance()
        {
            var withInDistance = 100;
            var customerDistance = 110;

            var returned = ValidationHelper.IsCustomerPositionWithInDistance(customerDistance, withInDistance);

            Assert.IsFalse(returned);
        }

        [Test]
        public void
            IsCustomerPositionWithInDistance_Should_Return_False_When_CustomerDistance_Less_Than_WithinDistance()
        {
            var withInDistance = 100;
            var customerDistance = 99;

            var returned = ValidationHelper.IsCustomerPositionWithInDistance(customerDistance, withInDistance);

            Assert.IsTrue(returned);
        }
    }
}