using CinemaApiADO.Models.Cinemas.Domain;

namespace CinemaApiAdo.Services.Cinemas;

public interface ICinemaService
{
    IEnumerable<CinemaDomain> GetAllCinemas();
}