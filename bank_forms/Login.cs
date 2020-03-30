using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using System.Windows.Forms;
using MongoDB.Driver;

namespace bank_forms
{
    public partial class Login : Form
    {
        private MongoClient client;
        public Login()
        {
            client = new MongoClient("mongodb+srv://Colba:Colba@colba-anrx1.mongodb.net/test?retryWrites=true&w=majority");
            InitializeComponent();
        }

        private void Btn_login_Click(object sender, EventArgs e)
        {
            var db = client.GetDatabase("bank");
            var collection = db.GetCollection<BsonDocument>("users");

            var filter = new BsonDocument("$and", new BsonArray
            {
                new BsonDocument("login", txtBx_login.Text),
                new BsonDocument("password", txtBx_password.Text)
            }); 
            var cursor = collection.FindSync(filter);
            while (cursor.MoveNext())
            {
                var users = cursor.Current;
                foreach (var user in users)
                {
                    textBox1.Text += user.ToString();
                }
            }
        }
    }
}
