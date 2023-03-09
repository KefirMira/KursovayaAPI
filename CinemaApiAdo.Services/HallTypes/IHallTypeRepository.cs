using CinemaApiADO.Models.HallsTypes.DB;

namespace CinemaApiAdo.Services.HallTypes;

public interface IHallTypeRepository
{
    IEnumerable<HallTypeDB> GetAllHallType();
    void CreateHallType(HallTypeDB hallTypeDb);
    void UpdateHallType(HallTypeDB hallTypeDb);
    void DeleteHallType(int hallTypeId);
}