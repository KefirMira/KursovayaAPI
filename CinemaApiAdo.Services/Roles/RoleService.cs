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

    public bool CreateRole(RoleBlank roleBlank)
    {
        try
        {
            RoleDB newrole = RoleDB.Convert(roleBlank);
            _repository.CreateRole(newrole);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool UpdateRole(int roleId, RoleBlank roleBlank)
    {
        try
        {
 RoleDB updaterole = RoleDB.Convert(roleId,roleBlank);
                 _repository.UpdateRole(updaterole);
                 return true;
        }
        catch
        {
            return false;
        }
       
    }

    public bool DeleteRole(int roleId)
    {
        try
        {
            _repository.DeleteRole(roleId);
            return true;
        }
        catch
        {
            return false;
        }
    }
}