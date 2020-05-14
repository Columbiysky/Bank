using bank_forms.src.BankAccount;
using bank_forms.src.DBConnection;
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
        int lvSelectedIndex;

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
;

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
                    lvi.Text = card + $"             Баланс: {accInfo["balance"]}";
                    // добавляем элемент в ListView
                    lv_clientCards.Items.Add(lvi);
                }
            }
            else
            {
                lbl_noCards.Visible = true;
            }  
        }

        private void btn_addDebitCard_Click(object sender, EventArgs e)
        {
            try
            {
                BankAccountManagement.CreateDebitCardForClient(DBConnect.GetConnection(), client, userAccId, accInfo["finishDate"]);
                MessageBox.Show("Дебетовая карта добавлена к Вашему счету");
                UpdateForm();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void UpdateForm()
        {
            lv_clientCards.Clear();
            try
            {
                userCards = BankAccountManagement.GetUserBankAccCards(userAccId);
            }
            catch (Exception exc)
            {
                lbl_noCards.Visible = true;
            }

            lbl_noCards.Visible = (userCards == null) ? true : false;

            foreach (string card in userCards)
            {
                ListViewItem lvi = new ListViewItem();

                // установка названия файла
                lvi.Name = card;
                lvi.Text = card;
                // добавляем элемент в ListView
                lv_clientCards.Items.Add(lvi);
                //lv_clientCards.Items.Add("");
            }
        }

        private void lv_clientCards_ItemActivate(object sender, EventArgs e)
        {
            var cardId = lv_clientCards.Items[lv_clientCards.SelectedIndices[0]].Name;

            CardOperations cardOperationsForm = new CardOperations(cardId);
            cardOperationsForm.Text = $"Карта номер {lv_clientCards.Items[lvSelectedIndex].Name}";
            MessageBox.Show(lv_clientCards.Items[lvSelectedIndex].Name);
            cardOperationsForm.ShowDialog();
        }

        private void lv_clientCards_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvSelectedIndex = lv_clientCards.FocusedItem.Index;
        }

        private void btn_transferMoneyToCard_Click(object sender, EventArgs e)
        {
            var cardId = lv_clientCards.Items[lv_clientCards.SelectedIndices[0]].Name;
            MessageBox.Show($"ДОДЕЛАЙ МЕНЯ!!!    {cardId}");
        }
    }
}
