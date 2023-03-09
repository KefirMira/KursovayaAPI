using CinemaApiADO.Models.Halls.DB;
using CinemaApiADO.Models.HallsTypes.Blank;

namespace CinemaApiADO.Models.Halls.Domain;

public class HallDomain
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int NumberOfSeats { get; set; }
    public int NumberOfRows { get; set; }
    public HallTypeBlank HallType { get; set; }
    public static HallDomain Convert(HallDB hallDb)
    {
        return new HallDomain()
        {
            Id = hallDb.Id,
            Name = hallDb.Name,
            NumberOfSeats = hallDb.NumberOfSeats,
            NumberOfRows = hallDb.NumberOfRows
        };
    }
    public static HallDomain Convert(HallDB hallDb, HallTypeBlank halltypeBlanks)
    {
        return new HallDomain()
        {
            Id = hallDb.Id,
            Name = hallDb.Name,
            NumberOfSeats = hallDb.NumberOfSeats,
            NumberOfRows = hallDb.NumberOfRows,
            HallType = halltypeBlanks
        };
    }

    public static IEnumerable<HallDomain> Convert(IEnumerable<HallDB> dbs)
    {
        return dbs.Select(Convert);
    }
}