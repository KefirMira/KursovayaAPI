using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaApiADO.Models.PaymentsMethods.Domain;
using CinemaApiADO.Models.PaymentsMethods.View;
using CinemaApiADO.Models.SessionsTypes.Domain;
using CinemaApiADO.Models.SessionsTypes.View;
using CinemaApiAdo.Services.PaymentsMethods;
using CinemaApiAdo.Services.SessionsTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApiADO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsMethodsController : ControllerBase
    {        
        private readonly ILogger<PaymentsMethodsController> _logger;
        private readonly IPaymentMethodService _payService;
        public PaymentsMethodsController(ILogger<PaymentsMethodsController> logger, IPaymentMethodService payService)
        {
            _logger = logger;
            _payService = payService;
        }

        [HttpGet("all")]
        public IEnumerable<PaymentsMethodsView> GetAll()
        {
            IEnumerable<PaymentsMethodsDomain> paydomain = _payService.GetAllPaymentMethod();
            return PaymentsMethodsView.Convert(paydomain);
        }
    }
}
