using MongoDB.Bson;
using MongoDB.Driver;

namespace bank_forms.src.BankCards
{
    class CardManagment
    {
        public ICard CreateDebitCard(MongoClient client, string validity, int percent = 0, int maxLimit = 0, string cardType = "Дебетовая карта")
        {
            var database = client.GetDatabase("bank");
            var collection = database.GetCollection<BsonDocument>("card");

            var objId = ObjectId.GenerateNewId();

            BsonDocument debitCard = new BsonDocument
            {
                { "_id",  objId },
                { "Validity", validity },
                { "Percent", percent },
                { "MaximumLimit",  maxLimit },
                { "CardType", cardType }
            };

            collection.InsertOne(debitCard);

            System.Console.WriteLine(objId);

            return new DebitCard(objId, validity, percent, maxLimit, cardType);
        }
    }
}
