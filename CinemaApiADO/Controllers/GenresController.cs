using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaApiADO.Models.Companies.Blank;
using CinemaApiADO.Models.Genres.Blank;
using CinemaApiADO.Models.Genres.Domain;
using CinemaApiADO.Models.Genres.View;
using CinemaApiAdo.Services.Genres;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApiADO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly ILogger<GenresController> _logger;
        private readonly IGenreService _genreService;

        public GenresController(ILogger<GenresController> logger, IGenreService clientService)
        {
            _logger = logger;
            _genreService = clientService;
        }

        [HttpGet("all")]
        public IEnumerable<GenreView> GetAll()
        {
            IEnumerable<GenreDomain> genredomain = _genreService.GetAllGenres();
            return GenreView.Convert(genredomain);
        }
        [HttpGet("{genreId}")]
        public GenreView Get(int genreId)
        {
            GenreDomain selectedGenre = _genreService.GetGenre(genreId);
            return GenreView.Convert(selectedGenre);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] GenreBlank genreBlank)
        {
            if (_genreService.CreateGenre(genreBlank))
                return Ok();
            else
                return NotFound();
        }

        [HttpPost("remove")]
        public IActionResult Delete(int genreId)
        {
            if (_genreService.DeleteGenre(genreId))
                return Ok();
            else
                return NotFound();
            
        }

        [HttpPost("update")]
        public IActionResult Update(int genreId, GenreBlank genreBlank)
        {
            if (_genreService.UpdateGenre(genreId,genreBlank))
                return Ok();
            else
                return NotFound();
            
        }
    }
}
