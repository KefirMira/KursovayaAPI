using CinemaApiADO.Models.Cinemas.DB;
using CinemaApiADO.Models.Cinemas.Domain;

namespace CinemaApiAdo.Services.Cinemas;

public class CinemaService : ICinemaService
{
    private readonly CinemaRepository _repository;
    
    public CinemaService()
    {
        _repository = new CinemaRepository();
    }
    public IEnumerable<CinemaDomain> GetAllCinemas()
    {
        IEnumerable<CinemaDB> allcinemas = _repository.GetAllCinemas();
        return CinemaDomain.Convert(allcinemas);
    }
}