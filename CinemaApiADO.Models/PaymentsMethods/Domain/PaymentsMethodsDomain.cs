using CinemaApiADO.Models.PaymentsMethods.DB;

namespace CinemaApiADO.Models.PaymentsMethods.Domain;

public class PaymentsMethodsDomain
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public static PaymentsMethodsDomain Convert(PaymentsMethodsDB companyDB)
    {
        return new PaymentsMethodsDomain()
        {
            Id = companyDB.Id,
            Name = companyDB.Name
        };
    }

    public static IEnumerable<PaymentsMethodsDomain> Convert(IEnumerable<PaymentsMethodsDB> dbs)
    {
        return dbs.Select(Convert);
    }
}