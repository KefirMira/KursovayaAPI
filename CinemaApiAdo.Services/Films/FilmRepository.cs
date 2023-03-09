using CinemaApiADO.Models.Castes;
using CinemaApiADO.Models.Companies.Blank;
using CinemaApiADO.Models.Films.Blank;
using CinemaApiADO.Models.Films.DB;
using CinemaApiADO.Models.Genres.Blank;
using CinemaApiADO.Models.Genres.Domain;
using CinemaApiADO.Models.GenresFilms;
using Npgsql;

namespace CinemaApiAdo.Services.Films;

public class FilmRepository: IFilmRepository
{
    private string connectionString = "Host = localhost; Database = cinemadb; User ID = postgres; Password= vjnbkmlff2004";
    private NpgsqlConnection _connection;

    public FilmRepository()
    {
        _connection = new NpgsqlConnection(connectionString);
    }
    
    public void CreateFilm(FilmDB film)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand(
            $"insert into film(name, age_restriction, country, duration, poster," +
            $"release, pushkins_map, short_description," +
            $"trailer_link) values ('{film.Name}', '{film.AgeRestriction}', '{film.Country}'" +
            $", '{film.Duration}', '{film.Poster}', '{film.Release}', '{film.ShortDescription}'" +
            $", '{film.TrailerLink}')", _connection);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void UpdateFilm(FilmDB film)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand(
            $"update film set (name, age_restriction, country, duration, poster," +
            $"release, pushkins_map, short_description," +
            $"trailer_link) values ('{film.Name}', '{film.AgeRestriction}', '{film.Country}'" +
            $", '{film.Duration}', '{film.Poster}', '{film.Release}', '{film.ShortDescription}'" +
            $", '{film.TrailerLink}') where id={film.Id}", _connection);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void DeleteFilm(int filmId)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand($"delete from film where id={filmId}", _connection);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public FilmDB GetFilm(int filmId)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand($"select * from film where id= {filmId}", _connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        FilmBlank film = new FilmBlank();
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
        return FilmDB.Convert(film);
    }

    public IEnumerable<GenreBlank> GetGenreFilm(int filmId)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand($"select name from genres_film join genre g on g.id = genres_film.idgenre where idfilm = {filmId}", _connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        List <GenreBlank> genretofilm= new List<GenreBlank>();
        while (reader.Read())
        {
            genretofilm.Add(new GenreBlank(){ Name = reader["name"].ToString()} );
        }
        _connection.Close();
        return genretofilm;
    }
    public IEnumerable<CompanyBlank> GetCompanyFilm(int filmId)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand($"select name from companies_to_film join film_company on film_company.id = companies_to_film.idfilm_conpany where idfilm = {filmId}", _connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        List <CompanyBlank> companytofilm= new List<CompanyBlank>();
        while (reader.Read())
        {
            companytofilm.Add(new CompanyBlank(){ Name = reader["name"].ToString()} );
        }
        _connection.Close();
        return companytofilm;
    }

    public IEnumerable<CastesFilmBlank> GetCastesFilm(int filmId)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand($"select surname, r.name as rolename, fp.name from caste join film_production fp on caste.idfilm_production = fp.id" +
                                                  $" join role r on caste.idrole = r.id where idfilm = {filmId}", _connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        List<CastesFilmBlank> castesFilmBlanks = new List<CastesFilmBlank>();
        while (reader.Read())
        {
            castesFilmBlanks.Add(new CastesFilmBlank()
            {
                Surname = reader["surname"].ToString(),
                Name = reader["name"].ToString(),
                Role = reader["rolename"].ToString()
            });
        }
        _connection.Close();
        return castesFilmBlanks;
    }

    public IEnumerable<FilmDB> GetAllFilm()
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand("select * from film", _connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        List<FilmDB> allfilms = new List<FilmDB>();
        while (reader.Read())
        {
            allfilms.Add(FilmDB.Convert(Convert.ToInt32(reader["id"]), new FilmBlank()
            {
                Name = reader["name"].ToString(),
                AgeRestriction = reader["age_restriction"].ToString(),
                Country = reader["country"].ToString(),
                Duration = Convert.ToInt32(reader["duration"]),
                Poster = reader["poster"].ToString(),
                Release = Convert.ToDateTime(reader["release"]),
                PushkinsMap = Convert.ToBoolean(reader["pushkins_map"]),
                ShortDescription = reader["short_description"].ToString(),
                TrailerLink = reader["trailer_link"].ToString(),
            }));
        }
        _connection.Close();
        return allfilms;
    }

    public void CreateGenresFilm(GenresFilms genresFilms)
    {
        _connection.Open();
        NpgsqlCommand command =
            new NpgsqlCommand(
                $"insert into genres_film( idgenre, idfilm) values ({genresFilms.genreId},{genresFilms.filmId})",
                _connection);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void CreateCasteFilm(Caste caste)
    {
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand($"insert into caste(idfilm, idfilm_production, idrole) values ({caste.filmId},{caste.filmprodId},{caste.roleId})", _connection);
        command.ExecuteNonQuery();
        _connection.Close();
    }
}