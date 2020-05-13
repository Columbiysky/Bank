using bank_forms.src.BankAccount;
using bank_forms.src.DBConnection;
using bank_forms.src.FormsDialog;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bank_forms
{
    public partial class CreateUserAccount : Form
    {
        IClient user;

        public CreateUserAccount(IClient user)
        {
            InitializeComponent();

            this.user = user;
        }

        private void btn_createNewAcc_Click(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Today;

            if (tb_accInfo.Text == "" || tb_cofirmPass.Text == "" || tb_confirmINN.Text == "")
            {
                lbl_warning.Visible = true;
                return;
            }

            string accType = tb_accInfo.Text;
            string inn = tb_confirmINN.Text;
            string pass = tb_cofirmPass.Text;

            var client = DBConnect.GetConnection();
            var database = client.GetDatabase("bank");
            var collection = database.GetCollection<BsonDocument>("clients");

            var filter = new BsonDocument("_id", user.client_id);
            var cursor = collection.FindSync<BsonDocument>(filter);

            while (cursor.MoveNext())
            {
                var clients = cursor.Current;

                foreach (var user in clients)
                {
                    if (inn != user.GetValue("INN").ToString() || pass != user.GetValue("Password").ToString())
                    {
                        lbl_warning.Visible = true;
                        return;
                    }
                }
            }

            BankAccountManagement.CreateUserBankAccount(DBConnect.GetConnection(), user, accType, 0, dateTime.ToString("dd.MM.yyyy"), dateTime.AddYears(5).ToString("dd.MM.yyyy"), true);

            MessageBox.Show("Счет успешно создан!");

            // говорим, что акк создали и давайка обновим данные на первой форме
            FormDialog.DataIsRecieved = true;

            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("\t\t    Внимание! \nВсе аккаунты в нашем банке создаются сроком на 5 лет");
        }
    }
}
