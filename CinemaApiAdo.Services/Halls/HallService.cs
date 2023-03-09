using CinemaApiADO.Models.Companies.Blank;
using CinemaApiADO.Models.Films.Blank;
using CinemaApiADO.Models.Films.DB;
using CinemaApiADO.Models.Films.Domain;
using CinemaApiADO.Models.Genres.Blank;
using CinemaApiADO.Models.Halls.Blank;
using CinemaApiADO.Models.Halls.DB;
using CinemaApiADO.Models.Halls.Domain;
using CinemaApiADO.Models.HallsTypes.Blank;

namespace CinemaApiAdo.Services.Halls;

public class HallService:IHallService
{
    private readonly HallRepository _repository;

    public HallService()
    {
        _repository = new HallRepository();
    }
    public void CreateHall(HallBlank hall)
    {
        HallDB newhall = HallDB.Convert(hall);
        _repository.CreateHall(newhall);
    }

    public void DeleteHall(int hallId)
    {
        _repository.DeleteHall(hallId);
    }

    public IEnumerable<HallDomain> GetAllHall()
    {
        IEnumerable<HallDB> allhall = _repository.GetAllHall();
        List<HallDomain> allinfohall = new List<HallDomain>();
        foreach (var item in allhall)
        {
            HallTypeBlank halltypefilm = _repository.GetHallTypeFilm(item.Id);
            allinfohall.Add(HallDomain.Convert(item,halltypefilm));
        }
        return allinfohall;
    }
}