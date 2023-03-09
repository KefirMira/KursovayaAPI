using CinemaApiADO.Models.Cinemas.DB;
using CinemaApiADO.Models.Companies.DB;
using CinemaApiADO.Models.Companies.Domain;

namespace CinemaApiADO.Models.Cinemas.Domain;

public class CinemaDomain
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public static CinemaDomain Convert(CinemaDB cinemaDB)
    {
        return new CinemaDomain()
        {
            Id = cinemaDB.Id,
            Name = cinemaDB.Name
        };
    }

    public static IEnumerable<CinemaDomain> Convert(IEnumerable<CinemaDB> dbs)
    {
        return dbs.Select(Convert);
    }
}