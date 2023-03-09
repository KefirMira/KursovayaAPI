using CinemaApiADO.Models.Cinemas.Blank;
using CinemaApiADO.Models.Cinemas.DB;
using Npgsql;

namespace CinemaApiAdo.Services.Cinemas;

public class CinemaRepository: ICinemaRepository
{
    private string connectionString = "Host = localhost; Database = cinemadb; User ID = postgres; Password= vjnbkmlff2004";
    private NpgsqlConnection _connection;
    public CinemaRepository()
    {
        _connection = new NpgsqlConnection(connectionString);
    }
    public IEnumerable<CinemaDB> GetAllCinemas()
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand("select * from cinema",_connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        List<CinemaDB> cinemaDbs = new List<CinemaDB>();
        while (reader.Read())
        {
            cinemaDbs.Add(CinemaDB.Convert(Convert.ToInt32(reader["id"]),new CinemaBlank()
            {
                Name = reader["name"].ToString()
            }));
        }
        _connection.Close();        
        return cinemaDbs;
    }
}