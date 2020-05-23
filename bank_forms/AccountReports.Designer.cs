namespace bank_forms
{
    partial class AccountReports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Дата операции: 15.04.2020; Время: 20:42:12; Тип: Пополнение счета; Сумма: 2000");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Дата операции: 20.04.2020; Время: 15:30:55; Тип: Пополнение счета; Сумма: 10000");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Дата операции: 21.04.2020; Время: 14:33:10; Тип: Перевод с карты; Сумма: 3200");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Дата операции: 21.04.2020; Время: 22:13:26; Тип: Пополнение счета; Сумма: 675");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("Дата операции: 23.04.2020; Время: 10:21:42; Тип: Перевод с карты; Сумма: 14200");
            this.lv_report = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lv_report
            // 
            this.lv_report.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lv_report.HideSelection = false;
            this.lv_report.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5});
            this.lv_report.Location = new System.Drawing.Point(3, 2);
            this.lv_report.Name = "lv_report";
            this.lv_report.Size = new System.Drawing.Size(780, 487);
            this.lv_report.TabIndex = 0;
            this.lv_report.UseCompatibleStateImageBehavior = false;
            this.lv_report.View = System.Windows.Forms.View.SmallIcon;
            // 
            // AccountReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 493);
            this.Controls.Add(this.lv_report);
            this.Name = "AccountReports";
            this.Text = "Отчет по счету";
            this.Load += new System.EventHandler(this.AccountReports_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lv_report;
    }
}