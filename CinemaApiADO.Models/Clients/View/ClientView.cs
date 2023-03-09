using CinemaApiADO.Models.Clients.Domain;

namespace CinemaApiADO.Models.Clients.View;

public class ClientView
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
    public static ClientView Convert(ClientDomain clientDB)
    {
        return new ClientView()
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

    public static IEnumerable<ClientView> Convert(IEnumerable<ClientDomain> domains)
    {
        return domains.Select(Convert);
    }
}