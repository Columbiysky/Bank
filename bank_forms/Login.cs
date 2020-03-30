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
            //Пиздец, вот и началось, коннекшин стринг, вся хуйня, сам понял
            //Надо будет добавить твой IP в белый лист в базе монго, пока хз как это делать, я ток свой умею))
            InitializeComponent();
        }

        private void Btn_login_Click(object sender, EventArgs e)
        {
            var db = client.GetDatabase("bank"); //ну с ангийского переведи
            var collection = db.GetCollection<BsonDocument>("users"); //и тут, что такое BsonDocument - до конца не понял, но мне реально поебать

            var filter = new BsonDocument("$and", new BsonArray //чтобы выборку сделать ,ес что щас там только 1 юзер   
            {
                new BsonDocument("login", txtBx_login.Text),            //cola
                new BsonDocument("password", txtBx_password.Text)       //cola          защитился охуеть...
            }); 

            var cursor = collection.FindSync(filter);       //все курсор называют, а хули мне, я не индивидуалочка тебе чтобы по своему называть
            while (cursor.MoveNext())       
            {
                var users = cursor.Current;     //ну переведи ты ну что ты как ...
                foreach (var user in users)
                {
                    textBox1.Text += user.ToString();       //ясно...
                }
            }
        }
    }
}
