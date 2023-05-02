using CinemaApiADO.Models.Roles.DB;

namespace CinemaApiAdo.Services.Roles;

public interface IRoleRepository
{
    IEnumerable<RoleDB> GetAllRole();
    bool CreateRole(RoleDB roleDb);
    bool UpdateRole(RoleDB roleDb);
    bool DeleteRole(int roleDb);
}