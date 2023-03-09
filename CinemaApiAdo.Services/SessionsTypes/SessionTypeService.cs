using CinemaApiADO.Models.SessionsTypes.DB;
using CinemaApiADO.Models.SessionsTypes.Domain;

namespace CinemaApiAdo.Services.SessionsTypes;

public class SessionTypeService: ISessionTypeService
{
    private readonly SessionTypeRepository _repository;
    public SessionTypeService()
    {
        _repository = new SessionTypeRepository();
    }
    public IEnumerable<SessionTypeDomain> GetAllSessionType()
    {
        IEnumerable<SessionTypeDB> allcinemas = _repository.GetAllSessionType();
        return SessionTypeDomain.Convert(allcinemas);
    }
}