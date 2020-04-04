using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace bank_forms
{
    class Client : IClient //класс клиента, наследованный от интерфейса
    {
        public virtual ObjectId client_id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public virtual string Login { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public virtual string Password { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public virtual string Surname { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public virtual string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public virtual string Second_name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public virtual int INN { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public virtual long Phone { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
