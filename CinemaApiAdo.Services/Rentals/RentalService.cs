using CinemaApiADO.Models.Films.Blank;
using CinemaApiADO.Models.Films.Domain;
using CinemaApiADO.Models.Halls.DB;
using CinemaApiADO.Models.Halls.Domain;
using CinemaApiADO.Models.HallsTypes.Blank;
using CinemaApiADO.Models.Rentals.Blank;
using CinemaApiADO.Models.Rentals.DB;
using CinemaApiADO.Models.Rentals.Domain;

namespace CinemaApiAdo.Services.Rentals;

public class RentalService:IRentalService
{
    private readonly RentalRepository _repository;

    public RentalService()
    {
        _repository = new RentalRepository();
    }
    public void CreateRental(RentalDomain rental)
    {
        //RentalDB newrental = RentalDB.Convert(rental);
        //_repository.CreateRental(newrental);
        _repository.CreateRental(rental);
    }

    public void DeleteRental(int rentalId)
    {
        _repository.DeleteRental(rentalId);
    }

    public IEnumerable<RentalDomain> GetAllRental()
    {
        IEnumerable<RentalDB> allrental = _repository.GetAllRental();
        List<RentalDomain> allinforental = new List<RentalDomain>();
        foreach (var item in allrental)
        {
            FilmDomain film = _repository.GetFilm(item.Id);
            allinforental.Add(RentalDomain.Convert(item,film));
        }
        return allinforental;
    }
}