using CinemaApiADO.Models.Sessions.Blank;
using CinemaApiADO.Models.Sessions.Domain;

namespace CinemaApiAdo.Services.Sessions;

public interface ISessionService
{
    void CreateSession(SessionBlank session);
    void DeleteSession(int sessionId);
    IEnumerable<SessionDomain> GetAllSession();
}