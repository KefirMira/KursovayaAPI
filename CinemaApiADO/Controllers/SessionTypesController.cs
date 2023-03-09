using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaApiADO.Models.Cinemas.Domain;
using CinemaApiADO.Models.Cinemas.View;
using CinemaApiADO.Models.SessionsTypes.Domain;
using CinemaApiADO.Models.SessionsTypes.View;
using CinemaApiAdo.Services.SessionsTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApiADO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionTypesController : ControllerBase
    {
        private readonly ILogger<SessionTypesController> _logger;
        private readonly ISessionTypeService _sessionService;
        public SessionTypesController(ILogger<SessionTypesController> logger, ISessionTypeService sessionService)
        {
            _logger = logger;
            _sessionService = sessionService;
        }

        [HttpGet("all")]
        public IEnumerable<SessionTypeView> GetAll()
        {
            IEnumerable<SessionTypeDomain> sessiondomain = _sessionService.GetAllSessionType();
            return SessionTypeView.Convert(sessiondomain);
        }
    }
}
