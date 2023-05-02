

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaApiADO.Models.Castes;
using CinemaApiADO.Models.Films.Blank;
using CinemaApiADO.Models.Films.Domain;
using CinemaApiADO.Models.Films.View;
using CinemaApiADO.Models.GenresFilms;
using CinemaApiAdo.Services.Films;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApiADO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly ILogger<FilmsController> _logger;
        private readonly IFilmService _filmService;

        public FilmsController(ILogger<FilmsController> logger, IFilmService filmService)
        {
            _logger = logger;
            _filmService = filmService;
        }

        [HttpGet("all")]
        public IEnumerable<FilmView> GetAll()
        {
            IEnumerable<FilmDomain> filmDomains = _filmService.GetAllFilm();
            return FilmView.Convert(filmDomains);
        }

        [HttpGet("{filmId}")]
        public FilmView Get(int filmId)
        {
            FilmDomain selectedFilm = _filmService.GetFilm(filmId);
            return FilmView.Convert(selectedFilm);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] FilmBlank newfilm)
        {
            if (_filmService.CreateFilm(newfilm))
                return Ok();
            else
                return NotFound();
        }

        [HttpPost("remove")]
        public IActionResult Delete(int filmId)
        {
            if (_filmService.DeleteFilm(filmId))
                return Ok();
            else
                return NotFound();
            
        }

        [HttpPost("update")]
        public IActionResult Update(int filmId, FilmBlank film)
        {
            if (_filmService.UpdateFilm(filmId,film))
                return Ok();
            else
                return NotFound();
            
        }
        [HttpPost("creategenresfilm")]
        public IActionResult CreateGenresFilm([FromBody] GenresFilms genresFilms)
        {
            if (_filmService.CreateGenresFilm(genresFilms))
                return Ok();
            else
                return NotFound();
            
        }
        [HttpPost("createcastefilm")]
        public IActionResult CreateCasteFilm([FromBody] Caste caste)
        {
            if (_filmService.CreateCasteFilm(caste))
                return Ok();
            else
                return NotFound();
            
        }
    }
}
