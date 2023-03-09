using CinemaApiADO.Models.FilmProductions.DB;

namespace CinemaApiADO.Models.FilmProductions.Domain;

public class FilmProductionDomain
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Surname { get; set; }
    public static FilmProductionDomain Convert(FilmProductionDB db)
    {
        return new FilmProductionDomain()
        {
            Id = db.Id,
            Name = db.Name,
            Surname = db.Surname
        };
    }

    public static IEnumerable<FilmProductionDomain> Convert(IEnumerable<FilmProductionDB> dbs)
    {
        return dbs.Select(Convert);
    }
}