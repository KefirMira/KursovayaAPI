using CinemaApiADO.Models.Films.DB;
using CinemaApiADO.Models.Halls.Blank;
using CinemaApiADO.Models.Halls.DB;
using CinemaApiADO.Models.HallsTypes.Blank;
using CinemaApiADO.Models.Rentals.Blank;
using CinemaApiADO.Models.Rentals.DB;
using CinemaApiADO.Models.Rentals.Domain;
using CinemaApiADO.Models.Sessions.Blank;
using CinemaApiADO.Models.Sessions.DB;
using CinemaApiADO.Models.Sessions.Domain;
using CinemaApiADO.Models.SessionsTypes.Blank;
using CinemaApiADO.Models.SessionsTypes.DB;
using Npgsql;

namespace CinemaApiAdo.Services.Sessions;

public class SessionRepository:ISessionRepository
{
    private string connectionString = "Host = localhost; Database = cinemadb; User ID = postgres; Password= vjnbkmlff2004";
    private NpgsqlConnection _connection;

    public SessionRepository()
    {
        _connection = new NpgsqlConnection(connectionString);
    }
    public void CreateSession(SessionDB session)
    {
        SessionDomain newsession = SessionDomain.Convert(session,GetHall(session.Id),GetRental(session.Id),GetTypeSession(session.Id));
        HallDB thisHall = HallDB.Convert(newsession.Hall);
        RentalDB thisRental = RentalDB.Convert(newsession.Rental);
        SessionTypeDB thisSessionType = SessionTypeDB.Convert(newsession.SessionType);
        NpgsqlCommand command = new NpgsqlCommand($"insert into session(idhall, time_of_session, price, idtype_session, idrental)" +
                                                 $" values({thisHall.Id},{newsession.TimeOfSession},{newsession.Price},{thisSessionType.Id},{thisRental.Id})", _connection);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void DeleteSession(int sessionId)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand($"delete from session where id={sessionId}", _connection);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public IEnumerable<SessionDB> GetAllSession()
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand("select * from session", _connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        List<SessionDB> allsession = new List<SessionDB>();
        while (reader.Read())
        {
            // if (reader["id"] == DBNull.Value)
            // {
            //     
            // }
            // else
            // {
                allsession.Add(SessionDB.Convert(Convert.ToInt32(reader["id"]), new SessionBlank()
                {
                    Price = Convert.ToInt32(reader["price"]),
                    TimeOfSession = Convert.ToDateTime(reader["time_of_session"])
                }));
            //}
        }
        _connection.Close();
        return allsession;
    }
    public RentalBlank GetRental(int sessionId)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand($"select * from rental join session on session.idrental = rental.id where session.id = {sessionId}", _connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        RentalBlank rental= new RentalBlank();
        while (reader.Read())
        {
            rental.ShowStartDate = Convert.ToDateTime(reader["show_start_date"]);
            rental.DateOfWithDrawal = Convert.ToDateTime(reader["date_of_withdrawal"]);
        }
        _connection.Close();
        return rental;
    }
    public HallBlank GetHall(int sessionId)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand($"select * from hall join session on hall.id = session.idhall where session.id ={sessionId}", _connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        HallBlank hall= new HallBlank();
        while (reader.Read())
        {
            hall.Name = reader["name"].ToString();
            hall.NumberOfRows = Convert.ToInt32(reader["number_of_rows"]);
            hall.NumberOfSeats = Convert.ToInt32(reader["number_of_seats"]);
        }
        _connection.Close();
        return hall;
    }
    public SessionTypeBlank GetTypeSession(int sessionId)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand($"select * from session_type join session on session_type.id = session.idtype_session where session.id = {sessionId}", _connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        SessionTypeBlank sessiontype= new SessionTypeBlank();
        while (reader.Read())
        {
            sessiontype.Name = reader["name"].ToString();
        }
        _connection.Close();
        return sessiontype;
    }
}