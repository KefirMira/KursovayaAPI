using CinemaApiADO.Models.Halls.Blank;
using CinemaApiADO.Models.HallsTypes.Blank;

namespace CinemaApiADO.Models.Halls.DB;

public class HallDB
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int NumberOfSeats { get; set; }
    public int NumberOfRows { get; set; }
    public static HallDB Convert(HallBlank hallBlank)
    {
        return new HallDB()
        {
            Name = hallBlank.Name,
            NumberOfSeats = hallBlank.NumberOfSeats,
            NumberOfRows = hallBlank.NumberOfRows
        };
    }
    public static HallDB Convert(int hallId,HallBlank hallBlank)
    {
        return new HallDB()
        {
            Id = hallId,
            Name = hallBlank.Name,
            NumberOfSeats= hallBlank.NumberOfSeats,
            NumberOfRows = hallBlank.NumberOfRows
        };
    }
}