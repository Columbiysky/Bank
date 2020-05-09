using bank_forms.src.BankAccount;
using bank_forms.src.BankCards;
using bank_forms.src.DBConnection;
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
    public partial class testAddCard : Form
    {
        IClient curClient;
        List<string> accId;

        public testAddCard(IClient client)
        {
            InitializeComponent();
            curClient = client;
        }

        private void addCardBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var debitCard = CardManagement.CreateDebitCard(DBConnect.GetConnection(), "10.06.2025");
                MessageBox.Show("Успешно");
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var creditCard = CardManagement.CreateCreditCard(DBConnect.GetConnection(), "10.06.2025", 10, 50000);
                MessageBox.Show("Успешно");
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var acc = BankAccountManagement.CreateUserBankAccount(DBConnect.GetConnection(), curClient, "тест тестович", 228000000, "04.05.2020", "04.05.2035", true);
                MessageBox.Show("Успешно");
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void btnAddCard_Click(object sender, EventArgs e)
        {
            try
            {
                BankAccountManagement.CreateDebitCardForClient(DBConnect.GetConnection(), curClient, accId.First<string>().ToString(),  "12.12.2030");
                MessageBox.Show("Успешно");
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var client = DBConnect.GetConnection();
            var db = client.GetDatabase("bank");
            var collection = db.GetCollection<BsonDocument>("clients");

            var filter = new BsonDocument("Name", "Sergey");

            var cursor = collection.FindSync<BsonDocument>(filter);

            while (cursor.MoveNext())
            {
                var clients = cursor.Current;

                foreach (var user in clients)
                {
                    MessageBox.Show(user.GetValue("Phone").ToString());
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var list = BankAccountManagement.GetUserBankAccounts(curClient);

            accId = list;

            foreach (var el in list)
            {
                MessageBox.Show(el.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                BankAccountManagement.CreateCreditCardForClient(DBConnect.GetConnection(), curClient, accId.Last<string>().ToString(), "12.12.2030", 5.5, 10000000);
                MessageBox.Show("Успешно");
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                var id = BankAccountManagement.GetUserBankAccId(accId.First<string>().ToString());
                MessageBox.Show(id);
            }
            catch (Exception exc)
            {
                MessageBox.Show("пиздец...");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                AccountOperations op = new AccountOperations();
                op.TransferMoneyToUserByNumber(curClient, accId.Last<string>().ToString(), 79019101122, 5000);
                MessageBox.Show("ЧЕТКО!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ПИЗДЕЦ!!!");
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                var cardsId = BankAccountManagement.GetUserBankAccCards(accId.First<string>().ToString());
                foreach (var card in cardsId)
                {
                    MessageBox.Show(card.ToString());
                }
                MessageBox.Show("ЧЕТКО!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ПИЗДЕЦ!!!");
            }
        }
    }
}
