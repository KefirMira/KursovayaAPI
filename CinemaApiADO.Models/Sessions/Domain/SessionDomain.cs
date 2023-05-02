using System.Data.SqlTypes;
using CinemaApiADO.Models.Halls.Blank;
using CinemaApiADO.Models.Halls.Domain;
using CinemaApiADO.Models.Rentals.Blank;
using CinemaApiADO.Models.Rentals.Domain;
using CinemaApiADO.Models.Sessions.DB;
using CinemaApiADO.Models.SessionsTypes.Blank;
using CinemaApiADO.Models.SessionsTypes.Domain;

namespace CinemaApiADO.Models.Sessions.Domain;

public class SessionDomain
{
    public int Id { get; set; }
    public DateTime TimeOfSession { get; set; }
    public int Price { get; set; }
    public SessionTypeDomain SessionType { get; set; }
    public RentalDomain Rental { get; set; }
    public HallDomain Hall { get; set; }
    public static SessionDomain Convert(SessionDB sessionDb)
    {
        return new SessionDomain()
        {
            Id = sessionDb.Id,
            TimeOfSession = sessionDb.TimeOfSession,
            Price = sessionDb.Price
        };
    }
    public static SessionDomain Convert(SessionDB sessionDb, HallDomain hallDomains, RentalDomain rentalDomain, SessionTypeDomain sessionTypeDomain)
    {
        return new SessionDomain()
        {
            Id = sessionDb.Id,
            TimeOfSession = sessionDb.TimeOfSession,
            Price = sessionDb.Price,
            Hall = hallDomains,
            SessionType = sessionTypeDomain,
            Rental = rentalDomain
        };
    }

    public static IEnumerable<SessionDomain> Convert(IEnumerable<SessionDB> dbs)
    {
        return dbs.Select(Convert);
    }
}