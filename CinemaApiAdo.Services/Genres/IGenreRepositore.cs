using CinemaApiADO.Models.Films.Domain;
using CinemaApiADO.Models.Genres.Blank;
using CinemaApiADO.Models.Genres.DB;

namespace CinemaApiAdo.Services.Genres;

public interface IGenreRepositore
{
    void CreateGenre(GenreDB genre);
    void UpdateGenre(GenreDB genre);
    void DeleteGenre(int genreId);
    GenreDB GetGenre(int genreId);
    IEnumerable<GenreDB> GetAllGenres();
}