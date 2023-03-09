using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaApiADO.Models.Clients;
using CinemaApiADO.Models.Clients.Blank;
using CinemaApiADO.Models.Clients.Domain;
using CinemaApiADO.Models.Clients.View;
using CinemaApiADO.Models.Companies.Blank;
using CinemaApiAdo.Services.Clients;
using CinemaApiAdo.Services.Companies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApiADO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ILogger<ClientsController> _logger;
        private readonly IClientService _clientService;
        public ClientsController(ILogger<ClientsController> logger, IClientService clientService)
        {
            _logger = logger;
            _clientService = clientService;
        }

        [HttpGet("all")]
        public IEnumerable<ClientView> GetAll()
        {
            IEnumerable<ClientDomain> clientsdomain = _clientService.GetAllClients();
            return ClientView.Convert(clientsdomain);
        }

        [HttpGet("{clientId}")]
        public ClientView Get(int clientId)
        {
            ClientDomain client = _clientService.GetClient(clientId);
            return ClientView.Convert(client);
        }
        [HttpPost("create")]
        public IActionResult Create([FromBody] ClientBlank clientBlank)
        {
            bool rez = _clientService.CreateClient(clientBlank);
            if (rez)
                return Ok();
            else
                return NotFound();
        }

        [HttpPost("remove")]
        public void Delete(int clientId)
        {
            _clientService.DeleteClient(clientId);
        }

        [HttpPost("update")]
        public void Update(int clientId, ClientBlank clientBlank)
        {
            _clientService.UpdateClient(clientId,clientBlank);
        }

        
        
        [HttpPost("authorization")]
        public IActionResult Authorization([FromBody]Auth auth)
        {
            ClientDomain client = _clientService.GetClient(auth.Login,auth.Password);
            if (client.Login != null)
                return Ok();
            else
                return NotFound();
        }
    }
}
