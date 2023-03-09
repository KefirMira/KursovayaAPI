using CinemaApiADO.Models.Halls.DB;

namespace CinemaApiAdo.Services.Halls;

public interface IHallRepository
{
    void CreateHall(HallDB hall);
    void DeleteHall(int hallId);
    IEnumerable<HallDB> GetAllHall();
}