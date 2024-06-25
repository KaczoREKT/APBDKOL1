using Kolokwium1.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium1.Services;

public class ClientService : IClientService
{
    private readonly MyDbContext _context;
    private readonly ICarRentalService _carRentalService;

    public ClientService(MyDbContext context, ICarRentalService carRentalService)
    {
        _context = context;
        _carRentalService = carRentalService;
    }

    public async Task<Client> GetClientWithRentalsAsync(int clientId)
    {
        return await _context.Client
            .Include(c => c.CarRentals)
            .ThenInclude(cr => cr.Car)
            .ThenInclude(car => car.Model)
            .Include(c => c.CarRentals)
            .ThenInclude(cr => cr.Car)
            .ThenInclude(car => car.Color)
            .FirstOrDefaultAsync(c => c.ID == clientId);
    }

    public async Task AddClientWithRentalAsync(Client client, int carId, DateTime dateFrom, DateTime dateTo)
    {
        var totalPrice = await _carRentalService.CalculateTotalPriceAsync(carId, dateFrom, dateTo);
        var carRental = new CarRental
        {
            Client = client,
            CarID = carId,
            DateFrom = dateFrom,
            DateTo = dateTo,
            TotalPrice = totalPrice
        };

        _context.Client.Add(client);
        _context.CarRental.Add(carRental);

        await _context.SaveChangesAsync();
    }
}
