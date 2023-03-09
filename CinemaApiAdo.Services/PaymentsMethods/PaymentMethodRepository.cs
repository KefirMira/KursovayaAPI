using CinemaApiADO.Models.PaymentsMethods.Blank;
using CinemaApiADO.Models.PaymentsMethods.DB;
using CinemaApiADO.Models.SessionsTypes.Blank;
using CinemaApiADO.Models.SessionsTypes.DB;
using Npgsql;

namespace CinemaApiAdo.Services.PaymentsMethods;

public class PaymentMethodRepository:IPaymentMethodRepository
{
    private string connectionString = "Host = localhost; Database = cinemadb; User ID = postgres; Password= vjnbkmlff2004";
    private NpgsqlConnection _connection;
    public PaymentMethodRepository()
    {
        _connection = new NpgsqlConnection(connectionString);
    }
    public IEnumerable<PaymentsMethodsDB> GetAllPaymentMethod()
    {    
        _connection.Open();
        NpgsqlCommand command = new NpgsqlCommand("select * from payment_method",_connection);
        NpgsqlDataReader reader = command.ExecuteReader();
        List<PaymentsMethodsDB> paymentDbs = new List<PaymentsMethodsDB>();
        while (reader.Read())
        {
            paymentDbs.Add(PaymentsMethodsDB.Convert(Convert.ToInt32(reader["id"]),new PaymentsMethodsBlank()
            {
                Name = reader["name"].ToString()
            }));
        }
        _connection.Close();        
        return paymentDbs;   
    }
}