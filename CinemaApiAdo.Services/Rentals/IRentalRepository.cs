using CinemaApiADO.Models.Halls.DB;
using CinemaApiADO.Models.Rentals.DB;
using CinemaApiADO.Models.Rentals.Domain;

namespace CinemaApiAdo.Services.Rentals;

public interface IRentalRepository
{
    //void CreateRental(RentalDB rental);
    void CreateRental(RentalDomain rental);
    void DeleteRental(int rentalId);
    IEnumerable<RentalDB> GetAllRental();
}