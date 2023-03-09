using CinemaApiADO.Models.Castes;
using CinemaApiADO.Models.Films.DB;
using CinemaApiADO.Models.GenresFilms;

namespace CinemaApiAdo.Services.Films;

public interface IFilmRepository
{
    void CreateFilm(FilmDB film);
    void UpdateFilm(FilmDB film);
    void DeleteFilm(int filmId);
    FilmDB GetFilm(int filmId);
    IEnumerable<FilmDB> GetAllFilm();
    void CreateGenresFilm(GenresFilms genresFilms);
    void CreateCasteFilm(Caste caste);
}