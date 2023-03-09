using CinemaApiADO.Models.Companies.DB;

namespace CinemaApiADO.Models.Companies.Domain;

public class CompanyDomain
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public static CompanyDomain Convert(CompanyDB companyDB)
    {
        return new CompanyDomain()
        {
            Id = companyDB.Id,
            Name = companyDB.Name
        };
    }

    public static IEnumerable<CompanyDomain> Convert(IEnumerable<CompanyDB> dbs)
    {
        return dbs.Select(Convert);
    }
}