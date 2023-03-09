using CinemaApiADO.Models.Roles.Blank;
using CinemaApiADO.Models.Roles.DB;
using CinemaApiADO.Models.Roles.Domain;

namespace CinemaApiAdo.Services.Roles;

public class RoleService:IRoleService
{
    private readonly RoleRepository _repository;

    public RoleService()
    {
        _repository = new RoleRepository();
    }
    public IEnumerable<RoleDomain> GetAllRole()
    {
        IEnumerable<RoleDB> allhalltypes = _repository.GetAllRole();
        return RoleDomain.Convert(allhalltypes);
    }

    public void CreateRole(RoleBlank roleBlank)
    {
        RoleDB newrole = RoleDB.Convert(roleBlank);
        _repository.CreateRole(newrole);
    }

    public void UpdateRole(int roleId, RoleBlank roleBlank)
    {
        RoleDB updaterole = RoleDB.Convert(roleId,roleBlank);
        _repository.UpdateRole(updaterole);
    }

    public void DeleteRole(int roleId)
    {
        _repository.DeleteRole(roleId);
    }
}