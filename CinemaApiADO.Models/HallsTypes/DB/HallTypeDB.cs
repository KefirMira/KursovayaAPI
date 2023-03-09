using CinemaApiADO.Models.HallsTypes.Blank;

namespace CinemaApiADO.Models.HallsTypes.DB;

public class HallTypeDB
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public static HallTypeDB Convert(HallTypeBlank halltypelank)
    {
        return new HallTypeDB()
        {
            Name = halltypelank.Name
        };
    } 
    public static HallTypeDB Convert(int companyId ,HallTypeBlank halltypelank)
    {
        return new HallTypeDB()
        {
            Id = companyId,
            Name = halltypelank.Name
        };
    }
}