using CinemaApiADO.Models.Companies.DB;

namespace CinemaApiAdo.Services.Companies;

public interface ICompanyRepository
{
    void CreateCompany(CompanyDB companyBlank);
    void UpdateCompany(int companyId,CompanyDB company);
    void DeleteCompany(int companyId);
    CompanyDB GetCompany(int companyId);
    IEnumerable<CompanyDB> GetAllCompanies();
}