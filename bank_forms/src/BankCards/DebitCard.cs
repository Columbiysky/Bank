using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;

namespace bank_forms.src.BankCards
{
    class DebitCard : ICard
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

        public DebitCard(ObjectId cardId, string validity, int percent = 0, int maxLimit = 0, string cardType = "Дебетовая карта")
        {
            CardID = cardId;
            Validity = validity;
            Percent = percent;
            MaximumLimit = maxLimit;
            CardType = cardType;
        }
    }
}
