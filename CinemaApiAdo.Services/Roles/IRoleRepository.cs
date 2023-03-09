using CinemaApiADO.Models.Roles.DB;

namespace CinemaApiAdo.Services.Roles;

public interface IRoleRepository
{
    IEnumerable<RoleDB> GetAllRole();
    void CreateRole(RoleDB roleDb);
    void UpdateRole(RoleDB roleDb);
    void DeleteRole(int roleDb);
}