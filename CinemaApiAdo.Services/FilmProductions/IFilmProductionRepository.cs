using CinemaApiADO.Models.FilmProductions.DB;

namespace CinemaApiAdo.Services.FilmProductions;

public interface IFilmProductionRepository
{
    bool CreateFilmProduction(FilmProductionDB filmProductionBlank);
    bool UpdateFilmProduction(int filmProductionId,FilmProductionDB filmProduction);
    bool DeleteFilmProduction(int filmProductionId);
    IEnumerable<FilmProductionDB> GetAllFilmProduction();
}