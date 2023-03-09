using CinemaApiADO.Models.Companies.Blank;
using CinemaApiADO.Models.Films.Blank;
using CinemaApiADO.Models.Films.Domain;
using CinemaApiADO.Models.Genres.Blank;

namespace CinemaApiADO.Models.Films.View;

public class FilmView
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
    public  List<GenreBlank> genresFilm { get; private set; }
    public  List<CastesFilmBlank> CastesFilmBlanks { get; private set; }
    public List<CompanyBlank> CompaniesFilmBlanks { get; private set; }

    // public static FilmView Convert(FilmDomain filmDomain, List<GenreBlank> genreFilm)
    // {
    //     return new FilmView()
    //     {
    //         Id = filmDomain.Id,
    //         Name = filmDomain.Name,
    //         Duration = filmDomain.Duration,
    //         Release = filmDomain.Release,
    //         Country = filmDomain.Country,
    //         AgeRestriction = filmDomain.AgeRestriction,
    //         TrailerLink = filmDomain.TrailerLink,
    //         ShortDescription = filmDomain.ShortDescription,
    //         PushkinsMap = filmDomain.PushkinsMap,
    //         Poster = filmDomain.Poster,
    //         genresFilm = 
    //     };
    // }
    public static FilmView Convert(FilmDomain filmDomain)
    {
        return new FilmView()
        {
            Id = filmDomain.Id,
            Name = filmDomain.Name,
            Duration = filmDomain.Duration,
            Release = filmDomain.Release,
            Country = filmDomain.Country,
            AgeRestriction = filmDomain.AgeRestriction,
            TrailerLink = filmDomain.TrailerLink,
            ShortDescription = filmDomain.ShortDescription,
            PushkinsMap = filmDomain.PushkinsMap,
            Poster = filmDomain.Poster,
            genresFilm = filmDomain.genresFilm,
            CastesFilmBlanks = filmDomain.CastesFilm,
            CompaniesFilmBlanks = filmDomain.CompaniesFilm
        };
    }

    public static IEnumerable<FilmView> Convert(IEnumerable<FilmDomain> filmDomains)
    {
        return filmDomains.Select(Convert);
    }
}