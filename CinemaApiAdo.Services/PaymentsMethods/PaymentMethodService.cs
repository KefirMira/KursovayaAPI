using CinemaApiADO.Models.PaymentsMethods.DB;
using CinemaApiADO.Models.PaymentsMethods.Domain;

namespace CinemaApiAdo.Services.PaymentsMethods;

public class PaymentMethodService:IPaymentMethodService
{
    private readonly PaymentMethodRepository _repository;
    public PaymentMethodService()
    {
        _repository = new PaymentMethodRepository();
    }
    public IEnumerable<PaymentsMethodsDomain> GetAllPaymentMethod()
    {
        IEnumerable<PaymentsMethodsDB> allPayment = _repository.GetAllPaymentMethod();
        return PaymentsMethodsDomain.Convert(allPayment);
    }
}