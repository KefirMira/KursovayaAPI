using CinemaApiADO.Models.Cinemas.Blank;
using CinemaApiADO.Models.Cinemas.DB;
using CinemaApiADO.Models.Cinemas.Domain;
using CinemaApiADO.Models.Clients.Blank;
using CinemaApiADO.Models.Clients.DB;
using CinemaApiADO.Models.Clients.Domain;
using CinemaApiADO.Models.Halls.DB;
using CinemaApiADO.Models.PaymentsMethods.Blank;
using CinemaApiADO.Models.PaymentsMethods.DB;
using CinemaApiADO.Models.PaymentsMethods.Domain;
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
    public bool CreateTicket(TicketDomain ticket)
    {
        try
        {
            //TicketDomain newticket = TicketDomain.Convert(ticket,GetSession(ticket.Id),
            //GetPaymethod(ticket.Id),GetCinema(ticket.Id),GetClient(ticket.Id),GetCashier(ticket.Id));
            //SessionDB thisSession = SessionDB.Convert(newticket.Session);
            //PaymentsMethodsDB thisPayment = PaymentsMethodsDB.Convert(newticket.PaymentsMethod);
            //CinemaDB thisCinema = CinemaDB.Convert(newticket.Cinema);
            //ClientDB thisClient = ClientDB.Convert(newticket.Client);
            //ClientDB thisCashier = ClientDB.Convert(newticket.Cashier);
            NpgsqlCommand command = new NpgsqlCommand(
                $"insert into ticket( place, row, idsession, idpaymethod, idcinema, idclient, idcashier)" +
                $" values ({ticket.Place},{ticket.Row},{ticket.IdSession},{ticket.IdPayMet},{ticket.IdCinema},{ticket.IdClient},{ticket.IdCasher})",
                _connection);
            command.ExecuteNonQuery();
            _connection.Close();
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
            _connection.Open();
            NpgsqlCommand command = new NpgsqlCommand($"delete from ticket where id={ticketId}", _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }
        catch
        {
            return false;
        }
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
                Row = Convert.ToInt32(reader["row"]),
                DateOfTicket = Convert.ToDateTime(reader["date_of_ticket"])
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
                Row = Convert.ToInt32(reader["row"]),
                DateOfTicket = Convert.ToDateTime(reader["date_of_ticket"])
            }));
        }
        _connection.Close();
        return allticketsclient;
    }
    
    public SessionDomain GetSession(int ticketId)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand($"select * from session join ticket on ticket.idsession = session.id where ticket.id={ticketId}", _connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        SessionBlank session= new SessionBlank();
        int IdSession = new int();
        while (reader.Read())
        {
            IdSession = Convert.ToInt32(reader["id"]);
            session.Price = Convert.ToInt32(reader["price"]);
            session.TimeOfSession = Convert.ToDateTime(reader["time_of_session"]);
        }
        _connection.Close();
        return SessionDomain.Convert(SessionDB.Convert(IdSession,session));
    }
    public PaymentsMethodsDomain GetPaymethod(int ticketId)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand($"select * from payment_method join ticket on ticket.idpaymethod = payment_method.id where ticket.id={ticketId}", _connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        PaymentsMethodsBlank payments= new PaymentsMethodsBlank();
        int IdPayMeth = new int();
        while (reader.Read())
        {
            IdPayMeth = Convert.ToInt32(reader["id"]);
            payments.Name = reader["name"].ToString();
        }
        _connection.Close();
        return PaymentsMethodsDomain.Convert(PaymentsMethodsDB.Convert(IdPayMeth,payments));
    }
    public CinemaDomain GetCinema(int ticketId)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand($"select * from cinema join ticket on ticket.idcinema = cinema.id where ticket.id={ticketId}", _connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        CinemaBlank cinema= new CinemaBlank();
        int IdCinema = new int();
        while (reader.Read())
        {
            IdCinema = Convert.ToInt32(reader["id"]);
            cinema.Name = reader["name"].ToString();
        }
        _connection.Close();
        return CinemaDomain.Convert(CinemaDB.Convert(IdCinema,cinema));
    }
    public ClientDomain GetClient(int ticketId)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand($"select * from client join ticket on client.id = ticket.idclient where ticket.id = {ticketId}", _connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        ClientBlank client = new ClientBlank();
        int IdClient = new int();
        while (reader.Read())
        {
            IdClient = Convert.ToInt32(reader["id"]);
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
        return ClientDomain.Convert(ClientDB.Convert(IdClient,client));
    }
    public ClientDomain GetCashier(int ticketId)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand($"select * from client join ticket on client.id = ticket.idcashier where ticket.id = {ticketId}", _connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        ClientBlank client = new ClientBlank();
        int IdCashier = new int();
        while (reader.Read())
        {
            IdCashier = Convert.ToInt32(reader["id"]);
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
        return ClientDomain.Convert(ClientDB.Convert(IdCashier,client));
    }
}