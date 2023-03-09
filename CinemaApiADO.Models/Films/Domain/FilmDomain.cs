using CinemaApiADO.Models.Companies.Blank;
using CinemaApiADO.Models.Films.Blank;
using CinemaApiADO.Models.Films.DB;
using CinemaApiADO.Models.Genres.Blank;
using CinemaApiADO.Models.Genres.Domain;

namespace CinemaApiADO.Models.Films.Domain;

public class FilmDomain
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
    public List<GenreBlank> genresFilm  { get; private set; }
    public List<CastesFilmBlank> CastesFilm  { get; private set; }
    
    public List<CompanyBlank> CompaniesFilm   { get; private set; }
    public static FilmDomain Convert(FilmDB filmDB)
    {
        return new FilmDomain()
        {
            Id = filmDB.Id,
            Name = filmDB.Name,
            Duration = filmDB.Duration,
            Release = filmDB.Release,
            Country = filmDB.Country,
            AgeRestriction = filmDB.AgeRestriction,
            TrailerLink = filmDB.TrailerLink,
            ShortDescription = filmDB.ShortDescription,
            PushkinsMap = filmDB.PushkinsMap,
            Poster = filmDB.Poster
        };
    }
    public static FilmDomain Convert(FilmDB filmDB, List<GenreBlank> genresFilm, List<CastesFilmBlank> castesFilmBlanks, List<CompanyBlank> companyBlanks)
    {
        return new FilmDomain()
        {
            Id = filmDB.Id,
            Name = filmDB.Name,
            Duration = filmDB.Duration,
            Release = filmDB.Release,
            Country = filmDB.Country,
            AgeRestriction = filmDB.AgeRestriction,
            TrailerLink = filmDB.TrailerLink,
            ShortDescription = filmDB.ShortDescription,
            PushkinsMap = filmDB.PushkinsMap,
            Poster = filmDB.Poster,
            genresFilm = new List<GenreBlank>(genresFilm),
            CastesFilm = new List<CastesFilmBlank>(castesFilmBlanks),
            CompaniesFilm = new List<CompanyBlank>(companyBlanks)
        };
    }

    public static IEnumerable<FilmDomain> Convert(IEnumerable<FilmDB> dbs)
    {
        return dbs.Select(Convert);
    }
}