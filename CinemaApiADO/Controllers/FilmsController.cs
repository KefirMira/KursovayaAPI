

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
        public void Create([FromBody] FilmBlank newfilm)
        {
            _filmService.CreateFilm(newfilm);
        }

        [HttpPost("remove")]
        public void Delete(int filmId)
        {
            _filmService.DeleteFilm(filmId);
        }

        [HttpPost("update")]
        public void Update(int filmId, FilmBlank film)
        {
            _filmService.UpdateFilm(filmId,film);
        }
        [HttpPost("creategenresfilm")]
        public void CreateGenresFilm([FromBody] GenresFilms genresFilms)
        {
            _filmService.CreateGenresFilm(genresFilms);
        }
        [HttpPost("createcastefilm")]
        public void CreateCasteFilm([FromBody] Caste caste)
        {
            _filmService.CreateCasteFilm(caste);
        }
    }
}
