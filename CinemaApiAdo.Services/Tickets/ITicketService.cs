using CinemaApiADO.Models.Sessions.Domain;
using CinemaApiADO.Models.Ticket.Blank;
using CinemaApiADO.Models.Ticket.Domain;

namespace CinemaApiAdo.Services.Tickets;

public interface ITicketService
{
    void CreateTicket(TicketBlank ticket);
    void DeleteTicket(int ticketId);
    IEnumerable<TicketDomain> GetAllTicket();
    IEnumerable<TicketDomain> GetAllTicketClient(int clientId);
}