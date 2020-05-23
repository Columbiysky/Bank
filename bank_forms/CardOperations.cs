using bank_forms.src.BankAccount;
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
    public partial class CardOperations : Form
    {
        IClient client;

        string cardId;

        public CardOperations(IClient client, string cardId)
        {
            InitializeComponent();

            this.client = client;
            this.cardId = cardId;
        }

        private void btn_transferToUser1_Click(object sender, EventArgs e)
        {
            AccountOperations op = new AccountOperations();

            decimal moneyAmount = Convert.ToDecimal(tb_moneyAmount1.Text);
            string accountId = tb_recAccountId.Text;

            try
            {
                op.TransferMoneyFromCardToAccId(client, cardId, accountId, moneyAmount);
                MessageBox.Show("Средства успешно переведены");
            }
            catch(Exception exc)
            {
                MessageBox.Show("Такого банковского аккаунта не существует");
            }
        }

        private void btn_transferToUser2_Click(object sender, EventArgs e)
        {
            AccountOperations op = new AccountOperations();

            decimal moneyAmount = Convert.ToDecimal(tb_moneyAmount2.Text);
            string recieverCardId = tb_recCardNumber.Text;

            try
            {
                op.TransferMoneyFromCardToCard(client, cardId, long.Parse(recieverCardId), moneyAmount);
                MessageBox.Show("Средства успешно переведены");
            }
            catch (Exception exc)
            {
                MessageBox.Show("Такой банковской карты нет в базе данных");
            }
        }
    }
}
