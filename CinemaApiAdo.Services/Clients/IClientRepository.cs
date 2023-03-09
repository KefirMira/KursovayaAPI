using CinemaApiADO.Models.Clients.DB;

namespace CinemaApiAdo.Services.Clients;

public interface IClientRepository
{
    bool CreateClient(ClientDB clientBlank);
    void UpdateClient(int companyId,ClientDB company);
    void DeleteClient(int companyId);
    ClientDB GetClient(int companyId);
    IEnumerable<ClientDB> GetAllClients();
    ClientDB GetClient(string login, string password);
}