using CinemaApiADO.Models.Sessions.DB;

namespace CinemaApiAdo.Services.Sessions;

public interface ISessionRepository
{
    void CreateSession(SessionDB session);
    void DeleteSession(int sessionId);
    IEnumerable<SessionDB> GetAllSession();
}