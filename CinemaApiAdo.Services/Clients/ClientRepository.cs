using CinemaApiADO.Models.Clients.Blank;
using CinemaApiADO.Models.Clients.DB;
using Npgsql;

namespace CinemaApiAdo.Services.Clients;

public class ClientRepository:IClientRepository
{
    private string connectionString = "Host = localhost; Database = cinemadb; User ID = postgres; Password= vjnbkmlff2004";
    private NpgsqlConnection _connection;
    public ClientRepository()
    {
        _connection = new NpgsqlConnection(connectionString);
    }
    public bool CreateClient(ClientDB clientBlank)
    {
        try
        {
            _connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(
                $"insert into client(surname, name, patronymic, login, " +
                $"password, telephone, mail, discount) values ('{clientBlank.Surname}'," +
                $"'{clientBlank.Name}','{clientBlank.Patronymic}','{clientBlank.Login}'" +
                $",'{clientBlank.Password}','{clientBlank.Telephone}','{clientBlank.Mail}'" +
                $",'{clientBlank.Discount}')", _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool UpdateClient(int companyId, ClientDB company)
    {
        try
        {
            _connection.Open();
            NpgsqlCommand command = new NpgsqlCommand($"update client set name = {company.Name} ," +
                                                      $"surname = {company.Surname}, patronymic = {company.Patronymic}," +
                                                      $"login = {company.Login}, password = {company.Password}," +
                                                      $"telephone = {company.Telephone}, mail ={company.Mail}," +
                                                      $"discount = {company.Discount} where id = {companyId}",
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

    public bool DeleteClient(int companyId)
    {
        try
        {
            _connection.Open();
            NpgsqlCommand command = new NpgsqlCommand($"delete from client where id={companyId}", _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }
        catch
        {
            return false;
        }

    }

    public ClientDB GetClient(int companyId)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand($"select * from client where id ={companyId}", _connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        ClientBlank selectedClient = new ClientBlank();
        while (reader.Read())
        {
            selectedClient.Name = reader["name"].ToString();
            selectedClient.Surname = reader["surname"].ToString();
            selectedClient.Patronymic = reader["patronymic"].ToString();
            selectedClient.Login = reader["login"].ToString();
            selectedClient.Password = reader["password"].ToString();
            selectedClient.Mail = reader["mail"].ToString();
            selectedClient.Telephone = reader["telephone"].ToString();
            selectedClient.Discount = Convert.ToInt32(reader["discount"]);
        }
        _connection.Close();
        return ClientDB.Convert(selectedClient);
    }

    public IEnumerable<ClientDB> GetAllClients()
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand("select * from client", _connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        List<ClientDB> clients = new List<ClientDB>();
        while (reader.Read())
        {
            clients.Add( ClientDB.Convert(Convert.ToInt32(reader["id"]), new ClientBlank()
            {
                Name  = reader["name"].ToString(),
                Surname = reader["surname"].ToString(),
                Patronymic = reader["patronymic"].ToString(),
                Login = reader["login"].ToString(),
                Password = reader["password"].ToString(),
                Mail = reader["mail"].ToString(),
                Telephone = reader["telephone"].ToString(),
                Discount = Convert.ToInt32(reader["discount"])
            }));
        }
        _connection.Close();
        return clients;
    }

    public ClientDB GetClient(string login, string password)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand($"select * from client where  " +
                                                  $"password='{password}'  and login='{login}'", _connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        ClientBlank authclient = new ClientBlank();
        while (reader.Read())
        {
            authclient.Name = reader["name"].ToString();
            authclient.Surname = reader["surname"].ToString();
            authclient.Patronymic = reader["patronymic"].ToString();
            authclient.Login = reader["login"].ToString();
            authclient.Password = reader["password"].ToString();
            authclient.Mail = reader["mail"].ToString();
            authclient.Telephone = reader["telephone"].ToString();
            authclient.Discount = Convert.ToInt32(reader["discount"]);
        }
        return ClientDB.Convert(authclient);
    }
}