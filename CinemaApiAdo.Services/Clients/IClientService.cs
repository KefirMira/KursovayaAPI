using CinemaApiADO.Models.Clients.Blank;
using CinemaApiADO.Models.Clients.Domain;

namespace CinemaApiAdo.Services.Clients;

public interface IClientService
{
    bool CreateClient(ClientBlank companyBlank);
    void UpdateClient(int companyId,ClientBlank company);
    void DeleteClient(int companyId);
    ClientDomain GetClient(int companyId);
    IEnumerable<ClientDomain> GetAllClients();
    ClientDomain GetClient(string login, string password);
}