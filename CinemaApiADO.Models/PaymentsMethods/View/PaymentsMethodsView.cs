using CinemaApiADO.Models.PaymentsMethods.Domain;

namespace CinemaApiADO.Models.PaymentsMethods.View;

public class PaymentsMethodsView
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public static PaymentsMethodsView Convert(PaymentsMethodsDomain companyDomain)
    {
        return new PaymentsMethodsView()
        {
            Id = companyDomain.Id,
            Name = companyDomain.Name
        };
    }

    public static IEnumerable<PaymentsMethodsView> Convert(IEnumerable<PaymentsMethodsDomain> domains)
    {
        return domains.Select(Convert);
    }
}