using CinemaApiADO.Models.HallsTypes.DB;

namespace CinemaApiAdo.Services.HallTypes;

public interface IHallTypeRepository
{
    IEnumerable<HallTypeDB> GetAllHallType();
    bool CreateHallType(HallTypeDB hallTypeDb);
    bool UpdateHallType(HallTypeDB hallTypeDb);
    bool DeleteHallType(int hallTypeId);
}