namespace Kolokwium1.Controllers;
using Kolokwium1.Services;
using Kolokwium1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientsController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet("{clientId}")]
    public async Task<IActionResult> GetClient(int clientId)
    {
        var client = await _clientService.GetClientWithRentalsAsync(clientId);
        if (client == null) return NotFound();
        return Ok(client);
    }

    [HttpPost]
    public async Task<IActionResult> AddClient([FromBody] AddClientRequest request)
    {
        var client = new Client
        {
            FirstName = request.Client.FirstName,
            LastName = request.Client.LastName,
            Address = request.Client.Address
        };

        await _clientService.AddClientWithRentalAsync(client, request.CarId, request.DateFrom, request.DateTo);
        return CreatedAtAction(nameof(GetClient), new { clientId = client.ID }, client);
    }
}

public class AddClientRequest
{
    public ClientDto Client { get; set; }
    public int CarId { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
}

public class ClientDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
}
