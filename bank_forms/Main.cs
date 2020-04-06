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
using MongoDB.Bson;

namespace bank_forms
{
    public partial class Main : Form
    {
        private MongoClient client;
        public Main(MongoClient client_)
        {
            StartPosition = FormStartPosition.CenterScreen;
            client = client_;
            InitializeComponent();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            foreach (TextBox item in groupBox1.Controls.OfType<TextBox>())
                item.Enabled = true;


        }

        private void txtBx_Address_TextChanged(object sender, EventArgs e)
        {
            //string token = "iAte5kDtsGdN89DR67eKar74TByKS6Ds";
            ////MessageBox.Show(txtBx_Address.Text);
            ////WebRequest get = WebRequest.Create("https://kladr-api.ru/api.php?query=" + txtBx_Address.Text /*+"&withParent=1"*/);
            //WebRequest get = WebRequest.Create("https://kladr-api.ru/api.php?query=" + txtBx_Address.Text
            //                                                                        + "&oneString=1&limit=3&withParent=1");
            //get.Credentials = CredentialCache.DefaultCredentials;
            //WebResponse response = get.GetResponse();
            //textBox1.Text += ((HttpWebResponse)response).StatusDescription + "\r\n";

            //using (Stream dataStream = response.GetResponseStream())
            //{
            //    //Open the stream using a StreamReader for easy access.  

            //   StreamReader reader = new StreamReader(dataStream);
            //   // Read the content.
            //    string responseFromServer = reader.ReadLine();
            //    //Display the content.
            //   textBox1.Text += responseFromServer + "\r\n\n\n";
            //}

            //response.Close();

            string DaDataToken = "481cdec20e319b938eb5fbff21fed0bee64a4706";
            string DaDataSecret = "815788af76613100cd9df99ac7d86d96e0c18564";
            SuggestClient api = new SuggestClient(DaDataToken);
            var query = txtBx_Address.Text;
            var response = api.SuggestAddress(query);
            var address_data = response.suggestions[0].data;
            textBox1.Text += address_data.city + " " + address_data.city_type + " " + address_data.area + " " + address_data.area_type +
                            " " + address_data.city_district + " "+ address_data.city_district_type + " "+
                            address_data.street+ "\r\n\n";

            //foreach (var item in response.Result.Suggestions)
            //{
            //    textBox1.Text += item.Data.City;
            //}

            //string token = "5e8a03b3f320ccdf6dcbb965"; //http://kladr.mnogo.ru/keys
            //KladrClient kladr = new KladrClient(token, "");
            //kladr.FindAddress(new Dictionary<string, string>
            //{
            //    {"query", txtBx_Address.Text },
            //    {"contentType","city" },
            //    {"withParent", "1"},
            //    {"limit", "2"}
            //}, fetchedAddress);



        }

        private void fetchedAddress(KladrResponse response)
        {
            if (response != null)
            {
                if (response.result != null && response.InfoMessage.Equals("OK"))
                    foreach (var item in response.result)
                    {
                        textBox1.Text += item.name + " " +item.type + " "+ item.zip +" "/*+ item.parents.GetValue(0,1,2).ToString()*/ +"\r\n";
                        //item.
                    }
            }
        }
    }
}
