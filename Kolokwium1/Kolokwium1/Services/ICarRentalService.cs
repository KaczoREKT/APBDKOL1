namespace Kolokwium1.Services;

public interface ICarRentalService
{
    Task<int> CalculateTotalPriceAsync(int carId, DateTime dateFrom, DateTime dateTo);
}
