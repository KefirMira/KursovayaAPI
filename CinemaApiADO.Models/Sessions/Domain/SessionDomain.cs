using System.Data.SqlTypes;
using CinemaApiADO.Models.Halls.Blank;
using CinemaApiADO.Models.Rentals.Blank;
using CinemaApiADO.Models.Sessions.DB;
using CinemaApiADO.Models.SessionsTypes.Blank;

namespace CinemaApiADO.Models.Sessions.Domain;

public class SessionDomain
{
    public int Id { get; set; }
    public DateTime TimeOfSession { get; set; }
    public int Price { get; set; }
    public SessionTypeBlank SessionType { get; set; }
    public RentalBlank Rental { get; set; }
    public HallBlank Hall { get; set; }
    public static SessionDomain Convert(SessionDB sessionDb)
    {
        return new SessionDomain()
        {
            Id = sessionDb.Id,
            TimeOfSession = sessionDb.TimeOfSession,
            Price = sessionDb.Price
        };
    }
    public static SessionDomain Convert(SessionDB sessionDb, HallBlank hallBlanks, RentalBlank rentalBlank, SessionTypeBlank sessionTypeBlank)
    {
        return new SessionDomain()
        {
            Id = sessionDb.Id,
            TimeOfSession = sessionDb.TimeOfSession,
            Price = sessionDb.Price,
            Hall = hallBlanks,
            SessionType = sessionTypeBlank,
            Rental = rentalBlank
        };
    }

    public static IEnumerable<SessionDomain> Convert(IEnumerable<SessionDB> dbs)
    {
        return dbs.Select(Convert);
    }
}