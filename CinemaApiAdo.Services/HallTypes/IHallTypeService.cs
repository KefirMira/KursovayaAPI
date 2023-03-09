using CinemaApiADO.Models.HallsTypes.Blank;
using CinemaApiADO.Models.HallsTypes.Domain;

namespace CinemaApiAdo.Services.HallTypes;

public interface IHallTypeService
{
    IEnumerable<HallTypeDomain> GetAllHallType();
    void CreateHallType(HallTypeBlank hallTypeBlank);
    void UpdateHallType(int halltypeId,HallTypeBlank hallTypeBlank);
    void DeleteHallType(int halltypeId);
}