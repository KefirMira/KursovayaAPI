using CinemaApiADO.Models.Rentals.Blank;

namespace CinemaApiADO.Models.Rentals.DB;

public class RentalDB
{
    public int Id { get; set; } 
    public DateTime ShowStartDate { get; set; }
    public DateTime  DateOfWithDrawal { get; set; }

    public static RentalDB Convert(RentalBlank rentalBlank)
    {
        return new RentalDB()
        {
            ShowStartDate = rentalBlank.ShowStartDate,
            DateOfWithDrawal = rentalBlank.DateOfWithDrawal
        };
    }
    public static RentalDB Convert(int rentalId,RentalBlank rentalBlank)
    {
        return new RentalDB()
        {
            Id = rentalId,
            ShowStartDate = rentalBlank.ShowStartDate,
            DateOfWithDrawal = rentalBlank.DateOfWithDrawal
        };
    }
}