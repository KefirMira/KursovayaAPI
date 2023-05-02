using CinemaApiADO.Models.Cinemas.Blank;
using CinemaApiADO.Models.Cinemas.Domain;
using CinemaApiADO.Models.Clients.Blank;
using CinemaApiADO.Models.Clients.Domain;
using CinemaApiADO.Models.Halls.Blank;
using CinemaApiADO.Models.PaymentsMethods.Blank;
using CinemaApiADO.Models.PaymentsMethods.Domain;
using CinemaApiADO.Models.Rentals.Blank;
using CinemaApiADO.Models.Sessions.Blank;
using CinemaApiADO.Models.Sessions.DB;
using CinemaApiADO.Models.Sessions.Domain;
using CinemaApiADO.Models.SessionsTypes.Blank;
using CinemaApiADO.Models.Ticket.DB;

namespace CinemaApiADO.Models.Ticket.Domain;

public class TicketDomain
{
    public int Id { get; set; }
    public int Place { get; set; }
    public int Row { get; set; }
    public DateTime DateOfTicket { get; set; }
    public SessionDomain? Session { get; set; }
    public int IdSession { get; set; }
    public PaymentsMethodsDomain? PaymentsMethod { get; set; }
    public int IdPayMet { get; set; }
    public CinemaDomain? Cinema { get; set; }
    public int IdCinema { get; set; }
    public ClientDomain? Client { get; set; }
    public int IdClient { get; set; }
    public ClientDomain? Cashier { get; set; }
    public int IdCasher { get; set; }
    public static TicketDomain Convert(TicketDB ticketDb)
    {
        return new TicketDomain()
        {
            Id = ticketDb.Id,
            Place = ticketDb.Place,
            Row = ticketDb.Row,
            DateOfTicket = ticketDb.DateOfTicket
        };
    }
    public static TicketDomain Convert(TicketDB ticketDb, SessionDomain sessionBlank, PaymentsMethodsDomain paymentsMethodsBlank, CinemaDomain cinemaBlank, ClientDomain client, ClientDomain cashier)
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
            Client = client,
            DateOfTicket = ticketDb.DateOfTicket
        };
    }

    public static IEnumerable<TicketDomain> Convert(IEnumerable<TicketDB> dbs)
    {
        return dbs.Select(Convert);
    }
}