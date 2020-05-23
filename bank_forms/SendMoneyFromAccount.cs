using bank_forms.src.BankAccount;
using bank_forms.src.Operations;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace bank_forms
{
    public partial class SendMoneyFromAccount : Form
    {
        IClient client;

        string accId;
        string userAccId;

        public SendMoneyFromAccount(IClient client, string accId, string userAccId)
        {
            InitializeComponent();

            this.client = client;
            this.accId = accId;
            this.userAccId = userAccId;
        }

        private void btn_transferToUser1_Click_1(object sender, EventArgs e)
        {
            AccountOperations op = new AccountOperations();

            decimal moneyAmount = Convert.ToDecimal(tb_moneyAmount1.Text, CultureInfo.InvariantCulture);
            string accountId = tb_recAccountId.Text;

            try
            {
                op.TransferMoneyToUserByAccId(client, accId, accountId, moneyAmount);
                MessageBox.Show("Средства успешно переведены");

                DateTime today = DateTime.Now;
                DateTime todayDate = DateTime.Today;

                string transactionType = "Перевод средств";
                string time = today.ToString("HH:mm:ss");

                // Записываем в архив
                OperationsRecorder.RecordAccountOperation
                (
                    userAccId,
                    todayDate.ToString("dd/MM/yyyy"),
                    time,
                    transactionType,
                    Convert.ToDecimal(tb_moneyAmount1.Text, CultureInfo.InvariantCulture)
                 );
            }
            catch (Exception exc)
            {
                MessageBox.Show("Такого счета нет в базе");
            }
        }

        private void btn_transferToUser2_Click(object sender, EventArgs e)
        {
            AccountOperations op = new AccountOperations();

            string cardNumber = tb_recCardNumber.Text;
            decimal moneyAmount = Convert.ToDecimal(tb_moneyAmount2.Text, CultureInfo.InvariantCulture);

            try
            {
                op.TransferMoneyToUserByCardNumber(client, accId, long.Parse(cardNumber), moneyAmount);
                MessageBox.Show("Средства успешно переведены");

                DateTime today = DateTime.Now;
                DateTime todayDate = DateTime.Today;

                string transactionType = "Перевод средств";
                string time = today.ToString("HH:mm:ss");

                // Записываем в архив
                OperationsRecorder.RecordAccountOperation
                (
                    userAccId,
                    todayDate.ToString("dd/MM/yyyy"),
                    time,
                    transactionType,
                    Convert.ToDecimal(tb_moneyAmount2.Text, CultureInfo.InvariantCulture)
                 );
            }
            catch (Exception exc)
            {
                MessageBox.Show("Пользователя с данной картой нет в базе");
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

        private void tb_recCardNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                return;
            else
                e.Handled = true;

            if (e.KeyChar == (char)Keys.Back)
                e.Handled = false;
        }

        private void btn_transferSomewhere_Click(object sender, EventArgs e)
        {
            AccountOperations op = new AccountOperations();

            string paymentDest = tb_transferDestination.Text;
            decimal moneyAmount = Convert.ToDecimal(tb_moneyAmount3.Text, CultureInfo.InvariantCulture);

            try
            {
                op.TransferMoneySomeWhereFromAcc(client, accId, moneyAmount);
                MessageBox.Show("Средства успешно переведены");

                DateTime today = DateTime.Now;
                DateTime todayDate = DateTime.Today;

                string transactionType = "Перевод средств";
                string time = today.ToString("HH:mm:ss");

                // Записываем в архив
                OperationsRecorder.RecordAccountOperation
                (
                    userAccId,
                    todayDate.ToString("dd/MM/yyyy"),
                    time,
                    transactionType,
                    Convert.ToDecimal(tb_moneyAmount3.Text, CultureInfo.InvariantCulture)
                 );
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка сервиса. Пожалуйста, повторите позже");
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
        }
    }
}
