using CinemaApiADO.Models.FilmProductions.Blank;
using CinemaApiADO.Models.FilmProductions.Domain;

namespace CinemaApiAdo.Services.FilmProductions;

public interface IFilmProductionService
{
    void CreateFilmProduction(FilmProductionBlank filmProductionBlank);
    void UpdateFilmProduction(int filmProductionId,FilmProductionBlank filmProduction);
    void DeleteFilmProduction(int filmProductionId);
    IEnumerable<FilmProductionDomain> GetAllFilmProduction();
}