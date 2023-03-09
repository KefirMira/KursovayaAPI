using CinemaApiADO.Models.SessionsTypes.DB;

namespace CinemaApiADO.Models.SessionsTypes.Domain;

public class SessionTypeDomain
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public static SessionTypeDomain Convert(SessionTypeDB companyDB)
    {
        return new SessionTypeDomain()
        {
            Id = companyDB.Id,
            Name = companyDB.Name
        };
    }

    public static IEnumerable<SessionTypeDomain> Convert(IEnumerable<SessionTypeDB> dbs)
    {
        return dbs.Select(Convert);
    }
}