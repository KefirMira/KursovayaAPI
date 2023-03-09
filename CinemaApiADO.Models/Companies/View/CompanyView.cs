using CinemaApiADO.Models.Companies.Domain;

namespace CinemaApiADO.Models.Companies.View;

public class CompanyView
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public static CompanyView Convert(CompanyDomain companyDomain)
    {
        return new CompanyView()
        {
            Id = companyDomain.Id,
            Name = companyDomain.Name
        };
    }

    public static IEnumerable<CompanyView> Convert(IEnumerable<CompanyDomain> domains)
    {
        return domains.Select(Convert);
    }
}