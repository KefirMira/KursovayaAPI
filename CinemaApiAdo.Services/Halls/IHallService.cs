using CinemaApiADO.Models.Halls.Blank;
using CinemaApiADO.Models.Halls.Domain;

namespace CinemaApiAdo.Services.Halls;

public interface IHallService
{
    void CreateHall(HallBlank hall);
    void DeleteHall(int hallId);
    IEnumerable<HallDomain> GetAllHall();
}