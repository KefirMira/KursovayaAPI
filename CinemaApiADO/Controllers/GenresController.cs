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
        public void Create([FromBody] GenreBlank genreBlank)
        {
            _genreService.CreateGenre(genreBlank);
        }

        [HttpPost("remove")]
        public void Delete(int genreId)
        {
            _genreService.DeleteGenre(genreId);
        }

        [HttpPost("update")]
        public void Update(int genreId, GenreBlank genreBlank)
        {
            _genreService.UpdateGenre(genreId,genreBlank);
        }
    }
}
