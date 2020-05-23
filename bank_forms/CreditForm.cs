using bank_forms.src.BankAccount;
using bank_forms.src.DBConnection;
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
    public partial class CreditForm : Form
    {
        IClient client;

        string userAccId;
        int years;

        public CreditForm(IClient client, string userAccId)
        {
            InitializeComponent();

            this.client = client;
            this.userAccId = userAccId;
        }

        private void CreditForm_Load(object sender, EventArgs e)
        {
            cb_years.Items.Add("1");
            cb_years.Items.Add("2");
            cb_years.Items.Add("3");

            DateTime creditDate = DateTime.Now;
            tb_creditDate.Text = creditDate.AddYears(3).ToString("dd/mm/yyyy");
        }

        private void cb_years_SelectedIndexChanged(object sender, EventArgs e)
        {
            years = Convert.ToInt32(cb_years.SelectedItem.ToString());

            DateTime creditDate = DateTime.Now;
            tb_creditDate.Text = creditDate.AddYears(years).ToString("dd/mm/yyyy");

            decimal creditSum = Convert.ToDecimal(tb_creditSum.Text);

            decimal finalSum;

            tb_payouts.Text = Math.Round(GetPayouts(years, creditSum, 10, out finalSum), 2).ToString();
            tb_finalSum.Text = (finalSum + creditSum).ToString();
        }

        private void btn_getCredit_Click(object sender, EventArgs e)
        {
            if (tb_creditSum.Text == "" || tb_payouts.Text == "" || tb_finalSum.Text == "")
            {
                MessageBox.Show("Пожалуйста, заполните все поля");
            }
            else
            {
                BankAccountManagement.CreateCreditCardForClient
                (
                    DBConnect.GetConnection(), 
                    client,
                    Convert.ToInt32(tb_creditSum.Text),
                    userAccId, 
                    tb_creditDate.Text, 
                    10, 
                    Convert.ToInt32(tb_creditSum.Text)
                 );

                MessageBox.Show("Кредит оформлен, карта доступна к использованию");
                this.Close();
            }
        }

        private decimal GetPayouts(int years, decimal sum, int percent, out decimal finalSum)
        {
            decimal everyYearSum = sum * percent / 100;

            finalSum = everyYearSum * (decimal)years;

            return finalSum / 12;
        }

        private void tb_creditSum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) return;
            else
                e.Handled = true;      
        }

        private void tb_creditSum_KeyUp(object sender, KeyEventArgs e)
        {
            decimal sum = Convert.ToDecimal(tb_creditSum.Text);
            if (sum > 500000)
            {
                MessageBox.Show("Максимальная сумма кредита 500 000 руб.");
                tb_creditSum.Clear();
            }
        }
    }
}
