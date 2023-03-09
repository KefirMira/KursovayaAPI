using CinemaApiADO.Models.Cinemas.Domain;

namespace CinemaApiADO.Models.Cinemas.View;

public class CinemaView
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public static CinemaView Convert(CinemaDomain cinemaDomain)
    {
        return new CinemaView()
        {
            Id = cinemaDomain.Id,
            Name = cinemaDomain.Name
        };
    }

    public static IEnumerable<CinemaView> Convert(IEnumerable<CinemaDomain> domains)
    {
        return domains.Select(Convert);
    }
}