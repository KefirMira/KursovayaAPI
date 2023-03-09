using System.Data.SqlTypes;
using CinemaApiADO.Models.Sessions.Blank;

namespace CinemaApiADO.Models.Sessions.DB;

public class SessionDB
{
    public int Id { get; set; }
    public DateTime TimeOfSession { get; set; }
    public int Price { get; set; }
    public static SessionDB Convert(SessionBlank sessionBlank)
    {
        return new SessionDB()
        {
            TimeOfSession = sessionBlank.TimeOfSession,
            Price = sessionBlank.Price
        };
    }
    public static SessionDB Convert(int sessionId,SessionBlank sessionBlank)
    {
        return new SessionDB()
        {
            Id = sessionId,
            TimeOfSession = sessionBlank.TimeOfSession,
            Price = sessionBlank.Price
        };
    }
}