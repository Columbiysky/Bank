using bank_forms.src.DBConnection;
using MongoDB.Bson;

namespace bank_forms.src.Operations
{
    public static class OperationsRecorder
    {
        public static void RecordAccountOperation(string userAccId, string operationDate, string transactionTime, string type, decimal sum)
        {
            var client = DBConnect.GetConnection();
            var database = client.GetDatabase("bank");
            var collection = database.GetCollection<BsonDocument>("operations");

            var operationObjId = ObjectId.GenerateNewId();

            BsonDocument operation = new BsonDocument
            {
                { "_id", operationObjId },
                { "OperationDate", operationDate },
                { "TransactionTime", transactionTime },
                { "Type", type },
                { "Sum", sum }
            };

            collection.InsertOne(operation);

            collection = database.GetCollection<BsonDocument>("account_operations");

            var accOperationsObjId = ObjectId.GenerateNewId();

            BsonDocument accountOperation = new BsonDocument
            {
                { "_id", accOperationsObjId },
                { "operationId", operationObjId },
                { "bankAccId", new ObjectId(userAccId) }
            };

            collection.InsertOne(accountOperation);
        }

        public static void RecordCardOperation(string userCardId, string operationDate, string transactionTime, string type, decimal sum)
        {
            var client = DBConnect.GetConnection();
            var database = client.GetDatabase("bank");
            var collection = database.GetCollection<BsonDocument>("operations");

            var operationObjId = ObjectId.GenerateNewId();

            BsonDocument operation = new BsonDocument
            {
                { "_id", operationObjId },
                { "OperationDate", operationDate },
                { "TransactionTime", transactionTime },
                { "Type", type },
                { "Sum", sum }
            };

            collection.InsertOne(operation);

            collection = database.GetCollection<BsonDocument>("card_operations");

            var cardOperationObjId = ObjectId.GenerateNewId();

            BsonDocument cardOperation = new BsonDocument
            {
                { "_id", cardOperationObjId },
                { "operationId", operationObjId },
                { "clientCardId", new ObjectId(userCardId) }
            };

            collection.InsertOne(cardOperation);
        }
    }
}