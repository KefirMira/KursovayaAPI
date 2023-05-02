using CinemaApiADO.Models.Companies.Blank;
using CinemaApiADO.Models.Films.Blank;
using CinemaApiADO.Models.Films.DB;
using CinemaApiADO.Models.Films.Domain;
using CinemaApiADO.Models.Genres.Blank;
using CinemaApiADO.Models.Halls.Blank;
using CinemaApiADO.Models.Halls.DB;
using CinemaApiADO.Models.Halls.Domain;
using CinemaApiADO.Models.HallsTypes.Blank;
using CinemaApiADO.Models.HallsTypes.Domain;

namespace CinemaApiAdo.Services.Halls;

public class HallService:IHallService
{
    private readonly HallRepository _repository;

    public HallService()
    {
        _repository = new HallRepository();
    }
    public bool CreateHall(HallBlank hall)
    {
        try
        {
            HallDB newhall = HallDB.Convert(hall);
            _repository.CreateHall(newhall);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool DeleteHall(int hallId)
    {
        try
        {
            _repository.DeleteHall(hallId);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public IEnumerable<HallDomain> GetAllHall()
    {
        IEnumerable<HallDB> allhall = _repository.GetAllHall();
        List<HallDomain> allinfohall = new List<HallDomain>();
        foreach (var item in allhall)
        {
            HallTypeDomain halltypefilm = _repository.GetHallTypeFilm(item.Id);
            allinfohall.Add(HallDomain.Convert(item,halltypefilm));
        }
        return allinfohall;
    }
}