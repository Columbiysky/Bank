using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace bank_forms.src.BankAccount
{
    class BankAccount
    {
        [BsonId]
        public ObjectId IdBankAccount { get; set; }

        [BsonElement("Balance")]
        public int Balance { get; set; }

        [BsonElement("StartDate")]
        public string Startdate { get; set; }

        [BsonElement("FinishDate")]
        public string FinishDate { get; set; }

        [BsonElement("IsActive")]
        public bool IsActive { get; set; }
    }
}
