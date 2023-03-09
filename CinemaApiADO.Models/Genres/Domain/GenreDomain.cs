using System.Net;
using CinemaApiADO.Models.Genres.DB;

namespace CinemaApiADO.Models.Genres.Domain;

public class GenreDomain
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public static GenreDomain Convert(GenreDB genreDB)
    {
        return new GenreDomain()
        {
            Id = genreDB.Id,
            Name = genreDB.Name
        };
    }

    public static IEnumerable<GenreDomain> Convert(IEnumerable<GenreDB> dbs)
    {
        return dbs.Select(Convert);
    }
}