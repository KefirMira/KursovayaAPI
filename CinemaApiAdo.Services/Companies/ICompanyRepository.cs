using CinemaApiADO.Models.Companies.DB;

namespace CinemaApiAdo.Services.Companies;

public interface ICompanyRepository
{
    bool CreateCompany(CompanyDB companyBlank);
    bool UpdateCompany(int companyId,CompanyDB company);
    bool DeleteCompany(int companyId);
    CompanyDB GetCompany(int companyId);
    IEnumerable<CompanyDB> GetAllCompanies();
}