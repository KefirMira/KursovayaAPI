using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaApiADO.Models.Genres.Blank;
using CinemaApiADO.Models.HallsTypes.Blank;
using CinemaApiADO.Models.HallsTypes.Domain;
using CinemaApiADO.Models.HallsTypes.View;
using CinemaApiAdo.Services.HallTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApiADO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HallTypesController : ControllerBase
    {
        private readonly ILogger<HallTypesController> _logger;
        private readonly IHallTypeService _service;
        public HallTypesController(ILogger<HallTypesController> logger, IHallTypeService sessionService)
        {
            _logger = logger;
            _service = sessionService;
        }

        [HttpGet("all")]
        public IEnumerable<HallTypeView> GetAll()
        {
            IEnumerable<HallTypeDomain> sessiondomain = _service.GetAllHallType();
            return HallTypeView.Convert(sessiondomain);
        }
          
        [HttpPost("create")]
        public IActionResult Create([FromBody] HallTypeBlank hallTypeBlank)
        {
            if (_service.CreateHallType(hallTypeBlank))
                return Ok();
            else
                return NotFound();
        }

        [HttpPost("remove")]
        public IActionResult Delete(int HallTypeId)
        {
            if (_service.DeleteHallType(HallTypeId))
                return Ok();
            else
                return NotFound();
        }

        [HttpPost("update")]
        public IActionResult Update(int HallTypeId, HallTypeBlank hallTypeBlank)
        {
            if (_service.UpdateHallType(HallTypeId, hallTypeBlank))
                return Ok();
            else
                return NotFound();
        }
    }
}
