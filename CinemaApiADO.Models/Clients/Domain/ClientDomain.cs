using CinemaApiADO.Models.Clients.DB;

namespace CinemaApiADO.Models.Clients.Domain;

public class ClientDomain
{
    public  int Id { get; private set; }
    public string Surname { get;private set; } 
    public string Name { get;private set; } 
    public string Patronymic { get;private set; } 
    public string Login { get;private set; } 
    public string Password { get;private set; } 
    public string Telephone { get;private set; } 
    public string Mail { get;private set; } 
    public int Discount { get;private set; }

    public static ClientDomain Convert(ClientDB clientDB)
    {
        return new ClientDomain()
        {
            Id = clientDB.Id,
            Surname = clientDB.Surname,
            Name = clientDB.Name,
            Patronymic = clientDB.Patronymic,
            Login = clientDB.Login,
            Password = clientDB.Password,
            Telephone = clientDB.Telephone,
            Mail = clientDB.Mail,
            Discount = clientDB.Discount
        };
    }

    public static IEnumerable<ClientDomain> Convert(IEnumerable<ClientDB> dbs)
    {
        return dbs.Select(Convert);
    }
}