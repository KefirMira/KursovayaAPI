using CinemaApiADO.Models.Ticket.Blank;

namespace CinemaApiADO.Models.Ticket.DB;

public class TicketDB
{
    public int Id { get; set; }
    public int Place { get; set; }
    public int Row { get; set; }
    public DateTime DateOfTicket { get; set; }
    public static TicketDB Convert(TicketBlank sessionBlank)
    {
        return new TicketDB()
        {
            Place = sessionBlank.Place,
            Row = sessionBlank.Row,
            DateOfTicket = sessionBlank.DateOfTicket
        };
    }
    public static TicketDB Convert(int sessionId,TicketBlank sessionBlank)
    {
        return new TicketDB()
        {
            Id = sessionId,
            Place = sessionBlank.Place,
            Row = sessionBlank.Row,
            DateOfTicket = sessionBlank.DateOfTicket
        };
    }
}