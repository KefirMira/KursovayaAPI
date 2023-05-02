using CinemaApiADO.Models.Halls.Blank;
using CinemaApiADO.Models.Halls.Domain;

namespace CinemaApiAdo.Services.Halls;

public interface IHallService
{
    bool CreateHall(HallBlank hall);
    bool DeleteHall(int hallId);
    IEnumerable<HallDomain> GetAllHall();
}