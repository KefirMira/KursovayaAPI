using CinemaApiADO.Models.Castes;
using CinemaApiADO.Models.Films.Blank;
using CinemaApiADO.Models.Films.DB;
using CinemaApiADO.Models.Films.Domain;
using CinemaApiADO.Models.GenresFilms;

namespace CinemaApiAdo.Services.Films;

public interface IFilmService
{
    bool CreateFilm(FilmBlank film);
    bool UpdateFilm(int filmId,FilmBlank film);
    bool DeleteFilm(int filmId);
    FilmDomain GetFilm(int filmId);
    IEnumerable<FilmDomain> GetAllFilm();
    bool CreateGenresFilm(GenresFilms genresFilms);
    bool CreateCasteFilm(Caste caste);
}