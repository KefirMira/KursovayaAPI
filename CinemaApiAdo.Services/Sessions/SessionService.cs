using CinemaApiADO.Models.Films.Blank;
using CinemaApiADO.Models.Halls.Blank;
using CinemaApiADO.Models.Rentals.Blank;
using CinemaApiADO.Models.Rentals.DB;
using CinemaApiADO.Models.Rentals.Domain;
using CinemaApiADO.Models.Sessions.Blank;
using CinemaApiADO.Models.Sessions.DB;
using CinemaApiADO.Models.Sessions.Domain;
using CinemaApiADO.Models.SessionsTypes.Blank;

namespace CinemaApiAdo.Services.Sessions;

public class SessionService:ISessionService
{
    private readonly SessionRepository _repository;

    public SessionService()
    {
        _repository = new SessionRepository();
    }
    public void CreateSession(SessionBlank session)
    {
        SessionDB newsession = SessionDB.Convert(session);
        _repository.CreateSession(newsession);
    }

    public void DeleteSession(int sessionId)
    {
        _repository.DeleteSession(sessionId);
    }

    public IEnumerable<SessionDomain> GetAllSession()
    {
        IEnumerable<SessionDB> allrental = _repository.GetAllSession();
        List<SessionDomain> allinforental = new List<SessionDomain>();
        foreach (var item in allrental)
        {
            HallBlank hall = _repository.GetHall(item.Id);
            SessionTypeBlank sessiontype = _repository.GetTypeSession(item.Id);
            RentalBlank rental = _repository.GetRental(item.Id);
            allinforental.Add(SessionDomain.Convert(item,hall,rental,sessiontype));
        }
        return allinforental;
    }
}