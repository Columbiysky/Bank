using bank_forms.src.DBConnection;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;

namespace bank_forms.src.BankAccount
{
    public class AccountOperations : IAccountOperations
    {
        public void TransferMoneyIDKWhere(IClient sender, decimal mountAmount)
        {
            throw new NotImplementedException();
        }

        public void TransferMoneyToUserByNumber(IClient sender, long phoneNumber, decimal moneyAmount)
        {
            /*
            var recieverId = FindUserByNumber(DBConnect.GetConnection(), phoneNumber);

            var senderCash = 0;

            var database = DBConnect.GetConnection().GetDatabase("bank");
            var collection = database.GetCollection<BsonDocument>("client_account");

            // красиво блять написал... крч ищем в базе челика, который отдает грiвни
            var filter = new BsonDocument("$and", new BsonArray
            {
                new BsonDocument()
            }

            var cursor = collection.FindSync<BsonDocument>(filter);

            // мб чет неправильно делаю, но работает, так что в пизду..
            while (cursor.MoveNext())
            {
                var clients = cursor.Current;

                foreach (var user in clients)
                {
                    senderCash = user.GetValue()
                }
            }
            */

        }

        private long FindUserByNumber(MongoClient client, long phoneNumber)
        {
            long recieverId = -1;

            var filter = new BsonDocument("Phone", phoneNumber);

            var database = client.GetDatabase("bank");
            var collection = database.GetCollection<BsonDocument>("clients");

            var recordId = ObjectId.GenerateNewId();

            // ищем челика в таблице Clients
            var cursor = collection.FindSync(filter);
            while (cursor.MoveNext())
            {
                var clients = cursor.Current;
                if (clients.Count() == 0)
                {
                    throw new Exception("Клиентов с таким номеро телефона нет");
                }
                else
                {
                    foreach (var user in clients)
                    {
                        recieverId = long.Parse(user.GetValue("Phone").ToString());
                    }
                }
            }

            return recieverId;
        }
    }
}
