using CinemaApiADO.Models.Roles.Domain;

namespace CinemaApiADO.Models.Roles.View;

public class RoleView
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public static RoleView Convert(RoleDomain companyDomain)
    {
        return new RoleView()
        {
            Id = companyDomain.Id,
            Name = companyDomain.Name
        };
    }

    public static IEnumerable<RoleView> Convert(IEnumerable<RoleDomain> domains)
    {
        return domains.Select(Convert);
    }
}