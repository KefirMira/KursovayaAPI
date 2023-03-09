using CinemaApiADO.Models.Cinemas.DB;

namespace CinemaApiAdo.Services.Cinemas;

public interface ICinemaRepository
{
    IEnumerable<CinemaDB> GetAllCinemas();
}