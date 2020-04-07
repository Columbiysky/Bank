using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace bank_forms.src.BankCards
{
    public class DebitCard : ICard
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

        public DebitCard(ObjectId cardId, string validity, int cardNumber, int cvvCode)
        {
            CardID = cardId;
            Validity = validity;
            Percent = 0;
            MaximumLimit = 0;
            CardType = "Дебетовая карта";
            CardNumber = cardNumber;
            CVV = cvvCode;
        }
    }
}
