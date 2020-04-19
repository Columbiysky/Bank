using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace bank_forms.src.BankAccount
{
    public class BankAccounts
    {
        [BsonId]
        public ObjectId IdBankAccount { get; set; }

        [BsonElement("AccountType")]
        public string AccountType { get; set; }

        [BsonElement("Balance")]
        public int Balance { get; set; }

        [BsonElement("StartDate")]
        public string Startdate { get; set; }

        [BsonElement("FinishDate")]
        public string FinishDate { get; set; }

        [BsonElement("IsActive")]
        public bool IsActive { get; set; }

        public BankAccounts(ObjectId idBankAccount, string accountType, int balance, string startDate, string finishDate, bool isActive)
        {
            IdBankAccount = idBankAccount;
            AccountType = accountType;
            Balance = balance;
            Startdate = startDate;
            FinishDate = finishDate;
            IsActive = isActive;
        }
    }
}
