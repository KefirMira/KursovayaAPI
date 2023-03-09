using CinemaApiADO.Models.Genres.Blank;

namespace CinemaApiADO.Models.Genres.DB;

public class GenreDB
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public static GenreDB Convert(GenreBlank genreblank)
    {
        return new GenreDB()
        {
            Name = genreblank.Name
        };
    } 
    public static GenreDB Convert(int genreId ,GenreBlank genreblank)
    {
        return new GenreDB()
        {
            Id = genreId,
            Name = genreblank.Name
        };
    }
}