using CinemaApiADO.Models.Companies.Blank;
using CinemaApiADO.Models.Companies.DB;
using Npgsql;

namespace CinemaApiAdo.Services.Companies;

public class CompanyRepository : ICompanyRepository
{
    private string connectionString = "Host = localhost; Database = cinemadb; User ID = postgres; Password= vjnbkmlff2004";
    private NpgsqlConnection _connection;
    public CompanyRepository()
    {
        _connection = new NpgsqlConnection(connectionString);
    }
    public void CreateCompany(CompanyDB companyBlank)
    {
        _connection.Open();
        NpgsqlCommand command =
            new NpgsqlCommand($"insert into film_company(name) values ('{companyBlank.Name}')", _connection);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void UpdateCompany(int companyId, CompanyDB company)
    {
       _connection.Open();
       NpgsqlCommand command = new NpgsqlCommand($"update film_company set name = {company.Name} where id = {companyId}", _connection);
       command.ExecuteNonQuery();
       _connection.Close();
    }

    public void DeleteCompany(int companyId)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand($"delete from film_company where id = {companyId}", _connection);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public CompanyDB GetCompany(int companyId)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand($"select * from film_company where id={companyId}", _connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        CompanyBlank companyBlank = new CompanyBlank();
        while (reader.Read())
        {
            companyBlank.Name = reader["name"].ToString();
        }
        _connection.Close();
        return CompanyDB.Convert(companyBlank);
    }

    public IEnumerable<CompanyDB> GetAllCompanies()
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand("select * from film_company", _connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        List<CompanyDB> allcompany = new List<CompanyDB>();
        while (reader.Read())
        {
            allcompany.Add(CompanyDB.Convert(Convert.ToInt32(reader["id"]),new CompanyBlank()
            {
                Name = reader["name"].ToString()
            }));
        }
        _connection.Close();
        return allcompany;
    }
}