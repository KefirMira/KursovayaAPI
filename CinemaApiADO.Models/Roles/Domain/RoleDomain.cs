using CinemaApiADO.Models.Companies.DB;
using CinemaApiADO.Models.Roles.DB;

namespace CinemaApiADO.Models.Roles.Domain;

public class RoleDomain
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public static RoleDomain Convert(RoleDB companyDB)
    {
        return new RoleDomain()
        {
            Id = companyDB.Id,
            Name = companyDB.Name
        };
    }

    public static IEnumerable<RoleDomain> Convert(IEnumerable<RoleDB> dbs)
    {
        return dbs.Select(Convert);
    }
}