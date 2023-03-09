using CinemaApiADO.Models.Companies.Blank;

namespace CinemaApiADO.Models.Companies.DB;

public class CompanyDB
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public static CompanyDB Convert(CompanyBlank companylank)
    {
        return new CompanyDB()
        {
            Name = companylank.Name
        };
    } 
    public static CompanyDB Convert(int companyId ,CompanyBlank companyblank)
    {
        return new CompanyDB()
        {
            Id = companyId,
            Name = companyblank.Name
        };
    }
}