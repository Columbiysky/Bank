using MongoDB.Bson;

namespace bank_forms
{
    public interface IClient //Интерфейс клиента, тут все само собой
    {
        ObjectId client_id { get; set; }
        long client_id64 { get; set; }
        string Login { get; set; }
        string Password { get; set; }
        string Surname { get; set; }
        string Name { get; set; }
        string Second_name { get; set; }
        long INN { get; set; }
        long Phone { get; set; }
    }
}
