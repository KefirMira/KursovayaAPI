using CinemaApiADO.Models.Genres.Domain;

namespace CinemaApiADO.Models.Genres.View;

public class GenreView
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public static GenreView Convert(GenreDomain genreDoamin)
    {
        return new GenreView()
        {
            Id = genreDoamin.Id,
            Name = genreDoamin.Name
        };
    }

    public static IEnumerable<GenreView> Convert(IEnumerable<GenreDomain> domains)
    {
        return domains.Select(Convert);
    }
}