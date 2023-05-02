using CinemaApiADO.Models.Castes;
using CinemaApiADO.Models.Films.DB;
using CinemaApiADO.Models.GenresFilms;

namespace CinemaApiAdo.Services.Films;

public interface IFilmRepository
{
    bool CreateFilm(FilmDB film);
    bool UpdateFilm(FilmDB film);
    bool DeleteFilm(int filmId);
    FilmDB GetFilm(int filmId);
    IEnumerable<FilmDB> GetAllFilm();
    bool CreateGenresFilm(GenresFilms genresFilms);
    bool CreateCasteFilm(Caste caste);
}