using CinemaApiADO.Models.Films.Blank;
using CinemaApiADO.Models.Halls.Blank;
using CinemaApiADO.Models.Halls.Domain;
using CinemaApiADO.Models.Rentals.Blank;
using CinemaApiADO.Models.Rentals.DB;
using CinemaApiADO.Models.Rentals.Domain;
using CinemaApiADO.Models.Sessions.Blank;
using CinemaApiADO.Models.Sessions.DB;
using CinemaApiADO.Models.Sessions.Domain;
using CinemaApiADO.Models.SessionsTypes.Blank;
using CinemaApiADO.Models.SessionsTypes.Domain;

namespace CinemaApiAdo.Services.Sessions;

public class SessionService:ISessionService
{
    private readonly SessionRepository _repository;

    public SessionService()
    {
        _repository = new SessionRepository();
    }
    public bool CreateSession(SessionBlank session)
    {
        try
        {
            SessionDB newsession = SessionDB.Convert(session);
            _repository.CreateSession(newsession);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool DeleteSession(int sessionId)
    {
        try
        {
            _repository.DeleteSession(sessionId);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public IEnumerable<SessionDomain> GetAllSession()
    {
        IEnumerable<SessionDB> allrental = _repository.GetAllSession();
        List<SessionDomain> allinforental = new List<SessionDomain>();
        foreach (var item in allrental)
        {
            HallDomain hall = _repository.GetHall(item.Id);
            SessionTypeDomain sessiontype = _repository.GetTypeSession(item.Id);
            RentalDomain rental = _repository.GetRental(item.Id);
            allinforental.Add(SessionDomain.Convert(item,hall,rental,sessiontype));
        }
        return allinforental;
    }
}