using bank_forms.src.BankAccount;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace bank_forms
{
    public partial class BankAccount : Form
    {
        IClient client;

        Dictionary<string, string> accInfo;
        List<string> userCards;

        string userAccId;

        public BankAccount(IClient client, Dictionary<string, string> accInfo, string userAccId)
        {
            InitializeComponent();

            this.client = client;
            this.accInfo = accInfo;
            this.userAccId = userAccId;
        }

        private void BankAccount_Load(object sender, EventArgs e)
        {
            lbl_accId.Text += "  " + accInfo["id"];
            lbl_accType.Text += "  " + accInfo["accountType"];
            lbl_accBalance.Text += "  " + accInfo["balance"];
            lbl_accStart.Text += "  " + accInfo["startDate"];
            lbl_accFinish.Text += "  " + accInfo["finishDate"];

            try
            {
                userCards = BankAccountManagement.GetUserBankAccCards(userAccId);
            }
            catch(Exception exc)
            {
                lbl_noCards.Visible = true;
            }

            if (userCards != null)
            {
                foreach (string card in userCards)
                {
                    ListViewItem lvi = new ListViewItem();

                    // установка названия файла
                    lvi.Name = card;
                    lvi.Text = card;
                    // добавляем элемент в ListView
                    lv_clientCards.Items.Add(lvi);
                    lv_clientCards.Items.Add("");
                }
            }
            else
            {
                lbl_noCards.Visible = true;
            }  
        }
    }
}
