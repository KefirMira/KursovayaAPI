using CinemaApiADO.Models.Films.Blank;
using CinemaApiADO.Models.Films.Domain;
using CinemaApiADO.Models.Rentals.Domain;

namespace CinemaApiADO.Models.Rentals.View;

public class RentalView
{
    public int Id { get; set; } 
    public DateTime ShowStartDate { get; set; }
    public DateTime  DateOfWithDrawal { get; set; }
    public FilmDomain Films { get; set; }
    public static RentalView Convert(RentalDomain rentalDomain)
    {
        return new RentalView()
        {
            Id = rentalDomain.Id,
            ShowStartDate = rentalDomain.ShowStartDate,
            DateOfWithDrawal = rentalDomain.DateOfWithDrawal,
            Films = rentalDomain.Films
        };
    }

    public static IEnumerable<RentalView> Convert(IEnumerable<RentalDomain> dbs)
    {
        return dbs.Select(Convert);
    }
}