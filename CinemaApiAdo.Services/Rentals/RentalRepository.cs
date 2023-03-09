using CinemaApiADO.Models.Films.Blank;
using CinemaApiADO.Models.Films.DB;
using CinemaApiADO.Models.Halls.Blank;
using CinemaApiADO.Models.Halls.DB;
using CinemaApiADO.Models.Halls.Domain;
using CinemaApiADO.Models.HallsTypes.Blank;
using CinemaApiADO.Models.HallsTypes.DB;
using CinemaApiADO.Models.Rentals.Blank;
using CinemaApiADO.Models.Rentals.DB;
using CinemaApiADO.Models.Rentals.Domain;
using Npgsql;

namespace CinemaApiAdo.Services.Rentals;

public class RentalRepository: IRentalRepository
{
    private string connectionString = "Host = localhost; Database = cinemadb; User ID = postgres; Password= vjnbkmlff2004";
    private NpgsqlConnection _connection;

    public RentalRepository()
    {
        _connection = new NpgsqlConnection(connectionString);
    }
    public void CreateRental(RentalDB rental)
    {
        RentalDomain newrental = RentalDomain.Convert(rental,GetFilm(rental.Id));
        FilmDB thisHalltype = FilmDB.Convert(newrental.Films);
        NpgsqlCommand command = new NpgsqlCommand($"insert into rental(show_start_date, date_of_withdrawal, idfilm)" +
                                                  $" values ('{newrental.ShowStartDate}','{newrental.DateOfWithDrawal}','{thisHalltype.Id}')", _connection);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void DeleteRental(int rentalId)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand($"delete from rental where id={rentalId}", _connection);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public IEnumerable<RentalDB> GetAllRental()
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand("select * from rental", _connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        List<RentalDB> allrentals = new List<RentalDB>();
        while (reader.Read())
        {
            allrentals.Add(RentalDB.Convert(Convert.ToInt32(reader["id"]), new RentalBlank()
            {
                ShowStartDate = Convert.ToDateTime(reader["show_start_date"]),
                DateOfWithDrawal = Convert.ToDateTime(reader["date_of_withdrawal"])
            }));
        }
        _connection.Close();
        return allrentals;
    }
    
    public FilmBlank GetFilm(int rentalId)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand($"select * from film join rental on rental.idfilm = film.id where rental.id = {rentalId}", _connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        FilmBlank film= new FilmBlank();
        while (reader.Read())
        {
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
        return film;
    }
}