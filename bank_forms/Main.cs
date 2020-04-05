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
            //MessageBox.Show(txtBx_Address.Text);
            WebRequest get = WebRequest.Create($@"https://kladr-api.ru/api.php?query={txtBx_Address.Text}&withParent=1");
            get.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = get.GetResponse();
            textBox1.Text += ((HttpWebResponse) response).StatusDescription + "\r\n";

            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.  
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.  
                string responseFromServer = reader.ReadToEnd();
                // Display the content.  
                Console.WriteLine(responseFromServer);
            }

            response.Close();
        }
    }
}
