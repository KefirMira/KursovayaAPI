using CinemaApiADO.Models.Films.Blank;

namespace CinemaApiADO.Models.Films.DB;

public class FilmDB
{
    public  int Id{get; private set;}
    public String Name { get; private set; }
    public int Duration { get; private set; }
    public DateTime Release { get; private set; }
    public String Country { get; private set; }
    public String AgeRestriction { get; private set; }
    public String TrailerLink { get; private set; }
    public String ShortDescription { get; private set; }
    public bool PushkinsMap { get; private set; }
    public String Poster { get; private set; }

    public static FilmDB Convert(FilmBlank filmBlank)
    {
        return new FilmDB()
        {
            Name = filmBlank.Name,
            Duration = filmBlank.Duration,
            Release = filmBlank.Release,
            Country = filmBlank.Country,
            AgeRestriction = filmBlank.AgeRestriction,
            TrailerLink = filmBlank.TrailerLink,
            ShortDescription = filmBlank.ShortDescription,
            PushkinsMap = filmBlank.PushkinsMap,
            Poster = filmBlank.Poster
        };
    }
    public static FilmDB Convert(int filmId,FilmBlank filmBlank)
    {
        return new FilmDB()
        {
            Id = filmId,
            Name = filmBlank.Name,
            Duration = filmBlank.Duration,
            Release = filmBlank.Release,
            Country = filmBlank.Country,
            AgeRestriction = filmBlank.AgeRestriction,
            TrailerLink = filmBlank.TrailerLink,
            ShortDescription = filmBlank.ShortDescription,
            PushkinsMap = filmBlank.PushkinsMap,
            Poster = filmBlank.Poster
        };
    }
}
