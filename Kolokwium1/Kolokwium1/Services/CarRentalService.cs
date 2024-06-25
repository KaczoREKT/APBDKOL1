namespace Kolokwium1.Services;

public class CarRentalService : ICarRentalService
{
    private readonly MyDbContext _context;

    public CarRentalService(MyDbContext context)
    {
        _context = context;
    }

    public async Task<int> CalculateTotalPriceAsync(int carId, DateTime dateFrom, DateTime dateTo)
    {
        var car = await _context.Cars.FindAsync(carId);
        var days = (dateTo - dateFrom).Days;
        return car.PricePerDay * days;
    }
}
