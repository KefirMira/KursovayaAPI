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
    
    public bool CreateCompany(CompanyBlank companyBlank)
    {
        try
        {
            CompanyDB newCompany = CompanyDB.Convert(companyBlank);
            _repository.CreateCompany(newCompany);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool UpdateCompany(int companyId, CompanyBlank company)
    {
        try
        {CompanyDB updateCompany = CompanyDB.Convert(company);
                 _repository.UpdateCompany(companyId,updateCompany);
                 return true;
        }
        catch
        {
            return false;
        }
        
    }

    public bool DeleteCompany(int companyId)
    {
        try
        {
            _repository.DeleteCompany(companyId);
            return true;
        }
        catch
        {
            return false;
        }
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