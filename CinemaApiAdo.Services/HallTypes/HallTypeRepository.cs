using CinemaApiADO.Models.Cinemas.Blank;
using CinemaApiADO.Models.Cinemas.DB;
using CinemaApiADO.Models.HallsTypes.Blank;
using CinemaApiADO.Models.HallsTypes.DB;
using Npgsql;

namespace CinemaApiAdo.Services.HallTypes;

public class HallTypeRepository:IHallTypeRepository
{
    private string connectionString = "Host = localhost; Database = cinemadb; User ID = postgres; Password= vjnbkmlff2004";
    private NpgsqlConnection _connection;
    public HallTypeRepository()
    {
        _connection = new NpgsqlConnection(connectionString);
    }
    public IEnumerable<HallTypeDB> GetAllHallType()
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand("select * from hall_type",_connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        List<HallTypeDB> halltypeDbs = new List<HallTypeDB>();
        while (reader.Read())
        {
            halltypeDbs.Add(HallTypeDB.Convert(Convert.ToInt32(reader["id"]),new HallTypeBlank()
            {
                Name = reader["name"].ToString()
            }));
        }
        _connection.Close();        
        return halltypeDbs;
    }

    public bool CreateHallType(HallTypeDB hallTypeDb)
    {
        try
        {
            _connection.Open();
            NpgsqlCommand command = new NpgsqlCommand($"insert into hall_type(name) values ('{hallTypeDb.Name}')",
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

    public bool UpdateHallType(HallTypeDB hallTypeDb)
    {
        try
        {
            _connection.Open();
            NpgsqlCommand command =
                new NpgsqlCommand($"update hall_type set name = {hallTypeDb.Name} where id={hallTypeDb.Id}");
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool DeleteHallType(int hallTypeId)
    {
        try
        {
            _connection.Open();
            NpgsqlCommand command = new NpgsqlCommand($"delete from hall_type where id={hallTypeId}", _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }
        catch 
        {
            return false;
        }
        
    }
}