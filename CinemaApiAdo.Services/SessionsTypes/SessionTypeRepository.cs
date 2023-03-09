using CinemaApiADO.Models.SessionsTypes.Blank;
using CinemaApiADO.Models.SessionsTypes.DB;
using Npgsql;

namespace CinemaApiAdo.Services.SessionsTypes;

public class SessionTypeRepository : ISessionTypeRepository
{
    private string connectionString = "Host = localhost; Database = cinemadb; User ID = postgres; Password= vjnbkmlff2004";
    private NpgsqlConnection _connection;
    public SessionTypeRepository()
    {
        _connection = new NpgsqlConnection(connectionString);
    }
    public IEnumerable<SessionTypeDB> GetAllSessionType()
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand("select * from session_type",_connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        List<SessionTypeDB> cinemaDbs = new List<SessionTypeDB>();
        while (reader.Read())
        {
            cinemaDbs.Add(SessionTypeDB.Convert(Convert.ToInt32(reader["id"]),new SessionTypeBlank()
            {
                Name = reader["name"].ToString()
            }));
        }
        _connection.Close();        
        return cinemaDbs;
    }
}