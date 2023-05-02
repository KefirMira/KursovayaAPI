using CinemaApiADO.Models.Films.Blank;
using CinemaApiADO.Models.Films.DB;
using CinemaApiADO.Models.Films.Domain;
using CinemaApiADO.Models.Halls.Blank;
using CinemaApiADO.Models.Halls.DB;
using CinemaApiADO.Models.Halls.Domain;
using CinemaApiADO.Models.HallsTypes.Blank;
using CinemaApiADO.Models.Rentals.Blank;
using CinemaApiADO.Models.Rentals.DB;
using CinemaApiADO.Models.Rentals.Domain;
using CinemaApiADO.Models.Sessions.Blank;
using CinemaApiADO.Models.Sessions.DB;
using CinemaApiADO.Models.Sessions.Domain;
using CinemaApiADO.Models.SessionsTypes.Blank;
using CinemaApiADO.Models.SessionsTypes.DB;
using CinemaApiADO.Models.SessionsTypes.Domain;
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
    public bool CreateSession(SessionDB session)
    {
        try
        {
            SessionDomain newsession = SessionDomain.Convert(session, GetHall(session.Id), GetRental(session.Id),
                GetTypeSession(session.Id));
            // HallDB thisHall = HallDB.Convert(newsession.Hall);
            // RentalDB thisRental = RentalDB.Convert(newsession.Rental);
            // SessionTypeDB thisSessionType = SessionTypeDB.Convert(newsession.SessionType);
            NpgsqlCommand command = new NpgsqlCommand(
                $"insert into session(idhall, time_of_session, price, idtype_session, idrental)" +
                $" values({newsession.Hall.Id},{newsession.TimeOfSession},{newsession.Price},{newsession.SessionType.Id},{newsession.Rental.Id})",
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

    public bool DeleteSession(int sessionId)
    {
        try
        {
            _connection.Open();
            NpgsqlCommand command = new NpgsqlCommand($"delete from session where id={sessionId}", _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }
        catch
        {
            return false;
        }
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
    public RentalDomain GetRental(int sessionId)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand($"select * from rental join session on session.idrental = rental.id where session.id = {sessionId}", _connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        RentalBlank rental= new RentalBlank();
        int Idrental = new int();
        while (reader.Read())
        {
            Idrental = Convert.ToInt32(reader["id"]);
            rental.ShowStartDate = Convert.ToDateTime(reader["show_start_date"]);
            rental.DateOfWithDrawal = Convert.ToDateTime(reader["date_of_withdrawal"]);
        }
        _connection.Close();
        return RentalDomain.Convert(RentalDB.Convert(Idrental,rental),GetFilmToRental(Idrental));
    }
    public HallDomain GetHall(int sessionId)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand($"select * from hall join session on hall.id = session.idhall where session.id ={sessionId}", _connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        HallBlank hall= new HallBlank();
        int IdHall = new int();
        while (reader.Read())
        {
            IdHall = Convert.ToInt32(reader["id"]);
            hall.Name = reader["name"].ToString();
            hall.NumberOfRows = Convert.ToInt32(reader["number_of_rows"]);
            hall.NumberOfSeats = Convert.ToInt32(reader["number_of_seats"]);
        }
        _connection.Close();
        return HallDomain.Convert(HallDB.Convert(IdHall,hall));
    }
    public SessionTypeDomain GetTypeSession(int sessionId)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand($"select * from session_type join session on session_type.id = session.idtype_session where session.id = {sessionId}", _connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        SessionTypeBlank sessiontype= new SessionTypeBlank();
        int Idsessiontype = new int();
        while (reader.Read())
        {
            Idsessiontype = Convert.ToInt32(reader["id"]);
            sessiontype.Name = reader["name"].ToString();
        }
        _connection.Close();
        return SessionTypeDomain.Convert((SessionTypeDB.Convert(Idsessiontype,sessiontype)));
    }
    public FilmDomain GetFilmToRental(int filmId)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand($"select * from film join rental on rental.idfilm = film.id where rental.id = {filmId}", _connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        FilmBlank film= new FilmBlank();
        int Idfilm = new int();
        while (reader.Read())
        {
            //film.Id = Convert.ToInt32(reader["id"]);
            Idfilm = Convert.ToInt32(reader["id"]);
            film.Name = reader["name"].ToString();
            film.AgeRestriction = reader["age_restriction"].ToString();
            film.Country = reader["country"].ToString();
            film.Duration = Convert.ToInt32(reader["duration"]);
            film.Poster = reader["poster"].ToString();
            film.Release = Convert.ToDateTime(reader["release"]);
            film.PushkinsMap = Convert.ToBoolean(reader["pushkins_map"]);
            film.ShortDescription = reader["short_description"].ToString();
            film.TrailerLink = reader["trailer_link"].ToString();
        }
        _connection.Close();
        return FilmDomain.Convert(FilmDB.Convert(Idfilm,film));
    }
}