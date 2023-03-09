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
        public void Create([FromBody] HallTypeBlank hallTypeBlank)
        {
            _service.CreateHallType(hallTypeBlank);
        }

        [HttpPost("remove")]
        public void Delete(int HallTypeId)
        {
            _service.DeleteHallType(HallTypeId);
        }

        [HttpPost("update")]
        public void Update(int HallTypeId, HallTypeBlank hallTypeBlank)
        {
            _service.UpdateHallType(HallTypeId,hallTypeBlank);
        }
    }
}
