using CinemaApiADO.Models.HallsTypes.Blank;
using CinemaApiADO.Models.Roles.Blank;
using CinemaApiADO.Models.Roles.Domain;

namespace CinemaApiAdo.Services.Roles;

public interface IRoleService
{
    IEnumerable<RoleDomain> GetAllRole();
    bool CreateRole(RoleBlank roleBlank);
    bool UpdateRole(int roleId,RoleBlank roleBlank);
    bool DeleteRole(int roleId);
}