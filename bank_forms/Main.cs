using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using Dadata;
using Dadata.Model;
using KladrApiClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Driver.Core.WireProtocol.Messages;
using bank_forms.src.BankAccount;
using bank_forms.src.FormsDialog;

namespace bank_forms
{
    public partial class Main : Form
    {
        int lvSelectedIndex;
        string bankAccId;

        Dictionary<string, string> accInfo;
        Dictionary<string, string> cardInfo;

        private MongoClient client;
        string DaDataToken = "481cdec20e319b938eb5fbff21fed0bee64a4706";
        //string DaDataSecret = "815788af76613100cd9df99ac7d86d96e0c18564";
        Dictionary<int, string> ID_addresses_dict;

        private IMongoDatabase db;
        private IClient app_client, old_client, curUser;

        private bool EditMode = false;
        private long _id { get; }
        private string old_address { get; set; }

        private bool SelectedFromListBox = false;

        public Main(MongoClient client_, IClient user, long id)
        {
            _id = id;
            StartPosition = FormStartPosition.CenterScreen;
            client = client_;
            db = client.GetDatabase("bank");

            this.curUser = user;

            var address_client_coll = db.GetCollection<BsonDocument>("client_address");
            app_client= new Client();

            InitializeComponent();
            //numericUpDown_clientAddresses.Maximum = 0;
            FillInfo(_id);
            FillAddress(_id/*, address_client_coll*/);

            foreach (ListBox Listbox in groupBox1.Controls.OfType<ListBox>())
                Listbox.Visible = false;
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (!EditMode)
            {
                foreach (TextBox item in groupBox1.Controls.OfType<TextBox>())
                {
                    if(item != txtBx_INN)
                        item.Enabled = true;
                }

                foreach (Button item in groupBox1.Controls.OfType<Button>())
                    item.Enabled = true;

                //numericUpDown_clientAddresses.Enabled = true;

                EditMode = true;

                old_client= new Client();
                old_client.Surname = txtBx_Surname.Text;
                old_client.Name = txtBx_Name.Text;
                old_client.Second_name = txtBx_Second_Name.Text;
                old_client.Phone = long.Parse(txtBx_Phone.Text);

                old_address = txtBx_Address.Text;

                btn_Edit.Text = "Завершить редактирование";
            }
            else
            {
                foreach (TextBox item in groupBox1.Controls.OfType<TextBox>())
                    item.Enabled = false;

                foreach (Button item in groupBox1.Controls.OfType<Button>())
                    if (item != btn_Edit  && item != btn_createNewUserAcc)
                        item.Enabled = false;
                
                EditMode = false;
                btn_Edit.Text = "Редактировать";
                listBox1.Visible = false;
                SaveChanges();
                FillAddress(_id);
            }
        }

