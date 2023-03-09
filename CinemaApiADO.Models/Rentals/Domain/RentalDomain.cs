using CinemaApiADO.Models.Films.Blank;
using CinemaApiADO.Models.Rentals.Blank;
using CinemaApiADO.Models.Rentals.DB;

namespace CinemaApiADO.Models.Rentals.Domain;

public class RentalDomain
{
    public int Id { get; set; } 
    public DateTime ShowStartDate { get; set; }
    public DateTime  DateOfWithDrawal { get; set; }
    public FilmBlank Films { get; set; }
    public static RentalDomain Convert(RentalDB rentalDb)
    {
        return new RentalDomain()
        {
            Id = rentalDb.Id,
            ShowStartDate = rentalDb.ShowStartDate,
            DateOfWithDrawal = rentalDb.DateOfWithDrawal
        };
    }
    public static RentalDomain Convert(RentalDB rentalDb, FilmBlank filmBlanks)
    {
        return new RentalDomain()
        {
            Id = rentalDb.Id,
            ShowStartDate = rentalDb.ShowStartDate,
            DateOfWithDrawal = rentalDb.DateOfWithDrawal,
            Films = filmBlanks
        };
    }

    public static IEnumerable<RentalDomain> Convert(IEnumerable<RentalDB> dbs)
    {
        return dbs.Select(Convert);
    }
}