using CinemaApiADO.Models.FilmProductions.Blank;

namespace CinemaApiADO.Models.FilmProductions.DB;

public class FilmProductionDB
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Surname { get; set; }

    public static FilmProductionDB Convert(FilmProductionBlank blank)
    {
        return new FilmProductionDB()
        {
            Name = blank.Name,
            Surname = blank.Surname
        };
    } 
    public static FilmProductionDB Convert(int blankId ,FilmProductionBlank blank)
    {
        return new FilmProductionDB()
        {
            Id = blankId,
            Name = blank.Name,
            Surname = blank.Surname
        };
    }
}