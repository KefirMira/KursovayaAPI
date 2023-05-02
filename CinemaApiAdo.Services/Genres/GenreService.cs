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
    
    public bool CreateGenre(GenreBlank genre)
    {
        try
        {
            GenreDB newGenre = GenreDB.Convert(genre);
            _repository.CreateGenre(newGenre);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool UpdateGenre(int genreId, GenreBlank genre)
    {
        try
        {
            GenreDB updateGenre = GenreDB.Convert(genreId, genre);
            _repository.UpdateGenre(updateGenre);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool DeleteGenre(int genreId)
    {
        try
        {
            _repository.DeleteGenre(genreId);
            return true;
        }
        catch
        {
            return false;
        }
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