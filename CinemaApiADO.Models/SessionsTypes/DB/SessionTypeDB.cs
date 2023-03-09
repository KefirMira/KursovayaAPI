using CinemaApiADO.Models.SessionsTypes.Blank;

namespace CinemaApiADO.Models.SessionsTypes.DB;

public class SessionTypeDB
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public static SessionTypeDB Convert(SessionTypeBlank companylank)
    {
        return new SessionTypeDB()
        {
            Name = companylank.Name
        };
    } 
    public static SessionTypeDB Convert(int companyId ,SessionTypeBlank companyblank)
    {
        return new SessionTypeDB()
        {
            Id = companyId,
            Name = companyblank.Name
        };
    }
}