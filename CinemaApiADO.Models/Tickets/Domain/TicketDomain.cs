using CinemaApiADO.Models.Cinemas.Blank;
using CinemaApiADO.Models.Clients.Blank;
using CinemaApiADO.Models.Halls.Blank;
using CinemaApiADO.Models.PaymentsMethods.Blank;
using CinemaApiADO.Models.Rentals.Blank;
using CinemaApiADO.Models.Sessions.Blank;
using CinemaApiADO.Models.Sessions.DB;
using CinemaApiADO.Models.SessionsTypes.Blank;
using CinemaApiADO.Models.Ticket.DB;

namespace CinemaApiADO.Models.Ticket.Domain;

public class TicketDomain
{
    public int Id { get; set; }
    public int Place { get; set; }
    public int Row { get; set; }
    public SessionBlank Session { get; set; }
    public PaymentsMethodsBlank PaymentsMethod { get; set; }
    public CinemaBlank Cinema { get; set; }
    public ClientBlank Client { get; set; }
    public ClientBlank Cashier { get; set; }
    public static TicketDomain Convert(TicketDB ticketDb)
    {
        return new TicketDomain()
        {
            Id = ticketDb.Id,
            Place = ticketDb.Place,
            Row = ticketDb.Row
        };
    }
    public static TicketDomain Convert(TicketDB ticketDb, SessionBlank sessionBlank, PaymentsMethodsBlank paymentsMethodsBlank, CinemaBlank cinemaBlank, ClientBlank client, ClientBlank cashier)
    {
        return new TicketDomain()
        {
            Id = ticketDb.Id,
            Place = ticketDb.Place,
            Row = ticketDb.Row,
            Session = sessionBlank,
            Cashier = cashier,
            Cinema = cinemaBlank,
            PaymentsMethod = paymentsMethodsBlank,
            Client = client
        };
    }

    public static IEnumerable<TicketDomain> Convert(IEnumerable<TicketDB> dbs)
    {
        return dbs.Select(Convert);
    }
}