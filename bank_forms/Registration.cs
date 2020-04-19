using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace bank_forms
{
    public partial class Registration : Form
    {
        private MongoClient client;
        public Registration(MongoClient client_)
        {
            StartPosition = FormStartPosition.CenterScreen;
            client = client_;
            InitializeComponent();
        }

        private void Btn_Register_Click(object sender, EventArgs e)
        {
            IClient newClient = new Client(); //инициализируем 
            var db = client.GetDatabase("bank");    //ясно
            var collection = db.GetCollection<BsonDocument>("clients");
            if (Check()) //чекаем что все поля заполнены
            {
               // newClient = GetData(newClient, collection); //заполняем все что можем
                var insertDoc = convertToBsonDocument(
                    GetData(newClient, collection)); //конвертируем в BSON чтобы заполнить в базе
                if (insertDoc == null) //Если еще с GetData null кидаем - вылетаем и тип ващ хз что делать 
                    return; //мб это можно сделать более адекватно, но я уже подтупливаю конкретно
                else
                {
                    var filter = new BsonDocument("$or", new BsonArray //Проверяем что такого же молодого нет
                    {
                        new BsonDocument("Login", insertDoc.GetValue("Login")),     
                        new BsonDocument("Phone", insertDoc.GetValue("Phone"))
                    });

                    var cursor = collection.FindSync(filter);       //все курсор называют, а хули мне, я не индивидуалочка тебе чтобы по своему называть
                    while (cursor.MoveNext())
                    {
                        var clients = cursor.Current; //ну переведи ты ну что ты как ...
                        if (clients.Count() > 0)
                        {
                            MessageBox.Show("This user already registered!", "Error!", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return; //вылетаем после того, как нашли
                        }
                    }
                    collection.InsertOne(insertDoc); //ну или вставляем
                    MessageBox.Show("Succesfully registered!", "Congratulations!", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    this.Dispose();
                }
            }
        }

        private IClient GetData(IClient app_client, IMongoCollection<BsonDocument> collection)
        {
            try
            {
                app_client.Login = txtBx_Login.Text;
                app_client.Password = txtBx_Password.Text;
                app_client.Surname = txtBx_Surname.Text;
                app_client.Name = txtBx_Name.Text;
                app_client.Second_name = txtBx_Second_name.Text;
                app_client.Phone = long.Parse(txtBx_Phone.Text);
                app_client.client_id64 = collection.CountDocuments(new BsonDocument()) + 1; //id будет long number ну ты понял
                //кол-во документов в коллекции + 1

                app_client.INN = app_client.client_id64; //а хули нет, у нас в единственной записи также)))

                return app_client;
            }
            catch (Exception ex) //по идее тут только одна ошибка - номер заполнен буквами - ругаемся и возвращаем нулл
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private BsonDocument convertToBsonDocument(IClient app_client) 
        {
            if (app_client != null) {   //если с прошлого метода кинули нулл - кидаем нулл в ответ, иначе работаем
                BsonDocument new_client = new BsonDocument
                {
                    {"_id", app_client.client_id64 },
                    {"Surname", app_client.Surname },
                    {"Name",app_client.Name },
                    {"Second_name", app_client.Second_name },
                    {"INN", app_client.INN },
                    {"Phone", app_client.Phone },
                    {"Login", app_client.Login },
                    {"Password", app_client.Password }
                };

                return new_client;
            }
            return null;
        }

        private bool Check()
        {
            if (txtBx_Login.Text.Replace(" ","").Length== 0)    //Убираем пробелы и смотрим чтобы строка
                txtBx_Login.Focus();                                        //не была пустой, иначе ругаемся и фокусируемся
            else if (txtBx_Password.Text.Replace(" ", "").Length == 0)
                txtBx_Password.Focus();
            else if (txtBx_Surname.Text.Replace(" ", "").Length == 0)
                txtBx_Surname.Focus();
            else if (txtBx_Name.Text.Replace(" ", "").Length == 0)
                txtBx_Name.Focus();
            else if (txtBx_Second_name.Text.Replace(" ", "").Length == 0)
                txtBx_Second_name.Focus();
            else if (txtBx_Phone.Text.Replace(" ", "").Length == 0)
                txtBx_Phone.Focus();
            else
                return true;

            MessageBox.Show("Not all fields are filled!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        private void txtBx_Phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (txtBx_Phone.Text.Length == 1 && txtBx_Phone.Text[0] == '9')
            //    txtBx_Phone.Text.Insert(0, "+7");
            //if (txtBx_Phone.Text.Length == 1 && txtBx_Phone.Text[0] == '8')
            //    txtBx_Phone.Text.Replace("8", "+7");
            //if (txtBx_Phone.Text.Length == 1 && txtBx_Phone.Text[0] == '+')
            //    txtBx_Phone.Text.Insert(1, "7");
        }

        private void txtBx_Phone_KeyUp(object sender, KeyEventArgs e)
        {
            //if (txtBx_Phone.Text.Length == 1 && txtBx_Phone.Text[0] == '9')
            //    txtBx_Phone.Text.Insert(0, "+7");
            //if (txtBx_Phone.Text.Length == 1 && txtBx_Phone.Text[0] == '8')
            //    txtBx_Phone.Text.Replace("8", "+7");
            //if (txtBx_Phone.Text.Length == 1 && txtBx_Phone.Text[0] == '+')
            //    txtBx_Phone.Text.Insert(1, "7");
        }

        private void txtBx_Phone_KeyDown(object sender, KeyEventArgs e)
        {
            //if (txtBx_Phone.Text.Length == 1 && txtBx_Phone.Text[0] == '9')
            //    txtBx_Phone.Text.Insert(0, "+7");
            //if (txtBx_Phone.Text.Length == 1 && txtBx_Phone.Text[0] == '8')
            //    txtBx_Phone.Text.Replace("8", "+7");
            //if (txtBx_Phone.Text.Length == 1 && txtBx_Phone.Text[0] == '+')
            //    txtBx_Phone.Text.Insert(1, "7");
        }

        private void txtBx_Phone_TextChanged(object sender, EventArgs e)
        {
            //if (txtBx_Phone.Text.Length == 1 && txtBx_Phone.Text[0] == '9')
            //    txtBx_Phone.Text.Insert(0, "+7");
            //if (txtBx_Phone.Text.Length == 1 && txtBx_Phone.Text[0] == '8')
            //    txtBx_Phone.Text.Replace("8", "+7");
            //if (txtBx_Phone.Text.Length == 1 && txtBx_Phone.Text[0] == '+')
            //    txtBx_Phone.Text.Insert(1, "7");
        }
    }
}
