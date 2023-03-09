using CinemaApiADO.Models.Halls.Domain;
using CinemaApiADO.Models.HallsTypes.Blank;

namespace CinemaApiADO.Models.Halls.View;

public class HallView
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int NumberOfSeats { get; set; }
    public int NumberOfRows { get; set; }
    public HallTypeBlank HallType { get; set; }
    public static HallView Convert(HallDomain hallDomain)
    {
        return new HallView()
        {
            Id = hallDomain.Id,
            Name = hallDomain.Name,
            NumberOfSeats = hallDomain.NumberOfSeats,
            NumberOfRows = hallDomain.NumberOfRows,
            HallType = hallDomain.HallType
        };
    }

    public static IEnumerable<HallView> Convert(IEnumerable<HallDomain> dbs)
    {
        return dbs.Select(Convert);
    }
}