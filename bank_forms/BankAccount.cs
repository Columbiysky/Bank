using bank_forms.src.BankAccount;
using bank_forms.src.DBConnection;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace bank_forms
{
    public partial class BankAccount : Form
    {
        IClient client;

        Dictionary<string, string> accInfo;
        Dictionary<string, string> cardInfo;
        List<string> userCards;

        string userAccId;
        string bankAccId;

        int lvSelectedIndex;
        double cash;
        double cardCash;

        public BankAccount(IClient client, Dictionary<string, string> accInfo, string userAccId, string bankAccId)
        {
            InitializeComponent();

            this.client = client;
            this.accInfo = accInfo;
            this.userAccId = userAccId;
            this.bankAccId = bankAccId;
        }

        private void BankAccount_Load(object sender, EventArgs e)
        {
            lbl_accId.Text += "  " + accInfo["id"];
            lbl_accType.Text += "  " + accInfo["accountType"];
            lbl_accBalance.Text += "  " + accInfo["balance"];
            lbl_accStart.Text += "  " + accInfo["startDate"];
            lbl_accFinish.Text += "  " + accInfo["finishDate"];

            cash = Convert.ToDouble(accInfo["balance"]);

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
                    cardInfo = BankAccountManagement.GetCardInfo(card);
                    lvi.Name = card;
                    lvi.Text = "№ " + cardInfo["cardNumber"] + $"   Баланс: {cardInfo["balance"]};   {cardInfo["cardType"]}";
                    // добавляем элемент в ListView
                    lv_clientCards.Items.Add(lvi);

                    cardCash = Convert.ToDouble(cardInfo["balance"]);
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
                this.BeginInvoke((MethodInvoker)(() => UpdateForm()));
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void UpdateForm()
        {
            lv_clientCards.Clear();

            accInfo = BankAccountManagement.GetBankAccInfo(bankAccId);

            lbl_accId.Text = "Номер банковского аккаунта: " + accInfo["id"];
            lbl_accType.Text = "Тип аккаунта:  " + accInfo["accountType"];
            lbl_accBalance.Text = "Баланс: " + accInfo["balance"];
            lbl_accStart.Text = "Дата открытия: " + accInfo["startDate"];
            lbl_accFinish.Text = "Дата закрытия: " + accInfo["finishDate"];

            //cash = Convert.ToDouble(accInfo["balance"]);

            try
            {
                userCards = BankAccountManagement.GetUserBankAccCards(userAccId);
            }
            catch (Exception exc)
            {
                lbl_noCards.Visible = true;
            }

            if (userCards != null)
            {
                foreach (string card in userCards)
                {
                    ListViewItem lvi = new ListViewItem();

                    // установка названия файла
                    cardInfo = BankAccountManagement.GetCardInfo(card);
                    lvi.Name = card;
                    lvi.Text = "№ " + cardInfo["cardNumber"] + $"   Баланс: {cardInfo["balance"]};   {cardInfo["cardType"]}";
                    // добавляем элемент в ListView
                    lv_clientCards.Items.Add(lvi);
                }
            }
            else
            {
                lbl_noCards.Visible = true;
            }
        }

        private void lv_clientCards_ItemActivate(object sender, EventArgs e)
        {
            var cardId = lv_clientCards.Items[lv_clientCards.SelectedIndices[0]].Name;

            CardOperations cardOperationsForm = new CardOperations(client, cardId);
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
            try
            {
                var cardId = lv_clientCards.Items[lv_clientCards.SelectedIndices[0]].Name;

                if (!IsDebitCard(cardId))
                {
                    MessageBox.Show("Вы патаетесь пополнить баланс кредитной карты");
                    return;
                }

                if (!CheckCardAndAccBalance(cardId, Convert.ToDecimal(tb_moneyAmount.Text)))
                {
                    MessageBox.Show("Вы превысили баланс аккаунта");
                    return;
                }

                BankAccountManagement.TransferMoneyToCard(cardId, accInfo["id"], tb_moneyAmount.Text);

                cardCash += Convert.ToDouble(tb_moneyAmount.Text);
                cardInfo = BankAccountManagement.GetCardInfo(cardId);

                this.BeginInvoke((MethodInvoker)(() => UpdateForm()));
                MessageBox.Show("Средства зачислены");
            }
            catch (Exception exc)
            {
                MessageBox.Show("Выберите карту из списка");
                //MessageBox.Show(exc.Message);
            }
        }

        private void btn_addMoney_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(tb_addMoney.Text) > 80000 || tb_addMoney.Text == "")
            {
                MessageBox.Show("Максимальная сумма пополнения 80 000р");
                return;
            }

            BankAccountManagement.AddMoneyToAccount(accInfo["id"], tb_addMoney.Text);
            //lbl_accBalance.Text = "Баланс:";
            //cash += Convert.ToDouble(tb_addMoney.Text);
            //lbl_accBalance.Text += "  " + cash;
            MessageBox.Show("Средства зачислены");
        }

        private void btn_getCreditCard_Click(object sender, EventArgs e)
        {
            CreditForm creditForm = new CreditForm(client, userAccId);
            creditForm.ShowDialog();
        }

        private void BankAccount_Activated(object sender, EventArgs e)
        {
            //lv_clientCards.Clear();
            this.BeginInvoke((MethodInvoker)(() => UpdateForm()));
        }

        private bool IsDebitCard(string cardId)
        {
            var client = DBConnect.GetConnection();
            var database = client.GetDatabase("bank");
            var collection = database.GetCollection<BsonDocument>("card");

            var filter = new BsonDocument("_id", new ObjectId(cardId));
            var cursor = collection.FindSync<BsonDocument>(filter);

            bool result = true;

            while (cursor.MoveNext())
            {
                var cards = cursor.Current;

                foreach (var card in cards)
                {
                    if (card.GetValue("CardType").ToString() == "Дебетовая карта")
                        result = true;
                    else
                        result = false;
                }
            }

            return result;
        }

        private void tb_moneyAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) return;
            else
                e.Handled = true;

            if (e.KeyChar == (char)Keys.Back)
                e.Handled = false;
        }

        private bool CheckCardAndAccBalance(string card, decimal transferSum)
        {
            cardInfo = BankAccountManagement.GetCardInfo(card);
            decimal cardBalance = Convert.ToDecimal(cardInfo["balance"]);

            //accInfo = BankAccountManagement.GetBankAccInfo(userAccId);
            decimal accountBalance = Convert.ToDecimal(accInfo["balance"]);

            bool isAllowed = true;

            if (transferSum > accountBalance)
            {
                isAllowed = false;
            }

            return isAllowed;
        }

        private void btn_transferMoney_Click(object sender, EventArgs e)
        {
            SendMoneyFromAccount sendMoney = new SendMoneyFromAccount(client, accInfo["id"]);
            sendMoney.ShowDialog();
        }

        private void tb_addMoney_KeyPress(object sender, KeyPressEventArgs e)
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
