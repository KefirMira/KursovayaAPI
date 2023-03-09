using CinemaApiADO.Models.Ticket.DB;

namespace CinemaApiAdo.Services.Tickets;

public interface ITicketRepository
{
    void CreateTicket(TicketDB ticket);
    void DeleteTicket(int ticketId);
    IEnumerable<TicketDB> GetAllTicket();
    IEnumerable<TicketDB> GetAllTicketClient(int clientId);
}