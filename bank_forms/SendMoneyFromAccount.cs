using bank_forms.src.BankAccount;
using System;
using System.Linq;
using System.Windows.Forms;

namespace bank_forms
{
    public partial class SendMoneyFromAccount : Form
    {
        IClient client;

        string accId;

        public SendMoneyFromAccount(IClient client, string accId)
        {
            InitializeComponent();

            this.client = client;
            this.accId = accId;
        }

        private void btn_transferToUser1_Click_1(object sender, EventArgs e)
        {
            AccountOperations op = new AccountOperations();

            decimal moneyAmount = Convert.ToDecimal(tb_moneyAmount1.Text);
            string accountId = tb_recAccountId.Text;

            try
            {
                op.TransferMoneyToUserByAccId(client, accId, accountId, moneyAmount);
                MessageBox.Show("Средства успешно переведены");
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
            decimal moneyAmount = Convert.ToDecimal(tb_moneyAmount2.Text);

            try
            {
                op.TransferMoneyToUserByCardNumber(client, accId, long.Parse(cardNumber), moneyAmount);
                MessageBox.Show("Средства успешно переведены");
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
        }

        private void tb_moneyAmount2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                return;
            else
                e.Handled = true;

            if (e.KeyChar == (char)Keys.Back)
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
    }
}
