using CinemaApiADO.Models.HallsTypes.DB;

namespace CinemaApiADO.Models.HallsTypes.Domain;

public class HallTypeDomain
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public static HallTypeDomain Convert(HallTypeDB companyDB)
    {
        return new HallTypeDomain()
        {
            Id = companyDB.Id,
            Name = companyDB.Name
        };
    }

    public static IEnumerable<HallTypeDomain> Convert(IEnumerable<HallTypeDB> dbs)
    {
        return dbs.Select(Convert);
    }
}