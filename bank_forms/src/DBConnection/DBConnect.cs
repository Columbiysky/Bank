using MongoDB.Bson;
using MongoDB.Driver;

namespace bank_forms.src.DBConnection
{
    public static class DBConnect
    {
        private static string connectionString = "mongodb+srv://Colba:Colba@colba-anrx1.mongodb.net/test?retryWrites=true&w=majority";

        public static MongoClient Getconnection()
        {
            return new MongoClient(connectionString);
        }
    }
}
