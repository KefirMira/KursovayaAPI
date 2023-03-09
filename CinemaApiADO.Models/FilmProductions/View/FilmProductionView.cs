using CinemaApiADO.Models.FilmProductions.Domain;

namespace CinemaApiADO.Models.FilmProductions.View;

public class FilmProductionView
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Surname { get; set; }
    public static FilmProductionView Convert(FilmProductionDomain domain)
    {
        return new FilmProductionView()
        {
            Id = domain.Id,
            Name = domain.Name,
            Surname = domain.Surname
        };
    }

    public static IEnumerable<FilmProductionView> Convert(IEnumerable<FilmProductionDomain> domains)
    {
        return domains.Select(Convert);
    }
}