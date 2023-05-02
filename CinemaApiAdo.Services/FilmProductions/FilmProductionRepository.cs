using CinemaApiADO.Models.FilmProductions.Blank;
using CinemaApiADO.Models.FilmProductions.DB;
using CinemaApiADO.Models.FilmProductions.Domain;
using Npgsql;

namespace CinemaApiAdo.Services.FilmProductions;

public class FilmProductionRepository:IFilmProductionRepository
{
    private string connectionString = "Host = localhost; Database = cinemadb; User ID = postgres; Password= vjnbkmlff2004";
    private NpgsqlConnection _connection;
    public FilmProductionRepository()
    {
        _connection = new NpgsqlConnection(connectionString);
    }
    public bool CreateFilmProduction(FilmProductionDB filmProductionBlank)
    {
        try
        {

            _connection.Open();
            NpgsqlCommand command =
                new NpgsqlCommand(
                    $"insert into film_production(name,surname) values ('{filmProductionBlank.Name}','{filmProductionBlank.Surname}')",
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

    public bool UpdateFilmProduction(int filmProductionId, FilmProductionDB filmProduction)
    {
        try
        {
            _connection.Open();
            NpgsqlCommand command =
                new NpgsqlCommand(
                    $"update film_production set name = {filmProduction.Name},surname = {filmProduction.Surname} where id = {filmProductionId}",
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

    public bool DeleteFilmProduction(int filmProductionId)
    {
        try
        {
            _connection.Open();
            NpgsqlCommand command =
                new NpgsqlCommand($"delete from film_production where id = {filmProductionId}", _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public IEnumerable<FilmProductionDB> GetAllFilmProduction()
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand("select * from film_production", _connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        List<FilmProductionDB> allcompany = new List<FilmProductionDB>();
        while (reader.Read())
        {
            allcompany.Add(FilmProductionDB.Convert(Convert.ToInt32(reader["id"]),new FilmProductionBlank()
            {
                Name = reader["name"].ToString(),
                Surname = reader["surname"].ToString()
            }));
        }
        _connection.Close();
        return allcompany;
    }
}