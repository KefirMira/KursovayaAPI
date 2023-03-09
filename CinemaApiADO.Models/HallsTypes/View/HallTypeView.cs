using CinemaApiADO.Models.Companies.Domain;
using CinemaApiADO.Models.HallsTypes.Domain;

namespace CinemaApiADO.Models.HallsTypes.View;

public class HallTypeView
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public static HallTypeView Convert(HallTypeDomain companyDomain)
    {
        return new HallTypeView()
        {
            Id = companyDomain.Id,
            Name = companyDomain.Name
        };
    }

    public static IEnumerable<HallTypeView> Convert(IEnumerable<HallTypeDomain> domains)
    {
        return domains.Select(Convert);
    }
}