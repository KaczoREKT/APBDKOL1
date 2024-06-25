namespace Kolokwium1.Services;
using Kolokwium1.Models;

public interface IClientService
{
    Task<Client> GetClientWithRentalsAsync(int clientId);
    Task AddClientWithRentalAsync(Client client, int carId, DateTime dateFrom, DateTime dateTo);
}