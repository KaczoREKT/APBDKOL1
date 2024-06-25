using Kolokwium1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium1.DTO;

namespace Kolokwium1.Services
{
    public class ClientService : IClientService
    {
        private readonly MyDbContext _context;
        private readonly ICarRentalService _carRentalService;

        public ClientService(MyDbContext context, ICarRentalService carRentalService)
        {
            _context = context;
            _carRentalService = carRentalService;
        }

        public async Task<ClientDto> GetClientWithRentalsAsync(int clientId)
        {
            var client = await _context.Clients
                .Include(c => c.CarRentals)
                    .ThenInclude(cr => cr.Car)
                        .ThenInclude(car => car.Model)
                .Include(c => c.CarRentals)
                    .ThenInclude(cr => cr.Car)
                        .ThenInclude(car => car.Color)
                .FirstOrDefaultAsync(c => c.ID == clientId);

            if (client == null) return null;

            return new ClientDto
            {
                Id = client.ID,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Address = client.Address,
                Rentals = client.CarRentals.Select(cr => new CarRentalDto
                {
                    Vin = cr.Car.VIN,
                    Color = cr.Car.Color.Name,
                    Model = cr.Car.Model.Name,
                    DateFrom = cr.DateFrom,
                    DateTo = cr.DateTo,
                    TotalPrice = cr.TotalPrice
                }).ToList()
            };
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
                TotalPrice = totalPrice,
                Discount = 0
            };

            await _context.Clients.AddAsync(client);
            await _context.CarRentals.AddAsync(carRental);

            await _context.SaveChangesAsync();
        }
    }
}
