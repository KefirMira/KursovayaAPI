using System.Data.SqlTypes;

namespace CinemaApiADO.Models.Sessions.Blank;

public class SessionBlank
{
    public DateTime TimeOfSession { get; set; }
    public int Price { get; set; }
}