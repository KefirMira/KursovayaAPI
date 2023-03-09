using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaApiADO.Models.Films.Domain;
using CinemaApiADO.Models.Films.View;
using CinemaApiADO.Models.Rentals.Blank;
using CinemaApiADO.Models.Rentals.Domain;
using CinemaApiADO.Models.Rentals.View;
using CinemaApiADO.Models.Ticket.Blank;
using CinemaApiADO.Models.Ticket.Domain;
using CinemaApiADO.Models.Ticket.View;
using CinemaApiAdo.Services.Rentals;
using CinemaApiAdo.Services.Tickets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApiADO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ILogger<TicketController> _logger;
        private readonly ITicketService _ticketService;

        public TicketController(ILogger<TicketController> logger, ITicketService ticketService)
        {
            _logger = logger;
            _ticketService = ticketService;
        }

        [HttpGet("all")]
        public IEnumerable<TicketView> GetAll()
        {
            IEnumerable<TicketDomain> ticketDomains = _ticketService.GetAllTicket();
            return TicketView.Convert(ticketDomains);
        }
        [HttpGet("{clientId}")]
        public IEnumerable<TicketView> GetAllTicketForClient(int clientId)
        {
            IEnumerable<TicketDomain> hallDomains = _ticketService.GetAllTicketClient(clientId);
            return TicketView.Convert(hallDomains);
        }

        [HttpPost("create")]
        public void Create([FromBody] TicketBlank newticket)
        {
            _ticketService.CreateTicket(newticket);
        }

        [HttpPost("remove")]
        public void Delete(int ticketId)
        {
            _ticketService.DeleteTicket(ticketId);
        }
    }
}
