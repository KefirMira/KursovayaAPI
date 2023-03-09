using CinemaApiADO.Models.Castes;
using CinemaApiADO.Models.Films.Blank;
using CinemaApiADO.Models.Films.DB;
using CinemaApiADO.Models.Films.Domain;
using CinemaApiADO.Models.GenresFilms;

namespace CinemaApiAdo.Services.Films;

public interface IFilmService
{
    void CreateFilm(FilmBlank film);
    void UpdateFilm(int filmId,FilmBlank film);
    void DeleteFilm(int filmId);
    FilmDomain GetFilm(int filmId);
    IEnumerable<FilmDomain> GetAllFilm();
    void CreateGenresFilm(GenresFilms genresFilms);
    void CreateCasteFilm(Caste caste);
}