using CinemaApiADO.Models.PaymentsMethods.Blank;

namespace CinemaApiADO.Models.PaymentsMethods.DB;

public class PaymentsMethodsDB
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public static PaymentsMethodsDB Convert(PaymentsMethodsBlank companylank)
    {
        return new PaymentsMethodsDB()
        {
            Name = companylank.Name
        };
    } 
    public static PaymentsMethodsDB Convert(int companyId ,PaymentsMethodsBlank companyblank)
    {
        return new PaymentsMethodsDB()
        {
            Id = companyId,
            Name = companyblank.Name
        };
    }
}