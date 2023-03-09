using CinemaApiADO.Models.SessionsTypes.Domain;

namespace CinemaApiADO.Models.SessionsTypes.View;

public class SessionTypeView
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public static SessionTypeView Convert(SessionTypeDomain companyDomain)
    {
        return new SessionTypeView()
        {
            Id = companyDomain.Id,
            Name = companyDomain.Name
        };
    }

    public static IEnumerable<SessionTypeView> Convert(IEnumerable<SessionTypeDomain> domains)
    {
        return domains.Select(Convert);
    }
}