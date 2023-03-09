using CinemaApiADO.Models.Halls.DB;
using CinemaApiADO.Models.Rentals.DB;

namespace CinemaApiAdo.Services.Rentals;

public interface IRentalRepository
{
    void CreateRental(RentalDB rental);
    void DeleteRental(int rentalId);
    IEnumerable<RentalDB> GetAllRental();
}