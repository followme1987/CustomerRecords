using System;
using System.Collections.Generic;
using System.Linq;
using CustomerRecords.Domain;
using CustomerRecords.Infrastructure.Service;
using NUnit.Framework;

namespace CustomerRecords.Infrastructure.Test
{
    [TestFixture]
    public class FileOperationServiceTest
    {
        [Test]
        public void ReadInputFile_Should_Return_All_Rows()
        {
            var filePath = @"TestFile\customers.txt";

            var fileOperationService = new FileOperationService(filePath);

            var returnedList = fileOperationService.ReadInputFile();

            var actual = returnedList.Count();

            var expected = 5;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReadInputFile_Should_Throw_Exception_When_FilePath_Is_Null()
        {
            var fileOperationService = new FileOperationService(null);

            var ex = Assert.Throws<ArgumentNullException>(() => fileOperationService.ReadInputFile());
        }

        [TestCaseSource(typeof(CustomerJsonCollection), "_customerJsonArray")]
        public void DeserializeJsonFileToObject_Should_Deserialize_Json_To_Object(List<string> customerJsonStringList)
        {
            var fileOperationService = new FileOperationService();

            var customerObject = fileOperationService.DeserializeJsonFileToObject(customerJsonStringList);

            var actual = customerObject.Count();

            var expected = 5;

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(CustomerJsonCollection), "_customerJsonArray")]
        public void DeserializeJsonFileToObject_Should_Deserialize_CustomerJson_To_CustomerObject(List<string> customerJsonStringList)
        {
            var fileOperationService = new FileOperationService();

            var actualObject = fileOperationService.DeserializeJsonFileToObject(customerJsonStringList);

            Assert.IsTrue(actualObject is IEnumerable<Customer>);
        }

        [Test]
        public void DeserializeJsonFileToObject_CustomerJson_Should_Have_Same_Properties_With_CustomerObject()
        {
            var fileOperationService = new FileOperationService();

            var customerJsonList = new List<string>
            {
                "{'latitude': '52.986375', 'user_id': 12, 'name': 'Christina McArdle', 'longitude': '-6.043701'}"
            };

            var actualObject = fileOperationService.DeserializeJsonFileToObject(customerJsonList).FirstOrDefault();

            var expectedLatitude = 52.986375;
            var expectedId = 12;
            var expectedName = "Christina McArdle";
            var expectedLongitude = -6.043701;

            Assert.AreEqual(expectedLatitude, actualObject.Latitude);
            Assert.AreEqual(expectedId, actualObject.Id);
            Assert.AreEqual(expectedName, actualObject.Name);
            Assert.AreEqual(expectedLongitude, actualObject.Longitude);
        }
    }
}