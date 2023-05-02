using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaApiADO.Models.Halls.Blank;
using CinemaApiADO.Models.Halls.Domain;
using CinemaApiADO.Models.Halls.View;
using CinemaApiADO.Models.Rentals.Blank;
using CinemaApiADO.Models.Rentals.Domain;
using CinemaApiADO.Models.Rentals.View;
using CinemaApiAdo.Services.Rentals;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApiADO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly ILogger<RentalsController> _logger;
        private readonly IRentalService _rentalService;

        public RentalsController(ILogger<RentalsController> logger, IRentalService rentalService)
        {
            _logger = logger;
            _rentalService = rentalService;
        }

        [HttpGet("all")]
        public IEnumerable<RentalView> GetAll()
        {
            IEnumerable<RentalDomain> hallDomains = _rentalService.GetAllRental();
            return RentalView.Convert(hallDomains);
        }

        [HttpPost("create")]
        public void Create([FromBody] RentalDomain newrental)
        {
            _rentalService.CreateRental(newrental);
        }

        [HttpPost("remove")]
        public void Delete(int rentalId)
        {
            _rentalService.DeleteRental(rentalId);
        }
    }
}
