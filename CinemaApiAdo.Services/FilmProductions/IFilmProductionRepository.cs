using CinemaApiADO.Models.FilmProductions.DB;

namespace CinemaApiAdo.Services.FilmProductions;

public interface IFilmProductionRepository
{
    void CreateFilmProduction(FilmProductionDB filmProductionBlank);
    void UpdateFilmProduction(int filmProductionId,FilmProductionDB filmProduction);
    void DeleteFilmProduction(int filmProductionId);
    IEnumerable<FilmProductionDB> GetAllFilmProduction();
}