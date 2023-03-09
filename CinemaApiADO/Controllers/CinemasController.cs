using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaApiADO.Models.Cinemas.Domain;
using CinemaApiADO.Models.Cinemas.View;
using CinemaApiADO.Models.Clients.Domain;
using CinemaApiADO.Models.Clients.View;
using CinemaApiAdo.Services.Cinemas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApiADO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemasController : ControllerBase
    {
        private readonly ILogger<CinemasController> _logger;
        private readonly ICinemaService _cinemaService;
        public CinemasController(ILogger<CinemasController> logger, ICinemaService cinemaService)
        {
            _logger = logger;
            _cinemaService = cinemaService;
        }

        [HttpGet("all")]
        public IEnumerable<CinemaView> GetAll()
        {
            IEnumerable<CinemaDomain> cinemadomain = _cinemaService.GetAllCinemas();
            return CinemaView.Convert(cinemadomain);
        }
    }
}
