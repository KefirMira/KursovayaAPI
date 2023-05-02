using CinemaApiADO.Models.FilmProductions.Blank;
using CinemaApiADO.Models.FilmProductions.Domain;

namespace CinemaApiAdo.Services.FilmProductions;

public interface IFilmProductionService
{
    bool CreateFilmProduction(FilmProductionBlank filmProductionBlank);
    bool UpdateFilmProduction(int filmProductionId,FilmProductionBlank filmProduction);
    bool DeleteFilmProduction(int filmProductionId);
    IEnumerable<FilmProductionDomain> GetAllFilmProduction();
}