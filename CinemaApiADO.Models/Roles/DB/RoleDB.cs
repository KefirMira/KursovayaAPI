using CinemaApiADO.Models.Roles.Blank;

namespace CinemaApiADO.Models.Roles.DB;

public class RoleDB
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public static RoleDB Convert(RoleBlank companylank)
    {
        return new RoleDB()
        {
            Name = companylank.Name
        };
    } 
    public static RoleDB Convert(int companyId ,RoleBlank companyblank)
    {
        return new RoleDB()
        {
            Id = companyId,
            Name = companyblank.Name
        };
    }
}