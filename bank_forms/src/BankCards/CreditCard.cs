using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace bank_forms.src.BankCards
{
    class CreditCard : ICard
    {
        [BsonId]
        public ObjectId CardID { get; set; }

        [BsonElement("Balance")]
        public decimal Balance { get; set; }

        [BsonElement("Validity")]
        public string Validity { get; set; }

        [BsonElement("Percent")]
        public double Percent { get; set; }

        [BsonElement("MaximumLimit")]
        public int MaximumLimit { get; set; }

        [BsonElement("CardType")]
        public string CardType { get; set; }

        [BsonElement("CardNumber")]
        public long CardNumber { get; set; }

        [BsonElement("CVV")]
        public string CVV { get; set; }

        public CreditCard(ObjectId cardId, decimal balance, string validity, long cardNumber, string cvvCode, double percent = 0, int maxLimit = 0)
        {
            CardID = cardId;
            Balance = balance;
            Validity = validity;
            CardNumber = cardNumber;
            CVV = cvvCode;
            Percent = percent;
            MaximumLimit = maxLimit;
            CardType = "Кредитная карта";
        }
    }
}
