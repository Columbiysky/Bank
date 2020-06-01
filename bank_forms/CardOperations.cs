using bank_forms.src.BankAccount;
using bank_forms.src.Operations;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bank_forms
{
    public partial class CardOperations : Form
    {
        IClient client;

        string cardId;
        string cardRecordId;
        ObjectId userCardId;

        public CardOperations(IClient client, string cardId, ObjectId userCardId)
        {
            InitializeComponent();

            this.client = client;
            this.cardId = cardId;
            this.userCardId = userCardId;
        }

        private void btn_transferToUser1_Click(object sender, EventArgs e)
        {
            if (tb_moneyAmount1.Text == "" || tb_recAccountId.Text == "")
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            AccountOperations op = new AccountOperations();

            decimal moneyAmount = Convert.ToDecimal(tb_moneyAmount1.Text, CultureInfo.InvariantCulture);
            string accountId = tb_recAccountId.Text;

            try
            {
                op.TransferMoneyFromCardToAccId(client, cardId, accountId, moneyAmount);
                MessageBox.Show("Средства успешно переведены");

                DateTime today = DateTime.Now;
                DateTime todayDate = DateTime.Today;

                cardRecordId = BankAccountManagement.GetUserCardId(cardId);

                string transactionType = "Перевод средств с карты";
                string time = today.ToString("HH:mm:ss");

                // Записываем в архив
                OperationsRecorder.RecordCardOperation
                (
                    cardRecordId,
                    todayDate.ToString("dd/MM/yyyy"),
                    time,
                    transactionType,
                    Convert.ToDecimal(tb_moneyAmount1.Text, CultureInfo.InvariantCulture)
                 );
            }
            catch (Exception exc)
            {
                MessageBox.Show("Данный банковский счет не зарегистрирован");
            }
        }

        private void btn_transferToUser2_Click(object sender, EventArgs e)
        {
            if (tb_moneyAmount2.Text == "" || tb_recCardNumber.Text == "")
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            AccountOperations op = new AccountOperations();

            decimal moneyAmount = Convert.ToDecimal(tb_moneyAmount2.Text, CultureInfo.InvariantCulture);
            string recieverCardId = tb_recCardNumber.Text;

            try
            {
                op.TransferMoneyFromCardToCard(client, cardId, long.Parse(recieverCardId), moneyAmount);
                MessageBox.Show("Средства успешно переведены");

                cardRecordId = BankAccountManagement.GetUserCardId(cardId);

                DateTime today = DateTime.Now;
                DateTime todayDate = DateTime.Today;

                string transactionType = "Перевод средств с карты";
                string time = today.ToString("HH:mm:ss");

                // Записываем в архив
                OperationsRecorder.RecordCardOperation
                (
                    cardRecordId,
                    todayDate.ToString("dd/MM/yyyy"),
                    time,
                    transactionType,
                    Convert.ToDecimal(tb_moneyAmount2.Text, CultureInfo.InvariantCulture)
                 );
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void tb_moneyAmount1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                return;
            else
                e.Handled = true;

            if (e.KeyChar == (char)Keys.Back)
                e.Handled = false;

            if (e.KeyChar == '.')
                e.Handled = false;
        }

        private void tb_moneyAmount2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                return;
            else
                e.Handled = true;

            if (e.KeyChar == (char)Keys.Back)
                e.Handled = false;

            if (e.KeyChar == '.')
                e.Handled = false;
        }

        private void btn_transferSomewhere_Click(object sender, EventArgs e)
        {
            if (tb_moneyAmount3.Text == "" || tb_transferDestination.Text == "")
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            AccountOperations op = new AccountOperations();

            decimal moneyAmount = Convert.ToDecimal(tb_moneyAmount3.Text, CultureInfo.InvariantCulture);

            try
            {
                op.TransferMoneySomeWhereFromCard(client, cardId, moneyAmount);
                MessageBox.Show("Средства успешно переведены");

                cardRecordId = BankAccountManagement.GetUserCardId(cardId);

                DateTime today = DateTime.Now;
                DateTime todayDate = DateTime.Today;

                string transactionType = "Перевод средств с карты";
                string time = today.ToString("HH:mm:ss");

                // Записываем в архив
                OperationsRecorder.RecordCardOperation
                (
                    cardRecordId,
                    todayDate.ToString("dd/MM/yyyy"),
                    time,
                    transactionType,
                    Convert.ToDecimal(tb_moneyAmount3.Text, CultureInfo.InvariantCulture)
                 );
            }
            catch (Exception exc)
            {
                MessageBox.Show("Такой банковской карты нет в базе данных");
            }
        }

        private void tb_moneyAmount3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                return;
            else
                e.Handled = true;

            if (e.KeyChar == (char)Keys.Back)
                e.Handled = false;

            if (e.KeyChar == '.')
                e.Handled = false;
        }
    }
}
