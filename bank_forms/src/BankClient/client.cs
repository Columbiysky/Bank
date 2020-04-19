using MongoDB.Bson;

namespace bank_forms
{
    public class Client : IClient //класс клиента, наследованный от интерфейса
    {
        public virtual ObjectId client_id { get; set; }
        public virtual long client_id64 { get; set; }
        public virtual string Login { get; set; }
        public virtual string Password { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Name { get; set; }
        public virtual string Second_name { get; set; }
        public virtual long INN { get; set; }
        public virtual long Phone { get; set; }
    }
}
