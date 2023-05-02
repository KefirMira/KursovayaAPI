using CinemaApiADO.Models.Cinemas.Blank;
using CinemaApiADO.Models.Cinemas.Domain;
using CinemaApiADO.Models.Clients.Blank;
using CinemaApiADO.Models.Clients.Domain;
using CinemaApiADO.Models.Films.Blank;
using CinemaApiADO.Models.PaymentsMethods.Blank;
using CinemaApiADO.Models.PaymentsMethods.Domain;
using CinemaApiADO.Models.Rentals.DB;
using CinemaApiADO.Models.Rentals.Domain;
using CinemaApiADO.Models.Sessions.Blank;
using CinemaApiADO.Models.Sessions.Domain;
using CinemaApiADO.Models.Ticket.Blank;
using CinemaApiADO.Models.Ticket.DB;
using CinemaApiADO.Models.Ticket.Domain;

namespace CinemaApiAdo.Services.Tickets;

public class TicketService:ITicketService
{
    private readonly TicketRepository _repository;

    public TicketService()
    {
        _repository = new TicketRepository();
    }
    public bool CreateTicket(TicketDomain ticket)
    {
        try
        {
            //TicketDB newticket = TicketDB.Convert(ticket);
            _repository.CreateTicket(ticket);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool DeleteTicket(int ticketId)
    {
        try
        {
        _repository.DeleteTicket(ticketId);
        return true;
        }
        catch
        {
            return false;
        }
    }

    public IEnumerable<TicketDomain> GetAllTicket()
    {
        IEnumerable<TicketDB> allticket = _repository.GetAllTicket();
        List<TicketDomain> allinfoticket = new List<TicketDomain>();
        foreach (var item in allticket)
        {
            CinemaDomain cinema = _repository.GetCinema(item.Id);
            PaymentsMethodsDomain payments = _repository.GetPaymethod(item.Id);
            SessionDomain session = _repository.GetSession(item.Id);
            ClientDomain cashier = _repository.GetCashier(item.Id);
            ClientDomain client = _repository.GetClient(item.Id);
            allinfoticket.Add(TicketDomain.Convert(item, session,payments,cinema,client,cashier));
        }
        return allinfoticket;
    }

    public IEnumerable<TicketDomain> GetAllTicketClient(int clientId)
    {
        IEnumerable<TicketDB> allticket = _repository.GetAllTicketClient(clientId);
        List<TicketDomain> allinfoticket = new List<TicketDomain>();
        foreach (var item in allticket)
        {
            CinemaDomain cinema = _repository.GetCinema(item.Id);
            PaymentsMethodsDomain payments = _repository.GetPaymethod(item.Id);
            SessionDomain session = _repository.GetSession(item.Id);
            ClientDomain cashier = _repository.GetCashier(item.Id);
            ClientDomain client = _repository.GetClient(item.Id);
            allinfoticket.Add(TicketDomain.Convert(item, session,payments,cinema,client,cashier));
        }
        return allinfoticket;
    }
}