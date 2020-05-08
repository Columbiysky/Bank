using bank_forms.src.BankCards;
using bank_forms.src.BankClient;
using bank_forms.src.DBConnection;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace bank_forms.src.BankAccount
{
    // я делаю говно...

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
        public static ClientAccount CreateUserBankAccount(MongoClient client, IClient user, string accountType, int balance, string startDate, string finishDate, bool isActive)
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
        /// Создать дебетовую карту и привязать к банковскому аккаунту
        /// </summary>
        /// <param name="client"> Подключение к БД </param>
        /// <param name="user"> Клиент </param>
        /// <param name="clientBankAccId"> ID клиентского аккаунта, к которому доавляем карту </param>
        /// <param name="validity"> Валидность карты (до какого числа) </param>
        public static void CreateDebitCardForClient(MongoClient client, IClient user, string clientBankAccId, string validity)
        {
            var database = client.GetDatabase("bank");
            var collection = database.GetCollection<BsonDocument>("users_cards");

            decimal balance = 0;

            var debitCard = CardManagement.CreateDebitCard(client, validity);

            var recordId = ObjectId.GenerateNewId();

            BsonDocument clientDebitCard = new BsonDocument
            {
                { "_id", recordId },
                { "clientBankAccountID", ObjectId.Parse(clientBankAccId) },
                { "cardId", debitCard.CardID }
            };

            collection.InsertOne(clientDebitCard);
        }

        /// <summary>
        /// Создать кредитную карту и привязать к банковскому аккаунту
        /// </summary>
        /// <param name="client"> Подключение к БД </param>
        /// <param name="user"> Пользователь </param>
        /// <param name="clientBankAccId"> ID клиентского аккаунта, к которому доавляем карту </param>
        /// <param name="validity"> Валидность карты (до какого числа) </param>
        /// <param name="percent"> Процент по карте </param>
        /// <param name="maxLimit"> Максимальнйы лимит карты </param>
        public static void CreateCreditCardForClient(MongoClient client, IClient user, string clientBankAccId, string validity, double percent = 0, int maxLimit = 0)
        {
            var database = client.GetDatabase("bank");
            var collection = database.GetCollection<BsonDocument>("users_cards");

            decimal balance = 0;

            var creditCard = CardManagement.CreateCreditCard(client, validity, percent, maxLimit);

            var recordId = ObjectId.GenerateNewId();

            BsonDocument clientCreditCard = new BsonDocument
            {
                { "_id", recordId },
                { "clientBankAccountID", ObjectId.Parse(clientBankAccId) },
                { "cardId", creditCard.CardID }
            };

            collection.InsertOne(clientCreditCard);
        }

        /// <summary>
        /// Получить список id всех банковских аккаунтов пользователя
        /// </summary>
        /// <param name="user"> IClient - нужный нам пользователь </param>
        /// <returns> Список id </returns>
        public static List<string> GetUserBankAccounts(IClient user)
        {
            List<string> userAccountsId = new List<string>();

            var client = DBConnect.GetConnection();
            var database = client.GetDatabase("bank");
            var collection = database.GetCollection<BsonDocument>("client_account");

            var filter = new BsonDocument("clientId", user.client_id64);
            var cursor = collection.FindSync(filter);

            while (cursor.MoveNext())
            {
                var accounts = cursor.Current;
                if (accounts.Count() == 0)
                {
                    throw new Exception("У данного клиента нет счетов");
                }
                else
                {
                    foreach (var account in accounts)
                    {
                        userAccountsId.Add(account.GetValue("_id").ToString());
                    }
                }
            }

            return userAccountsId;
        }

        /// <summary>
        /// Вернуть ID банковского аккаунта данного счета клиента
        /// </summary>
        /// <param name="userAccountId"> ID счета клиента </param>
        /// <returns> ID банковского аккаунта </returns>
        public static string GetUserBankAccId(string userAccountId)
        {
            string bankAccId = "";

            var client = DBConnect.GetConnection();
            var database = client.GetDatabase("bank");
            var collection = database.GetCollection<BsonDocument>("client_account");

            ObjectId objId = new ObjectId(userAccountId);

            var filter = new BsonDocument("_id", objId);
            var cursor = collection.FindSync(filter);

            while (cursor.MoveNext())
            {
                var accounts = cursor.Current;

                foreach (var account in accounts)
                {
                    bankAccId = account.GetValue("bankAccId").ToString();
                }
            }

            return bankAccId;
        }
    }
}
