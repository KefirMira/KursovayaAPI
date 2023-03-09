using System.Runtime.InteropServices.JavaScript;

namespace CinemaApiADO.Models.Films.Blank;

public class FilmBlank
{
    public String Name { get; set; }
    public int Duration { get; set; }
    public DateTime Release { get; set; }
    public String Country { get; set; }
    public String AgeRestriction { get; set; }
    public String TrailerLink { get; set; }
    public String ShortDescription { get; set; }
    public bool PushkinsMap { get; set; }
    public String Poster { get; set; }
}