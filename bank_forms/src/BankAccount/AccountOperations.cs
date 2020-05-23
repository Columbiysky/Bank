using bank_forms.src.DBConnection;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Globalization;
using System.Linq;

namespace bank_forms.src.BankAccount
{
    public class AccountOperations
    {
        public void TransferMoneySomeWhereFromAcc(IClient sender, string senderAccId, decimal moneyAmount)
        {
            decimal senderCash = 0;

            var database = DBConnect.GetConnection().GetDatabase("bank");
            var collection = database.GetCollection<BsonDocument>("bank_account");

            // надо найти крч баланс аккаунта выбранного счета клиента (у него может быть несколько счетов
            // но на один счет приходится лишь один банковский аккаунт)
            var filter = new BsonDocument("_id", new ObjectId(senderAccId));
            var cursor = collection.FindSync<BsonDocument>(filter);

            // мб чет неправильно делаю, но работает, так что в пизду..
            while (cursor.MoveNext())
            {
                var accounts = cursor.Current;

                foreach (var account in accounts)
                {
                    // запомним изначальный баланс
                    senderCash = decimal.Parse(account.GetValue("balance").ToString(), CultureInfo.InvariantCulture);

                    decimal result = senderCash - moneyAmount;
                    // обновим таблицу в бд вычев из баланса сумму, которую клиент переводит другому клиенту
                    collection.UpdateOne
                    (
                        new BsonDocument("_id", new ObjectId(senderAccId)),
                        new BsonDocument("$set", new BsonDocument("balance", Convert.ToDecimal(result, CultureInfo.InvariantCulture)))
                    );
                }
            }
        }

