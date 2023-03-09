using CinemaApiADO.Models.SessionsTypes.DB;
using CinemaApiADO.Models.SessionsTypes.Domain;

namespace CinemaApiAdo.Services.SessionsTypes;

public interface ISessionTypeService
{
    IEnumerable<SessionTypeDomain> GetAllSessionType();   
}