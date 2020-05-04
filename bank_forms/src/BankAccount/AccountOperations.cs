using bank_forms.src.DBConnection;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;

namespace bank_forms.src.BankAccount
{
    public class AccountOperations : IAccountOperations
    {
        public void TransferMoneyIDKWhere(IClient sender, string senderAccId, decimal mountAmount)
        {
            throw new NotImplementedException();
        }

        public void TransferMoneyToUserByNumber(IClient sender, string senderAccId, long phoneNumber, decimal moneyAmount)
        {
            // тут может вылететь эксепшен, CAREFUL!!!
            long recieverId = FindUserByNumber(DBConnect.GetConnection(), phoneNumber);

            decimal senderCash = 0;
            string senderBankAccId = "";

            var database = DBConnect.GetConnection().GetDatabase("bank");
            var collectionClientAcc = database.GetCollection<BsonDocument>("client_account");
            var collectionBankAcc = database.GetCollection<BsonDocument>("bank_account");

            // красиво блять написал... крч ищем в базе челика, который отдает грiвни
            var filterSenderMoney = new BsonDocument("clientId", sender.client_id64);
            var cursor = collectionClientAcc.FindSync<BsonDocument>(filterSenderMoney);

            // мб чет неправильно делаю, но работает, так что в пизду..
            while (cursor.MoveNext())
            {
                var clients = cursor.Current;

                foreach (var user in clients)
                {
                    
                }
            }

        }

        /// <summary>
        /// Поиск пользователя в БД по номеру телефона
        /// </summary>
        /// <param name="client"> Коннекшн к базе </param>
        /// <param name="phoneNumber"> Номер телефона </param>
        /// <returns> ID пользователя, если таковой есть </returns>
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
                    // хз что сделать, на пхй кину простой эксепшен!
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
