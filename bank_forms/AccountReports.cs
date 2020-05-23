using bank_forms.src.DBConnection;
using MongoDB.Bson;
using NUnit.Framework;
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
    public partial class AccountReports : Form
    {
        string clientAccId;

        public AccountReports(string clientAccId)
        {
            InitializeComponent();

            this.clientAccId = clientAccId;
        }

        private void AccountReports_Load(object sender, EventArgs e)
        {
            //ListViewItem lvi = new ListViewItem();

            //var operationInfo = GetReport(clientAccId);

            //// установка названия файла
            //lvi.Text = $"Дата: {operationInfo["date"]}. Время: {operationInfo["TransactionTime"]}. Тип транзакции: {operationInfo["Type"]} Сумма: {operationInfo["Sum"]}";
            //// добавляем элемент в ListView
            //lv_report.Items.Add(lvi);
        }

        private Dictionary<string, string> GetReport(string clientAccId)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            List<List> info = new List<List>();

            var client = DBConnect.GetConnection();
            var database = client.GetDatabase("bank");
            var collection = database.GetCollection<BsonDocument>("account_operations");

            var filter = new BsonDocument("bankAccId", ObjectId.Parse(clientAccId));
            var cursor = collection.FindSync<BsonDocument>(filter);

            var operationCollection = database.GetCollection<BsonDocument>("operations");

            while (cursor.MoveNext())
            {
                var records = cursor.Current;

                foreach (var record in records)
                {
                    string recordId = record.GetValue("operationId").ToString();

                    var operationFilter = new BsonDocument("_id", ObjectId.Parse(recordId));
                    var operationCursor = operationCollection.FindSync<BsonDocument>(operationFilter);

                    while (operationCursor.MoveNext())
                    {
                        var operationRecords = operationCursor.Current;

                        foreach (var cur in operationRecords)
                        {
                            //List<string> tmp = new List<string>();
                            //tmp.Add(cur.GetValue("OperationDate").ToString());
                            //tmp.Add(cur.GetValue("TransactionTime").ToString());
                            //tmp.Add(cur.GetValue("Type").ToString());
                            //tmp.Add(cur.GetValue("Sum").ToString());

                            //info.Add(tmp);

                            //result.Add("date", cur.GetValue("OperationDate").ToString());
                            //result.Add("TransactionTime", cur.GetValue("TransactionTime").ToString());
                            //result.Add("Type", cur.GetValue("Type").ToString());
                            //result.Add("Sum", cur.GetValue("Sum").ToString());
                        }
                    }
                }
            }



            return result;
        }
    }
}
