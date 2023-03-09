using CinemaApiADO.Models.Films.Domain;
using CinemaApiADO.Models.Genres.Blank;
using CinemaApiADO.Models.Genres.Domain;

namespace CinemaApiAdo.Services.Genres;

public interface IGenreService
{
    void CreateGenre(GenreBlank genre);
    void UpdateGenre(int genreId,GenreBlank genre);
    void DeleteGenre(int genreId);
    GenreDomain GetGenre(int genreId);
    IEnumerable<GenreDomain> GetAllGenres();
}