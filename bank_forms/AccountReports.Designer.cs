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
            this.dgw_info = new System.Windows.Forms.DataGridView();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_info)).BeginInit();
            this.SuspendLayout();
            // 
            // dgw_info
            // 
            this.dgw_info.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgw_info.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgw_info.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw_info.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.date,
            this.time,
            this.type,
            this.sum});
            this.dgw_info.Location = new System.Drawing.Point(3, 2);
            this.dgw_info.Name = "dgw_info";
            this.dgw_info.RowHeadersVisible = false;
            this.dgw_info.RowHeadersWidth = 51;
            this.dgw_info.RowTemplate.Height = 24;
            this.dgw_info.Size = new System.Drawing.Size(971, 420);
            this.dgw_info.TabIndex = 1;
            // 
            // date
            // 
            this.date.HeaderText = "Дата";
            this.date.MinimumWidth = 6;
            this.date.Name = "date";
            // 
            // time
            // 
            this.time.HeaderText = "Время";
            this.time.MinimumWidth = 6;
            this.time.Name = "time";
            // 
            // type
            // 
            this.type.HeaderText = "Тип операции";
            this.type.MinimumWidth = 6;
            this.type.Name = "type";
            // 
            // sum
            // 
            this.sum.HeaderText = "Сумма";
            this.sum.MinimumWidth = 6;
            this.sum.Name = "sum";
            // 
            // AccountReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 427);
            this.Controls.Add(this.dgw_info);
            this.Name = "AccountReports";
            this.Text = "Отчет по счету";
            this.Load += new System.EventHandler(this.AccountReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgw_info)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgw_info;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn sum;
    }
}