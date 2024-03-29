﻿using CinemaApiADO.Models.Clients.Blank;
using CinemaApiADO.Models.Clients.DB;
using CinemaApiADO.Models.Clients.Domain;
using CinemaApiADO.Models.Companies.Domain;

namespace CinemaApiAdo.Services.Clients;

public class ClientService: IClientService
{
    private readonly ClientRepository _repository;
    
    public ClientService()
    {
        _repository = new ClientRepository();
    }
    public bool CreateClient(ClientBlank companyBlank)
    {
        try
        {
            ClientDB client = ClientDB.Convert(companyBlank);
            _repository.CreateClient(client);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool UpdateClient(int companyId, ClientBlank company)
    {
        try
        {
            ClientDB update = ClientDB.Convert(company);
            _repository.UpdateClient(companyId, update);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool DeleteClient(int companyId)
    {
        try
        {
            _repository.DeleteClient(companyId);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public ClientDomain GetClient(int companyId)
    {
        ClientDB clientDB = _repository.GetClient(companyId);
        return ClientDomain.Convert(clientDB);
    }

    public IEnumerable<ClientDomain> GetAllClients()
    {
        IEnumerable<ClientDB> allclients = _repository.GetAllClients();
        return ClientDomain.Convert(allclients);
    }

    public ClientDomain GetClient(string login, string password)
    {
        ClientDB clientDB = _repository.GetClient(login, password);
        return ClientDomain.Convert(clientDB);
    }
}