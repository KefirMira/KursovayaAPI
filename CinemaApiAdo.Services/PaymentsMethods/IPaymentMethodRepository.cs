using CinemaApiADO.Models.PaymentsMethods.DB;

namespace CinemaApiAdo.Services.PaymentsMethods;

public interface IPaymentMethodRepository
{
    IEnumerable<PaymentsMethodsDB> GetAllPaymentMethod();
}