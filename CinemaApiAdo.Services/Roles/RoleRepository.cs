using CinemaApiADO.Models.HallsTypes.DB;
using CinemaApiADO.Models.Roles.Blank;
using CinemaApiADO.Models.Roles.DB;
using Npgsql;

namespace CinemaApiAdo.Services.Roles;

public class RoleRepository:IRoleRepository
{
    private string connectionString = "Host = localhost; Database = cinemadb; User ID = postgres; Password= vjnbkmlff2004";
    private NpgsqlConnection _connection;
    public RoleRepository()
    {
        _connection = new NpgsqlConnection(connectionString);
    }
    public IEnumerable<RoleDB> GetAllRole()
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand("select * from role",_connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        List<RoleDB> halltypeDbs = new List<RoleDB>();
        while (reader.Read())
        {
            halltypeDbs.Add(RoleDB.Convert(Convert.ToInt32(reader["id"]),new RoleBlank()
            {
                Name = reader["name"].ToString()
            }));
        }
        _connection.Close();        
        return halltypeDbs;
    }

    public void CreateRole(RoleDB roleDb)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand($"insert into role(name) values ('{roleDb.Name}')",
            _connection);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void UpdateRole(RoleDB roleDb)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand($"update role set name = {roleDb.Name} where id={roleDb.Id}");
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void DeleteRole(int roleDb)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand($"delete from role where id={roleDb}", _connection);
        command.ExecuteNonQuery();
        _connection.Close();
    }
}