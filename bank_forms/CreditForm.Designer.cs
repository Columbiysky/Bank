namespace bank_forms
{
    partial class CreditForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_getCredit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tb_payouts = new System.Windows.Forms.TextBox();
            this.tb_creditSum = new System.Windows.Forms.TextBox();
            this.tb_creditDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_years = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_finalSum = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(93, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Сумма кредита:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(86, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Дата окончания:";
            // 
            // btn_getCredit
            // 
            this.btn_getCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_getCredit.Location = new System.Drawing.Point(503, 452);
            this.btn_getCredit.Name = "btn_getCredit";
            this.btn_getCredit.Size = new System.Drawing.Size(259, 70);
            this.btn_getCredit.TabIndex = 3;
            this.btn_getCredit.Text = "Оформить кредит и заказать \r\nкредитную карту";
            this.btn_getCredit.UseVisualStyleBackColor = true;
            this.btn_getCredit.Click += new System.EventHandler(this.btn_getCredit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(586, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Процентная ставка:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(733, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "10%";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::bank_forms.Properties.Resources.bank_ico;
            this.panel1.Location = new System.Drawing.Point(25, 266);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(257, 256);
            this.panel1.TabIndex = 6;
            // 
            // tb_payouts
            // 
            this.tb_payouts.Location = new System.Drawing.Point(243, 161);
            this.tb_payouts.Name = "tb_payouts";
            this.tb_payouts.ReadOnly = true;
            this.tb_payouts.Size = new System.Drawing.Size(201, 22);
            this.tb_payouts.TabIndex = 8;
            this.tb_payouts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_creditSum
            // 
            this.tb_creditSum.Location = new System.Drawing.Point(243, 27);
            this.tb_creditSum.Name = "tb_creditSum";
            this.tb_creditSum.Size = new System.Drawing.Size(201, 22);
            this.tb_creditSum.TabIndex = 8;
            this.tb_creditSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_creditSum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_creditSum_KeyPress);
            this.tb_creditSum.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_creditSum_KeyUp);
            // 
            // tb_creditDate
            // 
            this.tb_creditDate.Location = new System.Drawing.Point(243, 119);
            this.tb_creditDate.Name = "tb_creditDate";
            this.tb_creditDate.ReadOnly = true;
            this.tb_creditDate.Size = new System.Drawing.Size(201, 22);
            this.tb_creditDate.TabIndex = 9;
            this.tb_creditDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(106, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Срок кредита:";
            // 
            // cb_years
            // 
            this.cb_years.FormattingEnabled = true;
            this.cb_years.Location = new System.Drawing.Point(243, 74);
            this.cb_years.Name = "cb_years";
            this.cb_years.Size = new System.Drawing.Size(72, 24);
            this.cb_years.TabIndex = 10;
            this.cb_years.SelectedIndexChanged += new System.EventHandler(this.cb_years_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(102, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Сумма выплат:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(21, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(216, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "Итоговая сумма выплат:";
            // 
            // tb_finalSum
            // 
            this.tb_finalSum.Location = new System.Drawing.Point(243, 202);
            this.tb_finalSum.Name = "tb_finalSum";
            this.tb_finalSum.ReadOnly = true;
            this.tb_finalSum.Size = new System.Drawing.Size(201, 22);
            this.tb_finalSum.TabIndex = 12;
            this.tb_finalSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CreditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(774, 534);
            this.Controls.Add(this.tb_finalSum);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cb_years);
            this.Controls.Add(this.tb_creditDate);
            this.Controls.Add(this.tb_creditSum);
            this.Controls.Add(this.tb_payouts);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_getCredit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(792, 581);
            this.MinimumSize = new System.Drawing.Size(792, 581);
            this.Name = "CreditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Оформление кредита";
            this.Load += new System.EventHandler(this.CreditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_getCredit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tb_payouts;
        private System.Windows.Forms.TextBox tb_creditSum;
        private System.Windows.Forms.TextBox tb_creditDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_years;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_finalSum;
    }
}