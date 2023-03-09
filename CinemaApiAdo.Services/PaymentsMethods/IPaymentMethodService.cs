using CinemaApiADO.Models.PaymentsMethods.Domain;

namespace CinemaApiAdo.Services.PaymentsMethods;

public interface IPaymentMethodService
{
    IEnumerable<PaymentsMethodsDomain> GetAllPaymentMethod();   
}