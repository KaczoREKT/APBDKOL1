using Kolokwium1.Models;
using Kolokwium1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium1.Controllers
{
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

            try
            {
                await _clientService.AddClientWithRentalAsync(client, request.CarId, request.DateFrom, request.DateTo);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            
            return CreatedAtAction(nameof(GetClient), new { clientId = client.ID }, client);
        }
    }
}