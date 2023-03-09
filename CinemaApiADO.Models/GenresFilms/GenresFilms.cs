using CinemaApiADO.Models.Films.DB;
using CinemaApiADO.Models.Films.Domain;
using CinemaApiADO.Models.Genres.DB;
using CinemaApiADO.Models.Genres.Domain;

namespace CinemaApiADO.Models.GenresFilms;

public class GenresFilms
{
    public int Id { get; set; }
    public GenreDB? Genre { get; set; } = new GenreDB();
    public FilmDB? Film { get; set; } = new FilmDB();
    public int genreId { get; set; }
    public int filmId { get; set; }
}