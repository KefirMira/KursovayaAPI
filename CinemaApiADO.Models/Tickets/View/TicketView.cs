using CinemaApiADO.Models.Cinemas.Blank;
using CinemaApiADO.Models.Clients.Blank;
using CinemaApiADO.Models.PaymentsMethods.Blank;
using CinemaApiADO.Models.Sessions.Blank;
using CinemaApiADO.Models.Sessions.Domain;
using CinemaApiADO.Models.Ticket.Domain;

namespace CinemaApiADO.Models.Ticket.View;

public class TicketView
{
    public int Id { get; set; }
    public int Place { get; set; }
    public int Row { get; set; }
    public SessionBlank Session { get; set; }
    public PaymentsMethodsBlank PaymentsMethod { get; set; }
    public CinemaBlank Cinema { get; set; }
    public ClientBlank Client { get; set; }
    public ClientBlank Cashier { get; set; }
    public static TicketView Convert(TicketDomain ticketDb)
    {
        return new TicketView()
        {
            Id = ticketDb.Id,
            Place = ticketDb.Place,
            Row = ticketDb.Row,
            Session = ticketDb.Session,
            Cashier = ticketDb.Cashier,
            Cinema = ticketDb.Cinema,
            PaymentsMethod = ticketDb.PaymentsMethod,
            Client = ticketDb.Client
        };
    }

    public static IEnumerable<TicketView> Convert(IEnumerable<TicketDomain> domains)
    {
        return domains.Select(Convert);
    }
}