using bank_forms.src.BankCards;
using bank_forms.src.DBConnection;
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
        public testAddCard()
        {
            InitializeComponent();
        }

        private void addCardBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var debutCard = CardManagement.CreateDebitCard(DBConnect.GetConnection(), "10.06.2025");
                MessageBox.Show("Успешно");
            }
            catch(Exception exc)
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
    }
}
