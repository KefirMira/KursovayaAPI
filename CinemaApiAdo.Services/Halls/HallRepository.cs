using CinemaApiADO.Models.Halls.Blank;
using CinemaApiADO.Models.Halls.DB;
using CinemaApiADO.Models.Halls.Domain;
using CinemaApiADO.Models.HallsTypes.Blank;
using CinemaApiADO.Models.HallsTypes.DB;
using CinemaApiADO.Models.HallsTypes.Domain;
using Npgsql;

namespace CinemaApiAdo.Services.Halls;

public class HallRepository: IHallRepository
{
    private string connectionString = "Host = localhost; Database = cinemadb; User ID = postgres; Password= vjnbkmlff2004";
    private NpgsqlConnection _connection;

    public HallRepository()
    {
        _connection = new NpgsqlConnection(connectionString);
    }
    public bool CreateHall(HallDB hall)
    {
        try
        {
            _connection.Open();
            HallDomain newhall = HallDomain.Convert(hall, GetHallTypeFilm(hall.Id));
            // HallTypeDB thisHalltype = HallTypeDB.Convert(newhall.HallType);
            NpgsqlCommand command = new NpgsqlCommand(
                $"insert into hall(idhall_type, name, number_of_seats, number_of_rows)" +
                $" values ('{newhall.HallType.Id}','{newhall.Name}',{newhall.NumberOfSeats},{newhall.NumberOfRows})",
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
    public HallTypeDomain GetHallTypeFilm(int hallId)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand($"select * from hall_type join hall  on hall_type.id = hall.idhall_type where hall.id={hallId}", _connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        HallTypeBlank halltype= new HallTypeBlank();
        int IdHallType = new int();
        while (reader.Read())
        {
            IdHallType = Convert.ToInt32(reader["id"]);
            halltype.Name = reader["name"].ToString();
        }
        _connection.Close();
        return HallTypeDomain.Convert(HallTypeDB.Convert(IdHallType,halltype));
    }
    public bool DeleteHall(int hallId)
    {
        try
        {
            _connection.Open();
            NpgsqlCommand command = new NpgsqlCommand($"delete from hall where id={hallId}", _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public IEnumerable<HallDB> GetAllHall()
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand("select * from hall", _connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        List<HallDB> allhalls = new List<HallDB>();
        while (reader.Read())
        {
            allhalls.Add(HallDB.Convert(Convert.ToInt32(reader["id"]), new HallBlank()
            {
                Name = reader["name"].ToString(),
                NumberOfRows =  Convert.ToInt32(reader["number_of_rows"]),
                NumberOfSeats = Convert.ToInt32(reader["number_of_seats"])
            }));
        }
        _connection.Close();
        return allhalls;
    }
}