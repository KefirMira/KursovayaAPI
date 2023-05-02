using CinemaApiADO.Models.Cinemas.Blank;
using CinemaApiADO.Models.Cinemas.Domain;
using CinemaApiADO.Models.Clients.Blank;
using CinemaApiADO.Models.Clients.Domain;
using CinemaApiADO.Models.PaymentsMethods.Blank;
using CinemaApiADO.Models.PaymentsMethods.Domain;
using CinemaApiADO.Models.Sessions.Blank;
using CinemaApiADO.Models.Sessions.Domain;
using CinemaApiADO.Models.Ticket.Domain;

namespace CinemaApiADO.Models.Ticket.View;

public class TicketView
{
    public int Id { get; set; }
    public int Place { get; set; }
    public int Row { get; set; }
    private DateTime DateOfTicket { get; set; }
    public SessionDomain Session { get; set; }
    public PaymentsMethodsDomain PaymentsMethod { get; set; }
    public CinemaDomain Cinema { get; set; }
    public ClientDomain Client { get; set; }
    public ClientDomain Cashier { get; set; }
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
            Client = ticketDb.Client,
            DateOfTicket = ticketDb.DateOfTicket
        };
    }

    public static IEnumerable<TicketView> Convert(IEnumerable<TicketDomain> domains)
    {
        return domains.Select(Convert);
    }
}