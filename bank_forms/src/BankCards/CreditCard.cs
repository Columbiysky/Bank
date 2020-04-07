using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace bank_forms.src.BankCards
{
    class CreditCard : ICard
    {
        [BsonId]
        public ObjectId CardID { get; set; }
        [BsonElement("Validity")]
        public string Validity { get; set; }

        [BsonElement("Percent")]
        public int Percent { get; set; }

        [BsonElement("MaximumLimit")]
        public int MaximumLimit { get; set; }

        [BsonElement("CardType")]
        public string CardType { get; set; }

        [BsonElement("CardNumber")]
        public int CardNumber { get; set; }

        [BsonElement("CVV")]
        public int CVV { get; set; }

        public CreditCard(ObjectId cardId, string validity, int cardNumber, int cvvCode, int percent = 0, int maxLimit = 0)
        {
            CardID = cardId;
            Validity = validity;
            CardNumber = cardNumber;
            CVV = cvvCode;
            Percent = percent;
            MaximumLimit = maxLimit;
            CardType = "Кредитная карта";
        }
    }
}
