using CinemaApiADO.Models.Genres.Blank;
using CinemaApiADO.Models.Genres.DB;
using Npgsql;

namespace CinemaApiAdo.Services.Genres;

public class GenreRepository: IGenreRepositore
{
    private string connectionString = "Host = localhost; Database = cinemadb; User ID = postgres; Password= vjnbkmlff2004";
    private NpgsqlConnection _connection;

    public GenreRepository()
    {
        _connection = new NpgsqlConnection(connectionString);
    }
    
    public void CreateGenre(GenreDB genre)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand($"insert into genre(name) values ('{genre.Name}')",
            _connection);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void UpdateGenre(GenreDB genre)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand($"update genre set name = {genre.Name} where id={genre.Id}");
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void DeleteGenre(int genreId)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand($"delete from genre where id={genreId}", _connection);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public GenreDB GetGenre(int genreId)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand($"select * from genre where id={genreId}", _connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        GenreBlank genreBlank = new GenreBlank();
        while (reader.Read())
        {
            genreBlank.Name = reader["name"].ToString();
        }
        _connection.Close();
        return GenreDB.Convert(genreBlank);
    }

    public IEnumerable<GenreDB> GetAllGenres()
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand("select * from genre", _connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        List<GenreDB> allgenre = new List<GenreDB>();
        while (reader.Read())
        {
            allgenre.Add(GenreDB.Convert(Convert.ToInt32(reader["id"]),new GenreBlank()
            {
                Name = reader["name"].ToString()
            }));
        }
        _connection.Close();
        return allgenre;
    }
}