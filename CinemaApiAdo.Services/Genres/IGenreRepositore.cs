using CinemaApiADO.Models.Films.Domain;
using CinemaApiADO.Models.Genres.Blank;
using CinemaApiADO.Models.Genres.DB;

namespace CinemaApiAdo.Services.Genres;

public interface IGenreRepositore
{
    bool CreateGenre(GenreDB genre);
    bool UpdateGenre(GenreDB genre);
    bool DeleteGenre(int genreId);
    GenreDB GetGenre(int genreId);
    IEnumerable<GenreDB> GetAllGenres();
}