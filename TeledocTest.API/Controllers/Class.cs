using Microsoft.AspNetCore.Mvc;
using TeledocTest.API.Contracts;
using TeledocTest.Application.Services;
using TeledocTest.Core.Models;

namespace TeledocTest.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _clientService;
        
        public ClientController(ClientService clientService) 
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClientResponse>>> GetClients()
        {
            var clients = await _clientService.GetAllClients();
            var response = clients.Select(c => new ClientResponse(c.Id, c.INN, c.Title, c.Type, c.Founders));
            return Ok(response);
        }
    }
}
