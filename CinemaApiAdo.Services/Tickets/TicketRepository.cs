using CinemaApiADO.Models.Cinemas.Blank;
using CinemaApiADO.Models.Cinemas.DB;
using CinemaApiADO.Models.Clients.Blank;
using CinemaApiADO.Models.Clients.DB;
using CinemaApiADO.Models.Halls.DB;
using CinemaApiADO.Models.PaymentsMethods.Blank;
using CinemaApiADO.Models.PaymentsMethods.DB;
using CinemaApiADO.Models.Rentals.Blank;
using CinemaApiADO.Models.Rentals.DB;
using CinemaApiADO.Models.Sessions.Blank;
using CinemaApiADO.Models.Sessions.DB;
using CinemaApiADO.Models.Sessions.Domain;
using CinemaApiADO.Models.SessionsTypes.DB;
using CinemaApiADO.Models.Ticket.Blank;
using CinemaApiADO.Models.Ticket.DB;
using CinemaApiADO.Models.Ticket.Domain;
using Npgsql;

namespace CinemaApiAdo.Services.Tickets;

public class TicketRepository: ITicketRepository
{
    private string connectionString = "Host = localhost; Database = cinemadb; User ID = postgres; Password= vjnbkmlff2004";
    private NpgsqlConnection _connection;

    public TicketRepository()
    {
        _connection = new NpgsqlConnection(connectionString);
    }
    public void CreateTicket(TicketDB ticket)
    {
        TicketDomain newticket = TicketDomain.Convert(ticket,GetSession(ticket.Id),
            GetPaymethod(ticket.Id),GetCinema(ticket.Id),GetClient(ticket.Id),GetCashier(ticket.Id));
        SessionDB thisSession = SessionDB.Convert(newticket.Session);
        PaymentsMethodsDB thisPayment = PaymentsMethodsDB.Convert(newticket.PaymentsMethod);
        CinemaDB thisCinema = CinemaDB.Convert(newticket.Cinema);
        ClientDB thisClient = ClientDB.Convert(newticket.Client);
        ClientDB thisCashier = ClientDB.Convert(newticket.Cashier);
        NpgsqlCommand command = new NpgsqlCommand($"insert into ticket( place, row, idsession, idpaymethod, idcinema, idclient, idcashier)" +
                                                  $" values ({newticket.Place},{newticket.Row},{thisSession.Id},{thisPayment.Id},{thisCinema.Id},{thisClient.Id},{thisCashier.Id})", _connection);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void DeleteTicket(int ticketId)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand($"delete from ticket where id={ticketId}", _connection);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public IEnumerable<TicketDB> GetAllTicket()
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand("select * from ticket", _connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        List<TicketDB> allticket = new List<TicketDB>();
        while (reader.Read())
        {
            allticket.Add(TicketDB.Convert(Convert.ToInt32(reader["id"]), new TicketBlank()
            {
                Place = Convert.ToInt32(reader["place"]),
                Row = Convert.ToInt32(reader["row"])
            }));
        }
        _connection.Close();
        return allticket;
    }

    public IEnumerable<TicketDB> GetAllTicketClient(int clientId)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand($"select * from ticket where idclient = {clientId}", _connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        List<TicketDB> allticketsclient = new List<TicketDB>();
        while (reader.Read())
        {
            allticketsclient.Add(TicketDB.Convert(Convert.ToInt32(reader["id"]), new TicketBlank()
            {
                Place = Convert.ToInt32(reader["place"]),
                Row = Convert.ToInt32(reader["row"])
            }));
        }
        _connection.Close();
        return allticketsclient;
    }
    
    public SessionBlank GetSession(int ticketId)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand($"select * from session join ticket on ticket.idsession = session.id where ticket.id={ticketId}", _connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        SessionBlank session= new SessionBlank();
        while (reader.Read())
        {
            session.Price = Convert.ToInt32(reader["price"]);
            session.TimeOfSession = Convert.ToDateTime(reader["time_of_session"]);
        }
        _connection.Close();
        return session;
    }
    public PaymentsMethodsBlank GetPaymethod(int ticketId)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand($"select * from payment_method join ticket on ticket.idpaymethod = payment_method.id where ticket.id={ticketId}", _connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        PaymentsMethodsBlank payments= new PaymentsMethodsBlank();
        while (reader.Read())
        {
            payments.Name = reader["name"].ToString();
        }
        _connection.Close();
        return payments;
    }
    public CinemaBlank GetCinema(int ticketId)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand($"select * from cinema join ticket on ticket.idcinema = cinema.id where ticket.id={ticketId}", _connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        CinemaBlank cinema= new CinemaBlank();
        while (reader.Read())
        {
            cinema.Name = reader["name"].ToString();
        }
        _connection.Close();
        return cinema;
    }
    public ClientBlank GetClient(int ticketId)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand("select * from client join ticket on client.id = ticket.idclient where ticket.id = {}", _connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        ClientBlank client = new ClientBlank();
        while (reader.Read())
        {
            client.Name = reader["name"].ToString();
            client.Surname = reader["surname"].ToString();
            client.Patronymic = reader["patronymic"].ToString();
            client.Login = reader["login"].ToString();
            client.Password = reader["password"].ToString();
            client.Mail = reader["mail"].ToString();
            client.Telephone = reader["telephone"].ToString();
            client.Discount = Convert.ToInt32(reader["discount"]);
        }
        _connection.Close();
        return client;
    }
    public ClientBlank GetCashier(int ticketId)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand("select * from client join ticket on client.id = ticket.idcashier where ticket.id = {}", _connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        ClientBlank client = new ClientBlank();
        while (reader.Read())
        {
            client.Name = reader["name"].ToString();
            client.Surname = reader["surname"].ToString();
            client.Patronymic = reader["patronymic"].ToString();
            client.Login = reader["login"].ToString();
            client.Password = reader["password"].ToString();
            client.Mail = reader["mail"].ToString();
            client.Telephone = reader["telephone"].ToString();
            client.Discount = Convert.ToInt32(reader["discount"]);
        }
        _connection.Close();
        return client;
    }
}