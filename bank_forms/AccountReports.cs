using bank_forms.src.BankAccount;
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
            var operationInfo = GetReport(clientAccId);
            var cardOperationInfo = GetReportFromCards(clientAccId);

            foreach (var elem in operationInfo)
            {
                dgw_info.Rows.Add(elem["date"], elem["TransactionTime"], elem["Type"], elem["Sum"]);
            }

            foreach (var elem in cardOperationInfo)
            {
                dgw_info.Rows.Add(elem["date"], elem["TransactionTime"], elem["Type"], elem["Sum"]);
            }
        }

        private List<Dictionary<string, string>> GetReport(string clientAccId)
        {
            List<Dictionary<string, string>> info = new List<Dictionary<string, string>>();

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
                            Dictionary<string, string> result = new Dictionary<string, string>();

                            result.Add("date", cur.GetValue("OperationDate").ToString());
                            result.Add("TransactionTime", cur.GetValue("TransactionTime").ToString());
                            result.Add("Type", cur.GetValue("Type").ToString());
                            result.Add("Sum", cur.GetValue("Sum").ToString());

                            info.Add(result);
                        }
                    }
                }
            }

            return info;
        }

        private List<Dictionary<string, string>> GetReportFromCards(string clientAccId)
        {
            List<Dictionary<string, string>> info = new List<Dictionary<string, string>>();

            var client = DBConnect.GetConnection();
            var database = client.GetDatabase("bank");
            var collection = database.GetCollection<BsonDocument>("card_operations");

            var userCards = BankAccountManagement.GetUserBankAccCards(clientAccId);

            foreach (var card in userCards)
            {
                string userAccCardId = BankAccountManagement.GetUserCardId(card);

                var filter = new BsonDocument("clientCardId", ObjectId.Parse(userAccCardId));
                var cursor = collection.FindSync<BsonDocument>(filter);

                while (cursor.MoveNext())
                {
                    var records = cursor.Current;

                    foreach (var record in records)
                    {
                        string recordId = record.GetValue("operationId").ToString();

                        var operationCollection = database.GetCollection<BsonDocument>("operations");

                        var operationFilter = new BsonDocument("_id", ObjectId.Parse(recordId));
                        var operationCursor = operationCollection.FindSync<BsonDocument>(operationFilter);

                        while (operationCursor.MoveNext())
                        {
                            var operationRecords = operationCursor.Current;

                            foreach (var cur in operationRecords)
                            {
                                Dictionary<string, string> result = new Dictionary<string, string>();

                                result.Add("date", cur.GetValue("OperationDate").ToString());
                                result.Add("TransactionTime", cur.GetValue("TransactionTime").ToString());
                                result.Add("Type", cur.GetValue("Type").ToString());
                                result.Add("Sum", cur.GetValue("Sum").ToString());

                                info.Add(result);
                            }
                        }
                    }
                }
            }

            return info;
        }
    }
}
