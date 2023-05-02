using CinemaApiADO.Models.Halls.Domain;
using CinemaApiADO.Models.Rentals.Blank;
using CinemaApiADO.Models.Rentals.Domain;

namespace CinemaApiAdo.Services.Rentals;

public interface IRentalService
{
    void CreateRental(RentalDomain rental);
    void DeleteRental(int rentalId);
    IEnumerable<RentalDomain> GetAllRental();
}