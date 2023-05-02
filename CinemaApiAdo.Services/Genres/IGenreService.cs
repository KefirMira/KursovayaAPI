using CinemaApiADO.Models.Films.Domain;
using CinemaApiADO.Models.Genres.Blank;
using CinemaApiADO.Models.Genres.Domain;

namespace CinemaApiAdo.Services.Genres;

public interface IGenreService
{
    bool CreateGenre(GenreBlank genre);
    bool UpdateGenre(int genreId,GenreBlank genre);
    bool DeleteGenre(int genreId);
    GenreDomain GetGenre(int genreId);
    IEnumerable<GenreDomain> GetAllGenres();
}