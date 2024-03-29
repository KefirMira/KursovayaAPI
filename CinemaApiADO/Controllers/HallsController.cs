using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaApiADO.Models.Films.Blank;
using CinemaApiADO.Models.Films.Domain;
using CinemaApiADO.Models.Films.View;
using CinemaApiADO.Models.Halls.Blank;
using CinemaApiADO.Models.Halls.Domain;
using CinemaApiADO.Models.Halls.View;
using CinemaApiAdo.Services.Films;
using CinemaApiAdo.Services.Halls;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApiADO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HallsController : ControllerBase
    {
        private readonly ILogger<HallsController> _logger;
        private readonly IHallService _hallService;

        public HallsController(ILogger<HallsController> logger, IHallService hallService)
        {
            _logger = logger;
            _hallService = hallService;
        }

        [HttpGet("all")]
        public IEnumerable<HallView> GetAll()
        {
            IEnumerable<HallDomain> hallDomains = _hallService.GetAllHall();
            return HallView.Convert(hallDomains);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] HallBlank newhall)
        {
            if (_hallService.CreateHall(newhall))
                return Ok();
            else
                return NotFound();
        }

        [HttpPost("remove")]
        public IActionResult Delete(int hallId)
        {
            if (_hallService.DeleteHall(hallId))
                return Ok();
            else
                return NotFound();
        }
    }
}
