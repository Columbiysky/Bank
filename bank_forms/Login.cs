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
        private IClient app_client = new Client();

        public Login()
        {
            StartPosition = FormStartPosition.CenterScreen;
            client = new MongoClient("mongodb+srv://Colba:Colba@colba-anrx1.mongodb.net/test?retryWrites=true&w=majority");
            //Пиздец, вот и началось, коннекшин стринг, вся хуйня, сам понял
            InitializeComponent();
        }

        private void Btn_login_Click(object sender, EventArgs e)
        {
            var db = client.GetDatabase("bank"); //ну с ангийского переведи
            var collection = db.GetCollection<BsonDocument>("clients"); //и тут, что такое BsonDocument - до конца не понял, но мне реально поебать

            var filter = new BsonDocument("$and", new BsonArray //чтобы выборку сделать ,ес что щас там только 1 юзер   
            {
                new BsonDocument("Login", txtBx_login.Text),            //cola
                new BsonDocument("Password", txtBx_password.Text)       //cola          защитился охуеть...
            }); 

            var cursor = collection.FindSync(filter);       //все курсор называют, а хули мне, я не индивидуалочка тебе чтобы по своему называть
            while (cursor.MoveNext())       
            {
                var clients = cursor.Current;     //ну переведи ты ну что ты как ...
                if (clients.Count() == 0)
                    MessageBox.Show("Логин/Пароль не верны!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    foreach (var client in clients)
                    {
                        app_client.Login = txtBx_login.Text;
                        app_client.Password = txtBx_password.Text;
                        app_client.client_id64 = client.GetValue("_id").AsInt64;
                        app_client.Surname = client.GetValue("Surname").ToString();
                        app_client.Name = client.GetValue("Name").ToString();
                        app_client.Second_name = client.GetValue("Second_name").ToString();
                        app_client.INN = client.GetValue("INN").AsInt64;
                        app_client.Phone = client.GetValue("Phone").AsInt64;
                    }

                    MessageBox.Show("Все верно!", "Ок!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void linkLbl_Register_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration reg_form = new Registration();
            reg_form.ShowDialog();
        }
    }
}
