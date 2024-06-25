using Kolokwium1.DTO;

namespace Kolokwium1.Services;
using Kolokwium1.Models;

public interface IClientService
{
    Task<ClientDto> GetClientWithRentalsAsync(int clientId);
    Task AddClientWithRentalAsync(Client client, int carId, DateTime dateFrom, DateTime dateTo);
}