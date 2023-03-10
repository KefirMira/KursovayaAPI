using System.Data.SqlTypes;
using CinemaApiADO.Models.Halls.Blank;
using CinemaApiADO.Models.Halls.Domain;
using CinemaApiADO.Models.Rentals.Blank;
using CinemaApiADO.Models.Sessions.Domain;
using CinemaApiADO.Models.SessionsTypes.Blank;

namespace CinemaApiADO.Models.Sessions.View;

public class SessionView
{
    public int Id { get; set; }
    public DateTime TimeOfSession { get; set; }
    public int Price { get; set; }
    public SessionTypeBlank SessionType { get; set; }
    public RentalBlank Rental { get; set; }
    public HallBlank Hall { get; set; }
    public static SessionView Convert(SessionDomain sessionDomain)
    {
        return new SessionView()
        {
            Id = sessionDomain.Id,
            TimeOfSession = sessionDomain.TimeOfSession,
            Price = sessionDomain.Price,
            Hall = sessionDomain.Hall,
            SessionType = sessionDomain.SessionType,
            Rental = sessionDomain.Rental
        };
    }

    public static IEnumerable<SessionView> Convert(IEnumerable<SessionDomain> domains)
    {
        return domains.Select(Convert);
    }
}