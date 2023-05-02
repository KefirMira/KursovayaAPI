using CinemaApiADO.Models.Sessions.DB;

namespace CinemaApiAdo.Services.Sessions;

public interface ISessionRepository
{
    bool CreateSession(SessionDB session);
    bool DeleteSession(int sessionId);
    IEnumerable<SessionDB> GetAllSession();
}