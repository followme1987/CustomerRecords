using System;
using CustomerRecords.Application.Service;
using CustomerRecords.Domain;
using NUnit.Framework;

namespace CustomerRecords.Application.Test
{
    [TestFixture]
    public class DistanceCalculatorDefaultFormulasServiceTest
    {

        [Test]
        public void CalculateGreatCircleDistance_Should_Return_Correct_Distance()
        {
            var service = new DistanceCalculatorDefaultFormulasService();

            var position = new Position
            {
                Latitude = 52.986375,
                Longitude = -6.043701
            };

            var actual = Math.Truncate(service.CalculateGreatCircleDistance(position) * 1000) / 1000;

            var expected = 41.768;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculateGreatCircleDistance_Should_Throw_Exception_When_Position_Is_Null()
        {
            var service = new DistanceCalculatorDefaultFormulasService();

            Assert.Throws<NullReferenceException>(() => service.CalculateGreatCircleDistance(null));
        }
    }
}