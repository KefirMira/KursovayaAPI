using CinemaApiADO.Models.Ticket.DB;
using CinemaApiADO.Models.Ticket.Domain;

namespace CinemaApiAdo.Services.Tickets;

public interface ITicketRepository
{
    bool CreateTicket(TicketDomain ticket);
    bool DeleteTicket(int ticketId);
    IEnumerable<TicketDB> GetAllTicket();
    IEnumerable<TicketDB> GetAllTicketClient(int clientId);
}