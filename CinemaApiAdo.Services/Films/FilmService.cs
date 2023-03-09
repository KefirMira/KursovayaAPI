using CinemaApiADO.Models.Castes;
using CinemaApiADO.Models.Companies.Blank;
using CinemaApiADO.Models.Films.Blank;
using CinemaApiADO.Models.Films.DB;
using CinemaApiADO.Models.Films.Domain;
using CinemaApiADO.Models.Genres.Blank;
using CinemaApiADO.Models.GenresFilms;

namespace CinemaApiAdo.Services.Films;

public class FilmService: IFilmService
{
    private readonly FilmRepository _repository;

    public FilmService()
    {
        _repository = new FilmRepository();
    }
    
    public void CreateFilm(FilmBlank film)
    {
        FilmDB newfilm = FilmDB.Convert(film);
        _repository.CreateFilm(newfilm);
    }

    public void UpdateFilm(int filmId, FilmBlank film)
    {
        FilmDB upfilm = FilmDB.Convert(filmId,film);
        _repository.UpdateFilm(upfilm);
    }

    public void DeleteFilm(int filmId)
    {
        _repository.DeleteFilm(filmId);
    }

    public FilmDomain GetFilm(int filmId)
    {
        FilmDB filmDB = _repository.GetFilm(filmId);
        List<GenreBlank> genrefilm = _repository.GetGenreFilm(filmId).ToList();
        List<CastesFilmBlank> castesFilmBlanks = _repository.GetCastesFilm(filmId).ToList();
        List<CompanyBlank> companiesBlank = _repository.GetCompanyFilm(filmId).ToList();
        // в промежуточную таблицу по ид
        //     конвертация в модель 
        //     объединение
        return FilmDomain.Convert(filmDB, genrefilm,castesFilmBlanks, companiesBlank);
    }

    public IEnumerable<FilmDomain> GetAllFilm()
    {
        IEnumerable<FilmDB> allfilms = _repository.GetAllFilm();
        List<FilmDomain> allinfofilm = new List<FilmDomain>();
        foreach (var item in allfilms)
        {
            List<GenreBlank> genrefilm = _repository.GetGenreFilm(item.Id).ToList();
            List<CastesFilmBlank> castesFilmBlanks = _repository.GetCastesFilm(item.Id).ToList();
            List<CompanyBlank> companiesBlank = _repository.GetCompanyFilm(item.Id).ToList();
            allinfofilm.Add(FilmDomain.Convert(item,genrefilm,castesFilmBlanks,companiesBlank));
        }
        return allinfofilm;
    }

    public void CreateGenresFilm(GenresFilms genresFilms)
    {
        _repository.CreateGenresFilm(genresFilms);
    }

    public void CreateCasteFilm(Caste caste)
    {
        _repository.CreateCasteFilm(caste);
    }
}