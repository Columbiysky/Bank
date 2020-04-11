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

namespace bank_forms
{
    public partial class Main : Form
    {
        private MongoClient client;
        string DaDataToken = "481cdec20e319b938eb5fbff21fed0bee64a4706";
        //string DaDataSecret = "815788af76613100cd9df99ac7d86d96e0c18564";
        private bool nodata = false;

        public Main(MongoClient client_)
        {

            StartPosition = FormStartPosition.CenterScreen;
            client = client_;
            var db = client.GetDatabase("bank");
            var address_coll= db.GetCollection<BsonDocument>("address");
            var address_client_coll = db.GetCollection<BsonDocument>("client_address");

            InitializeComponent();
            foreach (ListBox Listbox in groupBox1.Controls.OfType<ListBox>())
                Listbox.Visible = false;
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            foreach (TextBox item in groupBox1.Controls.OfType<TextBox>())
                item.Enabled = true;
        }

        private void txtBx_Address_TextChanged(object sender, EventArgs e)
        {
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

        private void listBox1_Click(object sender, EventArgs e) => 
            txtBx_Address.Text = listBox1.SelectedItem.ToString();

        private BsonDocument Get_client_address(BsonDocument ID_CLIENT, IMongoDatabase db)
        {
            var client_address_collection = db.GetCollection<BsonDocument>("client_address");
            var cursor = client_address_collection.FindSync(ID_CLIENT);
            BsonDocument client_address_bson = null;

            while (cursor.MoveNext())
            {
                var res = cursor.Current;
                if (res.Count() == 0)
                    throw new ArgumentNullException("Записи не найдены!");
                else
                    foreach (var doc in res)
                        client_address_bson = doc;
            }

            var id_address = client_address_bson.GetValue("ID_address");
            var address_collection = db.GetCollection<BsonDocument>("address");
            cursor = address_collection.FindSync(new BsonDocument("ID_address", id_address));
            BsonDocument address_bson = null;

            while (cursor.MoveNext())
            {
                var res = cursor.Current;
                if(res.Count()==0)
                    throw new ArgumentNullException("Записи не найдены!");
                else
                    foreach (var doc in res)
                        address_bson = doc;
            }



            return null;
        }
    }
}
