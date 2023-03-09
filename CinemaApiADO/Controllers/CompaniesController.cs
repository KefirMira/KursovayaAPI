using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaApiADO.Models.Companies.Blank;
using CinemaApiADO.Models.Companies.Domain;
using CinemaApiADO.Models.Companies.View;
using CinemaApiAdo.Services.Companies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApiADO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ILogger<CompaniesController> _logger;
        private readonly ICompanyService _companyService;
        public CompaniesController(ILogger<CompaniesController> logger, ICompanyService companyService)
        {
            _logger = logger;
            _companyService = companyService;
        }
        [HttpGet("all")]
        public IEnumerable<CompanyView> GetAll()
        {
            IEnumerable<CompanyDomain> companyDomains = _companyService.GetAllCompanies();
            return CompanyView.Convert(companyDomains);
        }

        [HttpGet("{companyId}")]
        public CompanyView Get(int companyId)
        {
            CompanyDomain selectedFilm = _companyService.GetCompany(companyId);
            return CompanyView.Convert(selectedFilm);
        }

        [HttpPost("create")]
        public void Create([FromBody] CompanyBlank companyBlank)
        {
            _companyService.CreateCompany(companyBlank);
        }

        [HttpPost("remove")]
        public void Delete(int companyId)
        {
            _companyService.DeleteCompany(companyId);
        }

        [HttpPost("update")]
        public void Update(int companyId, CompanyBlank companyBlank)
        {
            _companyService.UpdateCompany(companyId,companyBlank);
        }
    }
}
