using CinemaApiADO.Models.Companies.Blank;
using CinemaApiADO.Models.Companies.DB;
using CinemaApiADO.Models.Companies.Domain;
using CinemaApiADO.Models.Genres.DB;

namespace CinemaApiAdo.Services.Companies;

public class CompanyService: ICompanyService
{
    private readonly CompanyRepository _repository;
    
    public CompanyService()
    {
        _repository = new CompanyRepository();
    }
    
    public void CreateCompany(CompanyBlank companyBlank)
    {
        CompanyDB newCompany = CompanyDB.Convert(companyBlank);
        _repository.CreateCompany(newCompany);
    }

    public void UpdateCompany(int companyId, CompanyBlank company)
    {
        CompanyDB updateCompany = CompanyDB.Convert(company);
        _repository.UpdateCompany(companyId,updateCompany);
    }

    public void DeleteCompany(int companyId)
    {
        _repository.DeleteCompany(companyId);
    }

    public CompanyDomain GetCompany(int companyId)
    {
        CompanyDB companyDB = _repository.GetCompany(companyId);
        return CompanyDomain.Convert(companyDB);
    }

    public IEnumerable<CompanyDomain> GetAllCompanies()
    {
        IEnumerable<CompanyDB> allcompanies = _repository.GetAllCompanies();
        return CompanyDomain.Convert(allcompanies);
    }
}