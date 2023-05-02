using CinemaApiADO.Models.HallsTypes.Blank;
using CinemaApiADO.Models.HallsTypes.Domain;

namespace CinemaApiAdo.Services.HallTypes;

public interface IHallTypeService
{
    IEnumerable<HallTypeDomain> GetAllHallType();
    bool CreateHallType(HallTypeBlank hallTypeBlank);
    bool UpdateHallType(int halltypeId,HallTypeBlank hallTypeBlank);
    bool DeleteHallType(int halltypeId);
}