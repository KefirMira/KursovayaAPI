using CinemaApiADO.Models.Films.Domain;
using CinemaApiADO.Models.Genres.Blank;
using CinemaApiADO.Models.Genres.DB;
using CinemaApiADO.Models.Genres.Domain;

namespace CinemaApiAdo.Services.Genres;

public class GenreService: IGenreService
{
    private readonly GenreRepository _repository;

    public GenreService()
    {
        _repository = new GenreRepository();
    }
    
    public void CreateGenre(GenreBlank genre)
    {
        GenreDB newGenre = GenreDB.Convert(genre);
        _repository.CreateGenre(newGenre);
    }

    public void UpdateGenre(int genreId, GenreBlank genre)
    {
        GenreDB updateGenre = GenreDB.Convert(genreId,genre);
        _repository.UpdateGenre(updateGenre);
    }

    public void DeleteGenre(int genreId)
    {
        _repository.DeleteGenre(genreId);
    }

    public GenreDomain GetGenre(int genreId)
    {
        GenreDB genreDb = _repository.GetGenre(genreId);
        return GenreDomain.Convert(genreDb);
    }

    public IEnumerable<GenreDomain> GetAllGenres()
    {
        IEnumerable<GenreDB> allgenres = _repository.GetAllGenres();
        return GenreDomain.Convert(allgenres);
    }
}