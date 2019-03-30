using CustomerRecords.Domain;

namespace CustomerRecords.Application.Service.Interface
{
    public interface IGenericDistanceCalculatorService
    {
        double CalculateGreatCircleDistance(Position customerPosition);
    }
}