using MongoDB.Bson;

namespace bank_forms
{
    public class Client : IClient //класс клиента, наследованный от интерфейса
    {
        public virtual ObjectId client_id { get /*=> throw new NotImplementedException()*/; set /*=> throw new NotImplementedException()*/; }
        public virtual long client_id64 { get /*=>throw new NotImplementedException()*/; set /*=> throw new NotImplementedException()*/; }
        public virtual string Login { get /*=> throw new NotImplementedException()*/; set /*=> throw new NotImplementedException()*/; }
        public virtual string Password { get /*=> throw new NotImplementedException()*/; set /*=> throw new NotImplementedException()*/; }
        public virtual string Surname { get /*=> throw new NotImplementedException()*/; set /*=> throw new NotImplementedException()*/; }
        public virtual string Name { get /*=> throw new NotImplementedException()*/; set /*=> throw new NotImplementedException()*/; }
        public virtual string Second_name { get /*=> throw new NotImplementedException()*/; set /*=> throw new NotImplementedException()*/; }
        public virtual long INN { get /*=> throw new NotImplementedException()*/; set /*=> throw new NotImplementedException()*/; }
        public virtual long Phone { get /*=> throw new NotImplementedException()*/; set /*=> throw new NotImplementedException()*/; }
    }
}
