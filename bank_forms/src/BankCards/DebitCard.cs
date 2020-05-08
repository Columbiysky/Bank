using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace bank_forms.src.BankCards
{
    public class DebitCard : ICard
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

        public DebitCard(ObjectId cardId, decimal balance, string validity, long cardNumber, string cvvCode)
        {
            CardID = cardId;
            Balance = balance;
            Validity = validity;
            Percent = 0;
            MaximumLimit = 0;
            CardType = "Дебетовая карта";
            CardNumber = cardNumber;
            CVV = cvvCode;
        }
    }
}
