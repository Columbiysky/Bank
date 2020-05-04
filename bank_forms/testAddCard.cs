﻿using bank_forms.src.BankAccount;
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
                var acc = BankAccountManagement.CreateNewUserBankAccount(DBConnect.GetConnection(), curClient, "тест тестович", 228000000, "04.05.2020", "04.05.2035", true);
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
                BankAccountManagement.CreateDebitCardForClient(DBConnect.GetConnection(), curClient, "12.12.2030");
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

            foreach (var el in list)
            {
                MessageBox.Show(el.ToString());
            }
        }
    }
}
