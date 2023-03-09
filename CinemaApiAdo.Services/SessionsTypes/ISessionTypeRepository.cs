using CinemaApiADO.Models.SessionsTypes.DB;

namespace CinemaApiAdo.Services.SessionsTypes;

public interface ISessionTypeRepository
{
    IEnumerable<SessionTypeDB> GetAllSessionType();
}