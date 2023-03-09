using CinemaApiADO.Models.HallsTypes.Blank;
using CinemaApiADO.Models.Roles.Blank;
using CinemaApiADO.Models.Roles.Domain;

namespace CinemaApiAdo.Services.Roles;

public interface IRoleService
{
    IEnumerable<RoleDomain> GetAllRole();
    void CreateRole(RoleBlank roleBlank);
    void UpdateRole(int roleId,RoleBlank roleBlank);
    void DeleteRole(int roleId);
}