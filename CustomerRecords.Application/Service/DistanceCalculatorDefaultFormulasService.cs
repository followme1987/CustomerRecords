using System;
using CustomerRecords.Application.Service.Interface;
using CustomerRecords.Domain;

namespace CustomerRecords.Application.Service
{
    public class DistanceCalculatorDefaultFormulasService : IGenericDistanceCalculatorService
    {
        private readonly double _destinationLatitude;
        private readonly double _destinationLongitude;
        private readonly double _radius;

        public DistanceCalculatorDefaultFormulasService()
        {
            _radius = 6371;
            _destinationLatitude = 53.339428;
            _destinationLongitude = -6.257664;
        }

        public double CalculateGreatCircleDistance(Position customerPosition)
        {
            if (customerPosition == null) throw new NullReferenceException();

            var (customerRadiansLatitude, customerRadiansLongitude) =
                DegreesToRadians(customerPosition.Latitude, customerPosition.Longitude);
            var (destinationRadiansLatitude, destinationRadiansLongitude) =
                DegreesToRadians(_destinationLatitude, _destinationLongitude);

            var absoluteDifferences =
                CalculateAbsoluteDifferences(customerRadiansLongitude, destinationRadiansLongitude);

            var centralAngle = Math.Acos(Math.Sin(customerRadiansLatitude) * Math.Sin(destinationRadiansLatitude) +
                                         Math.Cos(customerRadiansLatitude) * Math.Cos(destinationRadiansLatitude) *
                                         Math.Cos(absoluteDifferences));

            var result = _radius * centralAngle;

            return result;
        }

        private static double CalculateAbsoluteDifferences(double customerLongitude, double destinationLongitude)
        {
            var dLon = Math.Abs(destinationLongitude - customerLongitude);
            return dLon;
        }

        private static (double lat, double lon) DegreesToRadians(double degreesLatitude, double degreesLongitude)
        {
            return (lat: degreesLatitude * Math.PI / 180.0, lon: degreesLongitude * Math.PI / 180.0);
        }
    }
}