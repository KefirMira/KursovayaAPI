using CinemaApiADO.Models.Cinemas.Blank;

namespace CinemaApiADO.Models.Cinemas.DB;

public class CinemaDB
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public static CinemaDB Convert(CinemaBlank cinemaBlank)
    {
        return new CinemaDB()
        {
            Name = cinemaBlank.Name
        };
    } 
    public static CinemaDB Convert(int cinemaId ,CinemaBlank cinemablank)
    {
        return new CinemaDB()
        {
            Id = cinemaId,
            Name = cinemablank.Name
        };
    }
}