using CinemaApiADO.Models.Companies.Domain;
using CinemaApiADO.Models.FilmProductions.Blank;
using CinemaApiADO.Models.FilmProductions.DB;
using CinemaApiADO.Models.FilmProductions.Domain;
using Npgsql;

namespace CinemaApiAdo.Services.FilmProductions;

public class FilmProductionService:IFilmProductionService
{
    private readonly FilmProductionRepository _repository;
    
    public FilmProductionService()
    {
        _repository = new FilmProductionRepository();
    }

    public bool CreateFilmProduction(FilmProductionBlank filmProductionBlank)
    {
        try
        {
            FilmProductionDB newCompany = FilmProductionDB.Convert(filmProductionBlank);
            _repository.CreateFilmProduction(newCompany);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool UpdateFilmProduction(int filmProductionId, FilmProductionBlank filmProduction)
    {
        try
        {
            FilmProductionDB updateCompany = FilmProductionDB.Convert(filmProduction);
            _repository.UpdateFilmProduction(filmProductionId, updateCompany);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool DeleteFilmProduction(int filmProductionId)
    {
        try
        {
            _repository.DeleteFilmProduction(filmProductionId);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public IEnumerable<FilmProductionDomain> GetAllFilmProduction()
    {
        IEnumerable<FilmProductionDB> allcompanies = _repository.GetAllFilmProduction();
        return FilmProductionDomain.Convert(allcompanies);
    }
}