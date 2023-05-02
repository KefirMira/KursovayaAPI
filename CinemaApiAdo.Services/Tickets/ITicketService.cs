using CinemaApiADO.Models.Sessions.Domain;
using CinemaApiADO.Models.Ticket.Blank;
using CinemaApiADO.Models.Ticket.Domain;

namespace CinemaApiAdo.Services.Tickets;

public interface ITicketService
{
    bool CreateTicket(TicketDomain ticket);
    bool DeleteTicket(int ticketId);
    IEnumerable<TicketDomain> GetAllTicket();
    IEnumerable<TicketDomain> GetAllTicketClient(int clientId);
}