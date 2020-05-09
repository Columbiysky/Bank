using bank_forms.src.DBConnection;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;

namespace bank_forms.src.BankAccount
{
    public class AccountOperations
    {
        public void TransferMoneyIDKWhere(IClient sender, string senderAccId, decimal mountAmount)
        {
            throw new NotImplementedException();
        }

        public void TransferMoneyToUserByNumber(IClient sender, string senderAccId, long phoneNumber, decimal moneyAmount)
        {
            var userBankAccId = BankAccountManagement.GetUserBankAccId(senderAccId);

            // тут может вылететь эксепшен, CAREFUL!!!
            long recieverId = FindUserByNumber(DBConnect.GetConnection(), phoneNumber);

            decimal senderCash = 0;

            var database = DBConnect.GetConnection().GetDatabase("bank");
            var collection = database.GetCollection<BsonDocument>("bank_account");

            // надо найти крч баланс аккаунта выбранного счета клиента (у него может быть несколько счетов
            // но на один счет приходится лишь один банковский аккаунт)
            var filter = new BsonDocument("_id", new ObjectId(userBankAccId));
            var cursor = collection.FindSync<BsonDocument>(filter);

            // мб чет неправильно делаю, но работает, так что в пизду..
            while (cursor.MoveNext())
            {
                var accounts = cursor.Current;

                foreach (var account in accounts)
                {
                    // запомним изначальный баланс
                    senderCash = decimal.Parse(account.GetValue("balance").ToString());
                    // обновим таблицу в бд вычев из баланса сумму, которую клиент переводит другому клиенту
                    collection.UpdateOne
                    (
                        new BsonDocument("_id", new ObjectId(userBankAccId)), 
                        new BsonDocument("$set", new BsonDocument("balance", senderCash - moneyAmount))
                    );
                }
            }


        }

        //public static void TransferMoneyFromCardToUser()

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
                        recieverId = long.Parse(user.GetValue("_id").ToString());
                    }
                }
            }

            return recieverId;
        }
    }
}
