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
        /// <returns>  </returns>
        public static ObjectId CreateDebitCardForClient(MongoClient client, IClient user, string clientBankAccId, string validity)
        {
            var database = client.GetDatabase("bank");
            var collection = database.GetCollection<BsonDocument>("users_cards");

            var debitCard = CardManagement.CreateDebitCard(client, validity);

            var recordId = ObjectId.GenerateNewId();

            BsonDocument clientDebitCard = new BsonDocument
            {
                { "_id", recordId },
                { "clientBankAccountID", ObjectId.Parse(clientBankAccId) },
                { "cardId", debitCard.CardID }
            };

            collection.InsertOne(clientDebitCard);

            return ObjectId.Parse(clientBankAccId);
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
        public static ObjectId CreateCreditCardForClient(MongoClient client, IClient user, decimal balance, string clientBankAccId, string validity, double percent = 0, int maxLimit = 0)
        {
            var database = client.GetDatabase("bank");
            var collection = database.GetCollection<BsonDocument>("users_cards");

            var creditCard = CardManagement.CreateCreditCard(client, balance, validity, percent, maxLimit);

            var recordId = ObjectId.GenerateNewId();

            BsonDocument clientCreditCard = new BsonDocument
            {
                { "_id", recordId },
                { "clientBankAccountID", ObjectId.Parse(clientBankAccId) },
                { "cardId", creditCard.CardID }
            };

            collection.InsertOne(clientCreditCard);

            return ObjectId.Parse(clientBankAccId);
        }

        /// <summary>
        /// Получить список id всех банковских счетов пользователя
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


        /// <summary>
        /// Возвращает список банковских карт, привязанных к данному счету
        /// </summary>
        /// <param name="userAccountId"> id счета </param>
        /// <returns> Список карт </returns>
        public static List<string> GetUserBankAccCards(string userAccountId)
        {
            List<string> cardsId = new List<string>();

            var client = DBConnect.GetConnection();
            var database = client.GetDatabase("bank");
            var collection = database.GetCollection<BsonDocument>("users_cards");

            var filter = new BsonDocument("clientBankAccountID", ObjectId.Parse(userAccountId));
            var cursor = collection.FindSync(filter);

            while (cursor.MoveNext())
            {
                var records = cursor.Current;

                if (records.Count() == 0)
                {
                    throw new Exception("У данного клиента нет карт");
                }
                else
                {
                    foreach (var record in records)
                    {
                        cardsId.Add(record.GetValue("cardId").ToString());
                    }
                }
            }

            return cardsId;
        }

        /// <summary>
        /// Получить словарь с информацией по аккаунту
        /// </summary>
        /// <param name="bankAccId"> id счета </param>
        /// <returns> Словарь:)) </returns>
        public static Dictionary<string, string> GetBankAccInfo(string bankAccId)
        {
            Dictionary<string, string> accInfo = new Dictionary<string, string>();

            var client = DBConnect.GetConnection();
            var database = client.GetDatabase("bank");
            var collection = database.GetCollection<BsonDocument>("bank_account");

            var filter = new BsonDocument("_id", ObjectId.Parse(bankAccId));
            var cursor = collection.FindSync(filter);

            while (cursor.MoveNext())
            {
                var records = cursor.Current;

                if (records.Count() == 0)
                {
                    throw new Exception("Данного банковского аккаунта не существует, кек))))");
                }
                else
                {
                    foreach (var record in records)
                    {
                        accInfo.Add("id", record.GetValue("_id").ToString());
                        accInfo.Add("accountType", record.GetValue("accountType").ToString());
                        accInfo.Add("balance", record.GetValue("balance").ToString());
                        accInfo.Add("startDate", record.GetValue("startDate").ToString());
                        accInfo.Add("finishDate", record.GetValue("finishDate").ToString());
                        accInfo.Add("isActive", record.GetValue("isActive").ToString());
                    }
                }
            }

            return accInfo;
        }

        /// <summary>
        /// Получить полную информацию по карте
        /// </summary>
        /// <param name="cardId"> id банковской карты </param>
        /// <returns> Dictionary с информацией по карте </returns>
        public static Dictionary<string, string> GetCardInfo(string cardId)
        {
            Dictionary<string, string> cardInfo = new Dictionary<string, string>();

            var client = DBConnect.GetConnection();
            var database = client.GetDatabase("bank");
            var collection = database.GetCollection<BsonDocument>("card");

            var filter = new BsonDocument("_id", ObjectId.Parse(cardId));
            var cursor = collection.FindSync(filter);

            while (cursor.MoveNext())
            {
                var records = cursor.Current;

                if (records.Count() == 0)
                {
                    throw new Exception("Такой карты нет, кек))))");
                }
                else
                {
                    foreach (var record in records)
                    {
                        cardInfo.Add("id", record.GetValue("_id").ToString());
                        cardInfo.Add("balance", record.GetValue("Balance").ToString());
                        cardInfo.Add("validity", record.GetValue("Validity").ToString());
                        cardInfo.Add("percent", record.GetValue("Percent").ToString());
                        cardInfo.Add("maxLinit", record.GetValue("MaximumLimit").ToString());
                        cardInfo.Add("cardType", record.GetValue("CardType").ToString());
                        cardInfo.Add("cardNumber", record.GetValue("CardNumber").ToString());
                        cardInfo.Add("cvv", record.GetValue("CVV").ToString());
                    }
                }
            }

            return cardInfo;
        }

        /// <summary>
        /// Пополнить счет на заданную сумму
        /// </summary>
        /// <param name="accountId"> id банковского аккаунта </param>
        /// <param name="moneyAmount"> количество баблишка </param>
        public static void AddMoneyToAccount(string accountId, string moneyAmount)
        {
            var client = DBConnect.GetConnection();
            var database = client.GetDatabase("bank");
            var collection = database.GetCollection<BsonDocument>("bank_account");

            var filter = new BsonDocument("_id", ObjectId.Parse(accountId));
            var cursor = collection.FindSync(filter);

            decimal cashBefore;

            while (cursor.MoveNext())
            {
                var records = cursor.Current;

                if (records.Count() == 0)
                {
                    throw new Exception("Такого банковского аккаунта нет, упс))))");
                }
                else
                {
                    foreach (var record in records)
                    {
                        cashBefore = decimal.Parse(record.GetValue("balance").ToString());
                        // обновим таблицу в бд, добавив к балансу сумму, которую клиент зачисляет на карту
                        collection.UpdateOne
                        (
                            new BsonDocument("_id", new ObjectId(accountId)),
                            new BsonDocument("$set", new BsonDocument("balance", cashBefore + Convert.ToDecimal(moneyAmount)))
                        );
                    }
                }
            }
        }

        /// <summary>
        /// Перевести деньги со счета на карту (со счета деньги не уходят, а просто на карте становится НЕ 0!!!)
        /// </summary>
        /// <param name="cardId"> id банковской карты </param>
        /// <param name="moneyAmount"> Сумма баблишка </param>
        public static void TransferMoneyToCard(string cardId, string userAccId, string moneyAmount)
        {
            var client = DBConnect.GetConnection();
            var database = client.GetDatabase("bank");
            var collection = database.GetCollection<BsonDocument>("card");

            var filter = new BsonDocument("_id", ObjectId.Parse(cardId));
            var cursor = collection.FindSync(filter);

            decimal cashBefore;

            while (cursor.MoveNext())
            {
                var records = cursor.Current;

                if (records.Count() == 0)
                {
                    throw new Exception("Такой карточки нет, упс))))");
                }
                else
                {
                    foreach (var record in records)
                    {
                        cashBefore = decimal.Parse(record.GetValue("Balance").ToString());

                        collection.UpdateOne
                        (
                            new BsonDocument("_id", new ObjectId(cardId)),
                            new BsonDocument("$set", new BsonDocument("Balance", cashBefore + Convert.ToDecimal(moneyAmount)))
                        );
                    }
                }
            }

            database = DBConnect.GetConnection().GetDatabase("bank");
            collection = database.GetCollection<BsonDocument>("bank_account");

            // надо найти крч баланс аккаунта выбранного счета клиента (у него может быть несколько счетов
            // но на один счет приходится лишь один банковский аккаунт)
            filter = new BsonDocument("_id", new ObjectId(userAccId));
            cursor = collection.FindSync<BsonDocument>(filter);

            decimal senderCash;

            // СНИМАЕМ БАБКИ СО СЧЕТА ОТПРАВИТЕЛЯ
            // мб чет неправильно делаю, но работает, так что в пизду..
            while (cursor.MoveNext())
            {
                var accounts = cursor.Current;

                foreach (var account in accounts)
                {
                    // запомним изначальный баланс
                    senderCash = decimal.Parse(account.GetValue("balance").ToString());
                    // обновим таблицу в бд вычтев из баланса сумму, которую клиент переводит другому клиенту
                    collection.UpdateOne
                    (
                        new BsonDocument("_id", new ObjectId(userAccId)),
                        new BsonDocument("$set", new BsonDocument("balance", senderCash - Convert.ToDecimal(moneyAmount)))
                    );
                }
            }
        }
    }
}
