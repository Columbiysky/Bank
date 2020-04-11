using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace bank_forms.src.BankClient
{
    public class ClientAccount
    {
        [BsonId]
        public ObjectId BankAccountId { get; set; }

        [BsonElement("ClientId")]
        IClient ClientId { get; set; }

        [BsonElement("IdBankAccount")]
        public ObjectId IdBankAccount { get; set; }

        //public BankAccount CreateAccount(IClient login)
        //{
        //    return new BankAccount();
        //}
    }
}
