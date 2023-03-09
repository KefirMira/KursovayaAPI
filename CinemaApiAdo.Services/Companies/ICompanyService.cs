using CinemaApiADO.Models.Companies.Blank;
using CinemaApiADO.Models.Companies.Domain;

namespace CinemaApiAdo.Services.Companies;

public interface ICompanyService
{
    void CreateCompany(CompanyBlank companyBlank);
    void UpdateCompany(int companyId,CompanyBlank company);
    void DeleteCompany(int companyId);
    CompanyDomain GetCompany(int companyId);
    IEnumerable<CompanyDomain> GetAllCompanies();
}