        public void TransferMoneySomeWhereFromCard(IClient sender, string senderCardId, decimal moneyAmount)
        {
            decimal senderCash = 0;

            var database = DBConnect.GetConnection().GetDatabase("bank");
            var collection = database.GetCollection<BsonDocument>("card");

            // надо найти крч баланс аккаунта выбранного счета клиента (у него может быть несколько счетов
            // но на один счет приходится лишь один банковский аккаунт)
            var filter = new BsonDocument("_id", new ObjectId(senderCardId));
            var cursor = collection.FindSync<BsonDocument>(filter);

            // мб чет неправильно делаю, но работает, так что в пизду..
            while (cursor.MoveNext())
            {
                var accounts = cursor.Current;

                foreach (var account in accounts)
                {
                    // запомним изначальный баланс
                    senderCash = decimal.Parse(account.GetValue("Balance").ToString(), CultureInfo.InvariantCulture);

                    decimal result = senderCash - moneyAmount;
                    // обновим таблицу в бд вычев из баланса сумму, которую клиент переводит другому клиенту
                    collection.UpdateOne
                    (
                        new BsonDocument("_id", new ObjectId(senderCardId)),
                        new BsonDocument("$set", new BsonDocument("Balance", Convert.ToDecimal(result, CultureInfo.InvariantCulture)))
                    );
                }
            }
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
                    senderCash = decimal.Parse(account.GetValue("balance").ToString(), CultureInfo.InvariantCulture);
                    // обновим таблицу в бд вычев из баланса сумму, которую клиент переводит другому клиенту
                    collection.UpdateOne
                    (
                        new BsonDocument("_id", new ObjectId(userBankAccId)), 
                        new BsonDocument("$set", new BsonDocument("balance", senderCash - moneyAmount))
                    );
                }
            }
        }

        public void TransferMoneyToUserByCardNumber(IClient sender, string senderAccId, long recieverCardNumber, decimal moneyAmount)
        {
            var userBankAccId = BankAccountManagement.GetUserBankAccId(senderAccId);

            // тут может вылететь сразу НЕСКОЛЬКО эксепшенов, CAREFUL!!!
            // запишем в блокнотик id получателя и id его банковского акк, куда привязана карта
            // long recieverId = FindUserByCardNumber(DBConnect.GetConnection(), recieverCardNumber, out recieverBankAccId);

            decimal senderCash = 0;
            decimal recieverCash = 0;

            var database = DBConnect.GetConnection().GetDatabase("bank");
            var collection = database.GetCollection<BsonDocument>("bank_account");

            // надо найти крч баланс аккаунта выбранного счета клиента (у него может быть несколько счетов
            // но на один счет приходится лишь один банковский аккаунт)
            var filter = new BsonDocument("_id", new ObjectId(senderAccId));
            var cursor = collection.FindSync<BsonDocument>(filter);

            // СНИМАЕМ БАБКИ СО СЧЕТА ОТПРАВИТЕЛЯ
            // мб чет неправильно делаю, но работает, так что в пизду..
            while (cursor.MoveNext())
            {
                var accounts = cursor.Current;

                foreach (var account in accounts)
                {
                    // запомним изначальный баланс
                    senderCash = decimal.Parse(account.GetValue("balance").ToString(), CultureInfo.InvariantCulture);

                    if (senderCash < moneyAmount)
                    {
                        throw new Exception("Недостаток средств на счету");
                    }

                    decimal result = senderCash - moneyAmount;

                    // обновим таблицу в бд вычтев из баланса сумму, которую клиент переводит другому клиенту
                    collection.UpdateOne
                    (
                        new BsonDocument("_id", new ObjectId(senderAccId)),
                        new BsonDocument("$set", new BsonDocument("balance", Convert.ToDecimal(result, CultureInfo.InvariantCulture)))
                    );
                }
            }

            collection = database.GetCollection<BsonDocument>("card");
            filter = new BsonDocument("CardNumber", recieverCardNumber);
            cursor = collection.FindSync<BsonDocument>(filter);

            // ЗАЧИСЛЯЕМ БАБКИ ПОЛУЧАТЕЛЮ
            while (cursor.MoveNext())
            {
                var accounts = cursor.Current;

                foreach (var account in accounts)
                {
                    // запомним изначальный баланс
                    recieverCash = decimal.Parse(account.GetValue("Balance").ToString(), CultureInfo.InvariantCulture);

                    decimal result = recieverCash + moneyAmount;
                    // обновим таблицу в бд, добавив к начальнйо сумме сумму перевода
                    collection.UpdateOne
                    (
                        new BsonDocument("CardNumber", recieverCardNumber),
                        new BsonDocument("$set", new BsonDocument("Balance", Convert.ToDecimal(result, CultureInfo.InvariantCulture)))
                    );
                }
            }
        }

        public void TransferMoneyToUserByAccId(IClient sender, string senderAccId, string recieverAccId, decimal moneyAmount)
        {
            //var userBankAccId = BankAccountManagement.GetUserBankAccId(senderAccId);

            // id банковского счета, куда КЭЕЭЕЭЕШ будем переводить
            ObjectId recieverBankAccId = ObjectId.Parse(recieverAccId);

            decimal senderCash = 0;
            decimal recieverCash = 0;

            var database = DBConnect.GetConnection().GetDatabase("bank");
            var collection = database.GetCollection<BsonDocument>("bank_account");

            // надо найти крч баланс аккаунта выбранного счета клиента (у него может быть несколько счетов
            // но на один счет приходится лишь один банковский аккаунт)
            var filter = new BsonDocument("_id", new ObjectId(senderAccId));
            var cursor = collection.FindSync<BsonDocument>(filter);

            // СНИМАЕМ БАБКИ СО СЧЕТА ОТПРАВИТЕЛЯ
            // мб чет неправильно делаю, но работает, так что в пизду..
            while (cursor.MoveNext())
            {
                var accounts = cursor.Current;

                foreach (var account in accounts)
                {
                    // запомним изначальный баланс
                    senderCash = decimal.Parse(account.GetValue("balance").ToString(), CultureInfo.InvariantCulture);

                    decimal result = senderCash - moneyAmount;

                    if (senderCash < moneyAmount)
                    {
                        throw new Exception("Недостаток средств на счету");
                    }

                    // обновим таблицу в бд вычтев из баланса сумму, которую клиент переводит другому клиенту
                    collection.UpdateOne
                    (
                        new BsonDocument("_id", new ObjectId(senderAccId)),
                        new BsonDocument("$set", new BsonDocument("balance", Convert.ToDecimal(result, CultureInfo.InvariantCulture)))
                    );
                }
            }

            filter = new BsonDocument("_id", recieverBankAccId);
            cursor = collection.FindSync<BsonDocument>(filter);

            // ЗАЧИСЛЯЕМ БАБКИ ПОЛУЧАТЕЛЮ
            while (cursor.MoveNext())
            {
                var accounts = cursor.Current;

                foreach (var account in accounts)
                {
                    // запомним изначальный баланс
                    recieverCash = decimal.Parse(account.GetValue("balance").ToString(), CultureInfo.InvariantCulture);

                    decimal result = recieverCash + moneyAmount;
                    // обновим таблицу в бд, добавив к начальнйо сумме сумму перевода
                    collection.UpdateOne
                    (
                        new BsonDocument("_id", recieverBankAccId),
                        new BsonDocument("$set", new BsonDocument("balance", Convert.ToDecimal(result, CultureInfo.InvariantCulture)))
                    );
                }
            }
        }

        public void TransferMoneyFromCardToAccId(IClient sender, string senderCardId, string recieverAccId, decimal moneyAmount)
        {
            decimal senderCash = 0;
            decimal recieverCash = 0;

            var database = DBConnect.GetConnection().GetDatabase("bank");
            var collection = database.GetCollection<BsonDocument>("card");

            // надо найти крч баланс аккаунта выбранного счета клиента (у него может быть несколько счетов
            // но на один счет приходится лишь один банковский аккаунт)
            var filter = new BsonDocument("_id", new ObjectId(senderCardId));
            var cursor = collection.FindSync<BsonDocument>(filter);

            // СНИМАЕМ БАБКИ СО СЧЕТА ОТПРАВИТЕЛЯ
            // мб чет неправильно делаю, но работает, так что в пизду..
            while (cursor.MoveNext())
            {
                var cards = cursor.Current;

                foreach (var card in cards)
                {
                    // запомним изначальный баланс
                    senderCash = decimal.Parse(card.GetValue("Balance").ToString(), CultureInfo.InvariantCulture);

                    if (senderCash < moneyAmount)
                    {
                        throw new Exception("Недостаток средств на счету");
                    }

                    decimal result = senderCash - moneyAmount;
                    // обновим таблицу в бд вычтев из баланса сумму, которую клиент переводит другому клиенту
                    collection.UpdateOne
                    (
                        new BsonDocument("_id", new ObjectId(senderCardId)),
                        new BsonDocument("$set", new BsonDocument("Balance", Convert.ToDecimal(result, CultureInfo.InvariantCulture)))
                    );
                }
            }

            collection = database.GetCollection<BsonDocument>("bank_account");
            filter = new BsonDocument("_id", new ObjectId(recieverAccId));
            cursor = collection.FindSync<BsonDocument>(filter);

            // ЗАЧИСЛЯЕМ БАБКИ ПОЛУЧАТЕЛЮ
            while (cursor.MoveNext())
            {
                var accounts = cursor.Current;

                foreach (var account in accounts)
                {
                    // запомним изначальный баланс
                    recieverCash = decimal.Parse(account.GetValue("balance").ToString(), CultureInfo.InvariantCulture);

                    decimal result = recieverCash + moneyAmount;
                    // обновим таблицу в бд, добавив к начальнйо сумме сумму перевода
                    collection.UpdateOne
                    (
                        new BsonDocument("_id", new ObjectId(recieverAccId)),
                        new BsonDocument("$set", new BsonDocument("balance", Convert.ToDecimal(result, CultureInfo.InvariantCulture)))
                    );
                }
            }
        }

        public void TransferMoneyFromCardToCard(IClient sender, string senderCardId, long recieverCardId, decimal moneyAmount)
        {
            decimal senderCash = 0;
            decimal recieverCash = 0;

            var database = DBConnect.GetConnection().GetDatabase("bank");
            var collection = database.GetCollection<BsonDocument>("card");

            // надо найти крч баланс аккаунта выбранного счета клиента (у него может быть несколько счетов
            // но на один счет приходится лишь один банковский аккаунт)
            var filter = new BsonDocument("_id", new ObjectId(senderCardId));
            var cursor = collection.FindSync<BsonDocument>(filter);

            // СНИМАЕМ БАБКИ СО СЧЕТА ОТПРАВИТЕЛЯ
            // мб чет неправильно делаю, но работает, так что в пизду..
            while (cursor.MoveNext())
            {
                var cards = cursor.Current;

                foreach (var card in cards)
                {
                    // запомним изначальный баланс
                    senderCash = decimal.Parse(card.GetValue("Balance").ToString(), CultureInfo.InvariantCulture);

                    if (senderCash < moneyAmount)
                    {
                        throw new Exception("Недостаток средств на счету");
                    }

                    decimal result = senderCash - moneyAmount;

                    // обновим таблицу в бд вычтев из баланса сумму, которую клиент переводит другому клиенту
                    collection.UpdateOne
                    (
                        new BsonDocument("_id", new ObjectId(senderCardId)),
                        new BsonDocument("$set", new BsonDocument("Balance", Convert.ToDecimal(result, CultureInfo.InvariantCulture)))
                    );
                }
            }

            collection = database.GetCollection<BsonDocument>("card");
            filter = new BsonDocument("CardNumber", recieverCardId);
            cursor = collection.FindSync<BsonDocument>(filter);

            // ЗАЧИСЛЯЕМ БАБКИ ПОЛУЧАТЕЛЮ
            while (cursor.MoveNext())
            {
                var accounts = cursor.Current;

                foreach (var account in accounts)
                {
                    // запомним изначальный баланс
                    recieverCash = decimal.Parse(account.GetValue("Balance").ToString(), CultureInfo.InvariantCulture);

                    decimal result = recieverCash + moneyAmount;

                    // обновим таблицу в бд, добавив к начальнйо сумме сумму перевода
                    collection.UpdateOne
                    (
                        new BsonDocument("CardNumber", recieverCardId),
                        new BsonDocument("$set", new BsonDocument("Balance", Convert.ToDecimal(result, CultureInfo.InvariantCulture)))
                    );
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

            // ищем челика в таблице Clients
            var cursor = collection.FindSync(filter);
            while (cursor.MoveNext())
            {
                var clients = cursor.Current;
                if (clients.Count() == 0)
                {
                    // хз что сделать, на пхй кину простой эксепшен!
                    throw new Exception("Клиентов с таким номером телефона нет");
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

        /// <summary>
        /// Вернуть ID клиента - владельца карты
        /// </summary>
        /// <param name="client"> Коннекшн </param>
        /// <param name="cardNumber"> Номер карты </param>
        /// <returns> id клиента банка </returns>
        private int FindUserByCardNumber(MongoClient client, long cardNumber, out ObjectId bankAccountId)
        {
            ObjectId cardId = new ObjectId();
            bankAccountId = new ObjectId();

            var filter = new BsonDocument("CardNumber", cardNumber);

            var database = client.GetDatabase("bank");
            var collection = database.GetCollection<BsonDocument>("cards");

            // ищем карту в таблице Cards
            var cursor = collection.FindSync(filter);
            while (cursor.MoveNext())
            {
                var cards = cursor.Current;

                if (cards.Count() == 0)
                {
                    // хз что сделать, на пхй кину простой эксепшен!
                    throw new Exception("Клиентов с данным номером карты не существует");
                }
                else
                {
                    foreach (var card in cards)
                    {
                        cardId = ObjectId.Parse(card.GetValue("_id").ToString());
                    }
                }
            }

            // ищем счет, к которому привязана карта
            collection = database.GetCollection<BsonDocument>("users_cards");
            filter = new BsonDocument("cardId", cardId);

            ObjectId clientBankAccId = new ObjectId();

            cursor = collection.FindSync(filter);
            while (cursor.MoveNext())
            {
                var usersCards = cursor.Current;

                if (usersCards.Count() == 0)
                {
                    // хз что сделать, на пхй кину простой эксепшен!
                    throw new Exception("Я эксепшен, поймай меня!...");
                }
                else
                {
                    foreach (var userCard in usersCards)
                    {
                        clientBankAccId = ObjectId.Parse(userCard.GetValue("clientBankAccID").ToString());
                    }
                }
            }

            // ну и НАКОНЕЦ-ТО ищем владельца карты
            // и заодно запомним _id банковского счета, к котороу карточка привязана (тупо по приколу)
            collection = database.GetCollection<BsonDocument>("client_account");
            filter = new BsonDocument("bankAccId", clientBankAccId);

            int recieverId = -1;

            cursor = collection.FindSync(filter);
            while (cursor.MoveNext())
            {
                var users = cursor.Current;

                if (users.Count() == 0)
                {
                    // хз что сделать, на пхй кину простой эксепшен!
                    throw new Exception("Я эксепшен, поймай меня!...");
                }
                else
                {
                    foreach (var user in users)
                    {
                        recieverId = int.Parse(user.GetValue("clientId").ToString());
                        bankAccountId = ObjectId.Parse(user.GetValue("bankAccId").ToString());
                    }
                }
            }

            return recieverId;
        }
    }
}
