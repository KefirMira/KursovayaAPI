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

    public void CreateFilmProduction(FilmProductionBlank filmProductionBlank)
    {
        FilmProductionDB newCompany = FilmProductionDB.Convert(filmProductionBlank);
        _repository.CreateFilmProduction(newCompany);
    }

    public void UpdateFilmProduction(int filmProductionId, FilmProductionBlank filmProduction)
    {
        FilmProductionDB updateCompany = FilmProductionDB.Convert(filmProduction);
        _repository.UpdateFilmProduction(filmProductionId,updateCompany);
    }

    public void DeleteFilmProduction(int filmProductionId)
    {
        _repository.DeleteFilmProduction(filmProductionId);
    }

    public IEnumerable<FilmProductionDomain> GetAllFilmProduction()
    {
        IEnumerable<FilmProductionDB> allcompanies = _repository.GetAllFilmProduction();
        return FilmProductionDomain.Convert(allcompanies);
    }
}