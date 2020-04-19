using bank_forms.src.BankClient;
using MongoDB.Bson;
using MongoDB.Driver;

namespace bank_forms.src.BankAccount
{
    public static class BankAccountManagement
    {
        /// <summary>
        /// Создаем новый банковский аккаунт и привязываем его к клиенту (добавляем в таблицу client_account)
        /// </summary>
        /// <param name="client"> connection чтобы к базе подключиться </param>
        /// <param name="user"> объект типа IClient </param>
        /// <param name="balance"> Начальный баланс аккаунта </param>
        /// <param name="startDate"> Дата активации аккаунта </param>
        /// <param name="finishDate"> До какого числа акк активен </param>
        /// <param name="isActive"> Активен акк или нет </param>
        /// <returns> Экземпляр класса ClientAccount </returns>
        public static ClientAccount CreateNewUserBankAccount(MongoClient client, IClient user, string accountType, int balance, string startDate, string finishDate, bool isActive)
        {
            var database = client.GetDatabase("bank");
            var collection = database.GetCollection<BsonDocument>("client_account");

            var userBankObjId = ObjectId.GenerateNewId();

            var account = CreateBankAccount(client, accountType, balance, startDate, finishDate, isActive);

            BsonDocument userBankAccount = new BsonDocument
            {
                { "_id", userBankObjId },
                { "clientId", user.client_id64 },
                { "bankAccId", account.IdBankAccount }
            };

            collection.InsertOne(userBankAccount);

            return new ClientAccount(userBankObjId, user, account);
        }

        /// <summary>
        /// Создаем новый банковский аккаунт
        /// </summary>
        /// <param name="client"> Connection чтобы в базу сразу добавить </param>
        /// <param name="accountType"> Тип аккаунта </param>
        /// <param name="balance"> Начальный баланс </param>
        /// <param name="startDate"> Дата открытия </param>
        /// <param name="finishDate"> Дата закрытия </param>
        /// <param name="isActive"> Активный или нет </param>
        /// <returns> Экземпляр класса BankAccounts </returns>
        private static BankAccounts CreateBankAccount
        (
            MongoClient client, 
            string accountType, 
            int balance, 
            string startDate, 
            string finishDate,
            bool isActive
        )
        {

            var database = client.GetDatabase("bank");
            var collection = database.GetCollection<BsonDocument>("bank_account");

            var bankAccId = ObjectId.GenerateNewId();

            BsonDocument bankAccount = new BsonDocument
            {
                { "_id", bankAccId },
                { "accountType", accountType },
                { "balance", balance },
                { "startDate", startDate },
                { "finishDate", finishDate },
                { "isActive", isActive }
            };

            collection.InsertOne(bankAccount);

            return new BankAccounts(bankAccId, accountType, balance, startDate, finishDate, isActive);
        }
    }
}
