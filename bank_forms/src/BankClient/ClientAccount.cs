using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using bank_forms.src.BankAccount;
using bank_forms.src.BankCards;

namespace bank_forms.src.BankClient
{
    public class ClientAccount
    {
        [BsonId]
        public ObjectId ClientAccId { get; set; }

        [BsonElement("ClientId")]
        long ClientId { get; set; }

        [BsonElement("IdBankAccount")]
        public ObjectId IdBankAccount { get; set; }

        public ClientAccount(ObjectId clientAccId, IClient client, BankAccounts account)
        {
            ClientAccId = clientAccId;
            ClientId = client.client_id64;
            IdBankAccount = account.IdBankAccount;
        }
    }
}
