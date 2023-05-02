using CinemaApiADO.Models.Sessions.Blank;
using CinemaApiADO.Models.Sessions.Domain;

namespace CinemaApiAdo.Services.Sessions;

public interface ISessionService
{
    bool CreateSession(SessionBlank session);
    bool DeleteSession(int sessionId);
    IEnumerable<SessionDomain> GetAllSession();
}