using CinemaApiADO.Models.Companies.Blank;
using CinemaApiADO.Models.Companies.Domain;

namespace CinemaApiAdo.Services.Companies;

public interface ICompanyService
{
    bool CreateCompany(CompanyBlank companyBlank);
    bool UpdateCompany(int companyId,CompanyBlank company);
    bool DeleteCompany(int companyId);
    CompanyDomain GetCompany(int companyId);
    IEnumerable<CompanyDomain> GetAllCompanies();
}