        private void txtBx_Address_TextChanged(object sender, EventArgs e)
        {
            if (EditMode)
            {
                SelectedFromListBox = false;

                if (txtBx_Address.Text != "")
                    foreach (ListBox Listbox in groupBox1.Controls.OfType<ListBox>())
                        Listbox.Visible = true;
                else
                    foreach (ListBox Listbox in groupBox1.Controls.OfType<ListBox>())
                        Listbox.Visible = false;


                listBox1.Items.Clear();

                SuggestClient api = new SuggestClient(DaDataToken);
                var query = txtBx_Address.Text;
                var response = api.SuggestAddress(query);

                foreach (var item in response.suggestions)
                    listBox1.Items.Add(item.unrestricted_value);
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            try
            {
                txtBx_Address.Text = listBox1.SelectedItem.ToString();
                SelectedFromListBox = true;
            }
            catch(NullReferenceException) { }
        }

        private void FillAddress(long id/*, IMongoCollection<BsonDocument> client_address*/)
        {
            var client_address = db.GetCollection<BsonDocument>("client_address");
            var filter = new BsonDocument("ID_Client", id);
            var cursor = client_address.FindSync(filter);
            int count = 0;

            while (cursor.MoveNext())
            {
                var ID_addresses = cursor.Current;

                if (ID_addresses.Count() == 0)
                {
                    MessageBox.Show("Вы еще не завершили все этапы регистрации в системе банка, " +
                                    "для управления счетами добавьте свой хотя бы один адрес!",
                        "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    //numericUpDown_clientAddresses.Maximum = ID_addresses.Count();

                    ID_addresses_dict = new Dictionary<int, string>();

                    foreach (var address in ID_addresses)
                    {
                        ID_addresses_dict.Add(count + 1, address.GetValue("Address").ToString());
                        count++;
                    }


                    //numericUpDown_clientAddresses.Minimum = 1;
                }
            }
        }

        private void FillInfo(long id)
        {
            var filter = new BsonDocument("_id", id);
            var client_collection = db.GetCollection<BsonDocument>("clients");
            var cursor = client_collection.FindSync(filter);

            while (cursor.MoveNext())
            {
                var clients = cursor.Current;

                foreach (var client in clients)
                {
                    app_client.Surname = client.GetValue("Surname").ToString();
                    app_client.Name = client.GetValue("Name").ToString();
                    app_client.Second_name = client.GetValue("Second_name").ToString();
                    app_client.INN = client.GetValue("INN").AsInt64;
                    app_client.Phone = client.GetValue("Phone").AsInt64;
                }
            }

            txtBx_Surname.Text = app_client.Surname;
            txtBx_Name.Text = app_client.Name;
            txtBx_Second_Name.Text = app_client.Second_name;
            txtBx_INN.Text = app_client.INN.ToString();
            txtBx_Phone.Text = app_client.Phone.ToString();
        }

        private void AddAddress_btn_Click(object sender, EventArgs e)
        {
            //var id_address = numericUpDown_clientAddresses.Maximum;
            var client_address_collection = db.GetCollection<BsonDocument>("client_address");
            string address = "";

            for (int i = 0; i < txtBx_Address.Text.Length; i++)
            {
                if (txtBx_Address.Text[i] == 'д' && txtBx_Address.Text[i + 1] == ' '
                                                 && Char.IsDigit(txtBx_Address.Text, i + 2) && SelectedFromListBox)
                {
                    address = txtBx_Address.Text;
                    break;
                }

                else if (i == txtBx_Address.Text.Length - 2 && txtBx_Address.Text[i] != 'д' )
                {
                    MessageBox.Show("Адрес не заполнен до конца! " +
                                    "Пожалуйста выберите адрес из списка ниже!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            long ID_client_address = client_address_collection.CountDocuments(new BsonDocument());

            var client_address_bson = new BsonDocument
            {
                {"ID_Client", _id },
                {"Address", txtBx_Address.Text }
            };

            var cursor = client_address_collection.FindSync(client_address_bson);
            while (cursor.MoveNext())
            {
                var addresses = cursor.Current;
                if (addresses.Count() > 0)
                {
                    MessageBox.Show("Данный адрес уже записан!", "Info", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }
            }
            
            client_address_collection.InsertOne(client_address_bson);

            FillAddress(_id);

            MessageBox.Show("Адрес успешно добавлен!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RemoveAddress_btn_Click(object sender, EventArgs e)
        {
            BsonDocument filter;
            if (txtBx_Address.Text!="")
               filter = new BsonDocument("Address", txtBx_Address.Text);
            else
                return;

            var address_client_col = db.GetCollection<BsonDocument>("client_address");
            address_client_col.DeleteOne(filter);
            FillAddress(_id);
            MessageBox.Show("Адрес успешно удален!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateAddress_btn_Click(object sender, EventArgs e)
        {
            UpdateDefinition<BsonDocument> NewAddress = null;
            if (old_address != "")
            {
                var client_address_col = db.GetCollection<BsonDocument>("client_address");
                var filter = new BsonDocument
                {
                    {"ID_Client", _id },
                    {"Address", old_address }
                };

                for (int i = 0; i < txtBx_Address.Text.Length; i++)
                {
                    if (txtBx_Address.Text[i] == 'д' && txtBx_Address.Text[i + 1] == ' '
                                                     && Char.IsDigit(txtBx_Address.Text, i + 2) && SelectedFromListBox)
                    {
                        NewAddress = Builders<BsonDocument>.Update.Set("Address", txtBx_Address.Text);
                        break;
                    }

                    else if (i == txtBx_Address.Text.Length - 2 && txtBx_Address.Text[i] != 'д')
                    {
                        MessageBox.Show("Адрес не заполнен до конца! " +
                                        "Пожалуйста выберете адрес из списка ниже!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                var cursor = client_address_col.FindSync(filter);
                while (cursor.MoveNext())
                {
                    var addresses = cursor.Current;
                    if (addresses.Count() > 0)
                    {
                        MessageBox.Show("Данный адрес уже записан!", "Info", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        return;
                    }
                }

                client_address_col.UpdateOne(filter, NewAddress);
                FillAddress(_id);
                MessageBox.Show("updated");
            }
            else
            {
                MessageBox.Show("Старого адреса не существовало, будет добавлен новый!", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                AddAddress_btn.PerformClick();
            }
        }

        public void UpdateData()
        {
            try
            {
                var accsId = BankAccountManagement.GetUserBankAccounts(curUser);

                foreach (string id in accsId)
                {
                    ListViewItem lvi = new ListViewItem();

                    accInfo = BankAccountManagement.GetBankAccInfo(BankAccountManagement.GetUserBankAccId(id));

                    var isActive = (accInfo["isActive"] == "true") ? "Активен" : "Заморожен";

                    // установка названия файла
                    lvi.Name = id;
                    lvi.Text = "Счет под номером: " + id + ". " + "     Баланс: " + accInfo["balance"] + ".     Дата создания: " + accInfo["startDate"] + $".     {isActive}";
                    lvi.ImageIndex = 0; // установка картинки для файла
                                        // добавляем элемент в ListView
                    listV_accounts.Items.Add(lvi);
                    listV_accounts.Items.Add("");
                }
            }
            catch (Exception exc)
            {
                lbl_noAccounts.Visible = true;
            }
            
        }

        //private void Main_Load(object sender, EventArgs e)
        //{
        //    listV_accounts.Clear();
        //    this.BeginInvoke((MethodInvoker)(() => UpdateData()));
        //    //UpdateData();
        //}

        private void listV_accounts_ItemActivate(object sender, EventArgs e)
        {
            bankAccId = BankAccountManagement.GetUserBankAccId(listV_accounts.Items[lvSelectedIndex].Name);

            BankAccount bankAccForm = new BankAccount(curUser, accInfo, listV_accounts.Items[lvSelectedIndex].Name, bankAccId);
            bankAccForm.Text = $"Счет под номером: {listV_accounts.Items[lvSelectedIndex].Name}";
            bankAccForm.ShowDialog();
        }

        private void btn_createNewUserAcc_Click(object sender, EventArgs e)
        {
            CreateUserAccount userAccForm = new CreateUserAccount(curUser);
            userAccForm.Activate();
            userAccForm.ShowDialog();
        }

        private void Main_Activated_1(object sender, EventArgs e)
        {
            listV_accounts.Clear();
            this.BeginInvoke((MethodInvoker)(() => UpdateData()));
            //UpdateData();
        }

        private void listV_accounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvSelectedIndex = listV_accounts.FocusedItem.Index;
        }

        private void SaveChanges()
        {
            var cliets_collection = db.GetCollection<BsonDocument>("clients");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", _id);
            UpdateDefinition<BsonDocument> _surname = null,
                _name = null, _second_name = null, _phone = null;

            if (old_client.Surname != txtBx_Surname.Text)
                _surname = Builders<BsonDocument>.Update.Set("Surname", txtBx_Surname.Text);

            if (old_client.Name != txtBx_Name.Text)
                _name = Builders<BsonDocument>.Update.Set("Name", txtBx_Name.Text);

            if (old_client.Second_name != txtBx_Second_Name.Text)
                _second_name = Builders<BsonDocument>.Update.Set("Second_name", txtBx_Second_Name.Text);

            if (old_client.Phone != long.Parse(txtBx_Phone.Text))
                _phone = Builders<BsonDocument>.Update.Set("Phone", long.Parse(txtBx_Phone.Text));

            if (txtBx_Surname.Text != "" & txtBx_Name.Text != "" & txtBx_Phone.Text != "" & txtBx_Address.Text != "")
            {
                if (_surname != null)
                    cliets_collection.UpdateOne(filter, _surname);
                if (_name != null)
                    cliets_collection.UpdateOne(filter, _name);
                if (_second_name != null)
                    cliets_collection.UpdateOne(filter, _second_name);
                if (_phone != null)
                    cliets_collection.UpdateOne(filter, _phone);
            }
        }
    }
}