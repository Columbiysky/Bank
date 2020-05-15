using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace bank_forms.src.BankCards
{
    public static class CardManagement
    {
        public static ICard CreateDebitCard(MongoClient client, string validity, decimal balance = 0)
        {
            var database = client.GetDatabase("bank");
            var collection = database.GetCollection<BsonDocument>("card");

            var objId = ObjectId.GenerateNewId();

            string cvvCode = GenerateCVV();
            long cardNumber = GenerateCardNumber();

            BsonDocument debitCard = new BsonDocument
            {
                { "_id", objId },
                { "Balance", balance },
                { "Validity", validity },
                { "Percent", 0 },
                { "MaximumLimit",  0 },
                { "CardType", "Дебетовая карта" },
                { "CardNumber", cardNumber },
                { "CVV", cvvCode },
                { "isMain", false}
            };

            collection.InsertOne(debitCard);

            return new DebitCard(objId,validity, cardNumber, cvvCode, false, balance);
        }

        public static ICard CreateCreditCard
        (
            MongoClient client, 
            string validity, 
            double percent = 0, 
            int maxLimit = 0,
            decimal balance = 0
        )
        {
            var database = client.GetDatabase("bank");
            var collection = database.GetCollection<BsonDocument>("card");

            var objId = ObjectId.GenerateNewId();

            string cvvCode = GenerateCVV();
            long cardNumber = GenerateCardNumber();

            BsonDocument creditCard = new BsonDocument
            {
                { "_id", objId },
                { "Balance", balance },
                { "Validity", validity },
                { "Percent", percent },
                { "MaximumLimit",  maxLimit },
                { "CardType", "Кредитная карта" },
                { "CardNumber", cardNumber },
                { "CVV", cvvCode },
                { "isMain", false}
            };

            collection.InsertOne(creditCard);

            return new CreditCard(objId, validity, cardNumber, cvvCode, balance, percent, maxLimit);
        }

        private static long GenerateCardNumber()
        {
            Random random = new Random();
            long foobar = random.NextLong(1000000000000000, 10000000000000000);
            Random rnd = new Random();
            return foobar;
        }

        private static string GenerateCVV()
        {
            Random rnd = new Random();
            int cvv = rnd.Next(1, 999);
            string result = "";

            if (cvv <= 9)
            {
                result = result + "00" + cvv;
                return result;
            }

            if (cvv >= 10 && cvv <= 99)
            {
                result = result + "0" + cvv;
                return result;
            }

            result = result + cvv;

            return result;
        }

        // Random.Next только int принимает, а нам нужен рандом из long -> вот ето он!!!
        // (честно взял у умных людей)
        private static long NextLong(this Random random, long min, long max)
        {
            if (max <= min)
                throw new ArgumentOutOfRangeException("max", "max must be > min!");

            //Working with ulong so that modulo works correctly with values > long.MaxValue
            ulong uRange = (ulong)(max - min);

            //Prevent a modolo bias; see https://stackoverflow.com/a/10984975/238419
            //for more information.
            //In the worst case, the expected number of calls is 2 (though usually it's
            //much closer to 1) so this loop doesn't really hurt performance at all.
            ulong ulongRand;
            do
            {
                byte[] buf = new byte[8];
                random.NextBytes(buf);
                ulongRand = (ulong)BitConverter.ToInt64(buf, 0);
            } while (ulongRand > ulong.MaxValue - ((ulong.MaxValue % uRange) + 1) % uRange);

            return (long)(ulongRand % uRange) + min;
        }

        /// <summary>
        /// Returns a random long from 0 (inclusive) to max (exclusive)
        /// </summary>
        /// <param name="random">The given random instance</param>
        /// <param name="max">The exclusive maximum bound.  Must be greater than 0</param>
        private static long NextLong(this Random random, long max)
        {
            return random.NextLong(1000000000000000, max);
        }

        /// <summary>
        /// Returns a random long over all possible values of long (except long.MaxValue, similar to
        /// random.Next())
        /// </summary>
        /// <param name="random">The given random instance</param>
        private static long NextLong(this Random random)
        {
            return random.NextLong(long.MinValue, long.MaxValue);
        }
    }
}
