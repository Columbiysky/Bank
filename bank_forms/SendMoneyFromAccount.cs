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

        private void btn_transferToUser_Click(object sender, EventArgs e)
        {
            AccountOperations op = new AccountOperations();

            decimal moneyAmount = Convert.ToDecimal(tb_moneyAmount.Text);
            string cardNumber = tb_recCardNumber.Text;

            try
            {
                op.TransferMoneyToUserByAccId(client, accId, cardNumber, moneyAmount);
                MessageBox.Show("Средства успешно переведены");
            }
            catch (Exception exc)
            {
                MessageBox.Show("Такого счета нет в базе");
            }
        }

        private void tb_moneyAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) return;
            else
                e.Handled = true;
        }
    }
}
