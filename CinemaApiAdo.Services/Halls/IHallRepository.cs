using CinemaApiADO.Models.Halls.DB;

namespace CinemaApiAdo.Services.Halls;

public interface IHallRepository
{
    bool CreateHall(HallDB hall);
    bool DeleteHall(int hallId);
    IEnumerable<HallDB> GetAllHall();
}