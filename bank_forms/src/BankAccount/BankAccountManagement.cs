using bank_forms.src.BankCards;
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
        /// Создать новый банковский аккаунт
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

        /// <summary>
        /// Добавить существующую карту клиенту 
        /// </summary>
        /// <param name="connection"> Подключение к БД</param>
        /// <param name="client"> Клиент </param>
        /// <param name="card"> Карта </param>
        public static void AddCardToClient(MongoClient connection, IClient client, ICard card)
        {
            var database = connection.GetDatabase("bank");
            var collection = database.GetCollection<BsonDocument>("users_cards");

            var recordId = ObjectId.GenerateNewId();

            BsonDocument clientCard = new BsonDocument
            {
                { "_id", recordId },
                { "clientId", client.client_id64 },
                { "cardId", card.CardID }
            };

            collection.InsertOne(clientCard);
        }

        /// <summary>
        /// Создать дебетовую карту и добавить к пользователю
        /// </summary>
        /// <param name="client"> Подключение к БД </param>
        /// <param name="user"> Клиент </param>
        /// <param name="validity"> Валидность карты (до какого числа) </param>
        public static void CreateDebitCardForClient(MongoClient client, IClient user, string validity)
        {
            var database = client.GetDatabase("bank");
            var collection = database.GetCollection<BsonDocument>("users_cards");

            var debitCard = CardManagement.CreateDebitCard(client, validity);

            var recordId = ObjectId.GenerateNewId();

            BsonDocument clientDebitCard = new BsonDocument
            {
                { "_id", recordId },
                { "clientId", user.client_id64 },
                { "cardId", debitCard.CardID }
            };

            collection.InsertOne(clientDebitCard);
        }

        public static void CreateCreditCardForClient(MongoClient client, IClient user, string validity, double percent = 0, int maxLimit = 0)
        {
            var database = client.GetDatabase("bank");
            var collection = database.GetCollection<BsonDocument>("users_cards");

            var creditCard = CardManagement.CreateDebitCard(client, validity);

            var recordId = ObjectId.GenerateNewId();

            BsonDocument clientCreditCard = new BsonDocument
            {
                { "_id", recordId },
                { "clientId", user.client_id64 },
                { "cardId", creditCard.CardID }
            };

            collection.InsertOne(clientCreditCard);
        }
    }
}
