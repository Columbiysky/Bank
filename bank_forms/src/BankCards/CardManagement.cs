using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace bank_forms.src.BankCards
{
    public static class CardManagement
    {
        public static ICard CreateDebitCard(MongoClient client, string validity, int cardNumber, int cvvCode)
        {
            var database = client.GetDatabase("bank");
            var collection = database.GetCollection<BsonDocument>("card");

            var objId = ObjectId.GenerateNewId();

            BsonDocument debitCard = new BsonDocument
            {
                { "_id", objId },
                { "Validity", validity },
                { "Percent", 0 },
                { "MaximumLimit",  0 },
                { "CardType", "Дебетовая карта" },
                { "CardNumber", cardNumber },
                { "CVV", cvvCode }
            };

            collection.InsertOne(debitCard);

            return new DebitCard(objId, validity, cardNumber, cvvCode);
        }

        public static ICard CreateCreditCard
        (
            MongoClient client, 
            string validity, 
            int cardNumber,
            int cvvCode,
            int percent = 0, 
            int maxLimit = 0, 
            string cardType = "Кредитная карта"
        )
        {
            var database = client.GetDatabase("bank");
            var collection = database.GetCollection<BsonDocument>("card");

            var objId = ObjectId.GenerateNewId();

            BsonDocument creditCard = new BsonDocument
            {
                { "_id", objId },
                { "Validity", validity },
                { "Percent", percent },
                { "MaximumLimit",  maxLimit },
                { "CardType", cardType },
                { "CardNumber", cardNumber },
                { "CVV", cvvCode }
            };

            collection.InsertOne(creditCard);

            return new CreditCard(objId, validity, cardNumber, cvvCode, percent, maxLimit);
        }

        private static int GanerateCardNumber()
        {
            throw new NotImplementedException();
        }

        private static int GenerateCVV()
        {
            Random cvv = new Random();
            cvv.Next(0, 999);
            throw new NotImplementedException();
        }
    }
}
