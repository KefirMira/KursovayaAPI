using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaApiADO.Models.Rentals.Blank;
using CinemaApiADO.Models.Rentals.Domain;
using CinemaApiADO.Models.Rentals.View;
using CinemaApiADO.Models.Sessions.Blank;
using CinemaApiADO.Models.Sessions.Domain;
using CinemaApiADO.Models.Sessions.View;
using CinemaApiAdo.Services.Rentals;
using CinemaApiAdo.Services.Sessions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApiADO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly ILogger<SessionsController> _logger;
        private readonly ISessionService _sessionService;

        public SessionsController(ILogger<SessionsController> logger, ISessionService sessionService)
        {
            _logger = logger;
            _sessionService = sessionService;
        }

        [HttpGet("all")]
        public IEnumerable<SessionView> GetAll()
        {
            IEnumerable<SessionDomain> sessionDomains = _sessionService.GetAllSession();
            return SessionView.Convert(sessionDomains);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] SessionBlank newsession)
        {
            if (_sessionService.CreateSession(newsession))
                return Ok();
            else
                return NotFound();
        }

        [HttpPost("remove")]
        public IActionResult Delete(int sessionId)
        {
            if (_sessionService.DeleteSession(sessionId))
                return Ok();
            else
                return NotFound();
        }
    }
}
