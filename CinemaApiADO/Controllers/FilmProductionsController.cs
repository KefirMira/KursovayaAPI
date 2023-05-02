using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaApiADO.Models.FilmProductions.Blank;
using CinemaApiADO.Models.FilmProductions.Domain;
using CinemaApiADO.Models.FilmProductions.View;
using CinemaApiAdo.Services.FilmProductions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApiADO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmProductionsController : ControllerBase
    {
        private readonly ILogger<FilmProductionsController> _logger;
        private readonly IFilmProductionService _service;
        public FilmProductionsController(ILogger<FilmProductionsController> logger, IFilmProductionService service)
        {
            _logger = logger;
            _service = service;
        }
        [HttpGet("all")]
        public IEnumerable<FilmProductionView> GetAll()
        {
            IEnumerable<FilmProductionDomain> companyDomains = _service.GetAllFilmProduction();
            return FilmProductionView.Convert(companyDomains);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] FilmProductionBlank companyBlank)
        {
            if (_service.CreateFilmProduction(companyBlank))
                return Ok();
            else
                return NotFound();
        }

        [HttpPost("remove")]
        public IActionResult Delete(int companyId)
        {
            if (_service.DeleteFilmProduction(companyId))
                return Ok();
            else
                return NotFound();
            
        }

        [HttpPost("update")]
        public IActionResult Update(int companyId, FilmProductionBlank companyBlank)
        {
            if (_service.UpdateFilmProduction(companyId,companyBlank))
                return Ok();
            else
                return NotFound();
            
        }
    }
}
