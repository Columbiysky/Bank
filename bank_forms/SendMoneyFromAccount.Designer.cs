namespace bank_forms
{
    partial class SendMoneyFromAccount
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
            this.tb_recAccountId = new System.Windows.Forms.TextBox();
            this.tb_moneyAmount1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_transferToUser1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_transferToUser2 = new System.Windows.Forms.Button();
            this.tb_moneyAmount2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_recCardNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_transferSomewhere = new System.Windows.Forms.Button();
            this.tb_moneyAmount3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_transferDestination = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_recAccountId
            // 
            this.tb_recAccountId.Location = new System.Drawing.Point(3, 32);
            this.tb_recAccountId.Name = "tb_recAccountId";
            this.tb_recAccountId.Size = new System.Drawing.Size(291, 22);
            this.tb_recAccountId.TabIndex = 0;
            this.tb_recAccountId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_moneyAmount1
            // 
            this.tb_moneyAmount1.Location = new System.Drawing.Point(3, 109);
            this.tb_moneyAmount1.Name = "tb_moneyAmount1";
            this.tb_moneyAmount1.Size = new System.Drawing.Size(193, 22);
            this.tb_moneyAmount1.TabIndex = 1;
            this.tb_moneyAmount1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_moneyAmount1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_moneyAmount1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Номер счета получателя:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(10, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Сумма перевода:";
            // 
            // btn_transferToUser1
            // 
            this.btn_transferToUser1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_transferToUser1.Location = new System.Drawing.Point(-1, 383);
            this.btn_transferToUser1.Name = "btn_transferToUser1";
            this.btn_transferToUser1.Size = new System.Drawing.Size(299, 50);
            this.btn_transferToUser1.TabIndex = 4;
            this.btn_transferToUser1.Text = "Перевести средства";
            this.btn_transferToUser1.UseVisualStyleBackColor = true;
            this.btn_transferToUser1.Click += new System.EventHandler(this.btn_transferToUser1_Click_1);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_transferToUser1);
            this.panel1.Controls.Add(this.tb_moneyAmount1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tb_recAccountId);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 434);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btn_transferToUser2);
            this.panel2.Controls.Add(this.tb_moneyAmount2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.tb_recCardNumber);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(302, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(299, 434);
            this.panel2.TabIndex = 5;
            // 
            // btn_transferToUser2
            // 
            this.btn_transferToUser2.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_transferToUser2.Location = new System.Drawing.Point(-1, 383);
            this.btn_transferToUser2.Name = "btn_transferToUser2";
            this.btn_transferToUser2.Size = new System.Drawing.Size(299, 50);
            this.btn_transferToUser2.TabIndex = 4;
            this.btn_transferToUser2.Text = "Перевести средства";
            this.btn_transferToUser2.UseVisualStyleBackColor = true;
            this.btn_transferToUser2.Click += new System.EventHandler(this.btn_transferToUser2_Click);
            // 
            // tb_moneyAmount2
            // 
            this.tb_moneyAmount2.Location = new System.Drawing.Point(3, 109);
            this.tb_moneyAmount2.Name = "tb_moneyAmount2";
            this.tb_moneyAmount2.Size = new System.Drawing.Size(193, 22);
            this.tb_moneyAmount2.TabIndex = 1;
            this.tb_moneyAmount2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_moneyAmount2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_moneyAmount2_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(10, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "Сумма перевода:";
            // 
            // tb_recCardNumber
            // 
            this.tb_recCardNumber.Location = new System.Drawing.Point(3, 32);
            this.tb_recCardNumber.Name = "tb_recCardNumber";
            this.tb_recCardNumber.Size = new System.Drawing.Size(291, 22);
            this.tb_recCardNumber.TabIndex = 0;
            this.tb_recCardNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_recCardNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_recCardNumber_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(10, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(228, 22);
            this.label4.TabIndex = 2;
            this.label4.Text = "Номер карты получателя:";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btn_transferSomewhere);
            this.panel3.Controls.Add(this.tb_moneyAmount3);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.tb_transferDestination);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(603, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(299, 434);
            this.panel3.TabIndex = 6;
            // 
            // btn_transferSomewhere
            // 
            this.btn_transferSomewhere.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_transferSomewhere.Location = new System.Drawing.Point(-1, 383);
            this.btn_transferSomewhere.Name = "btn_transferSomewhere";
            this.btn_transferSomewhere.Size = new System.Drawing.Size(299, 50);
            this.btn_transferSomewhere.TabIndex = 4;
            this.btn_transferSomewhere.Text = "Перевести средства";
            this.btn_transferSomewhere.UseVisualStyleBackColor = true;
            this.btn_transferSomewhere.Click += new System.EventHandler(this.btn_transferSomewhere_Click);
            // 
            // tb_moneyAmount3
            // 
            this.tb_moneyAmount3.Location = new System.Drawing.Point(3, 109);
            this.tb_moneyAmount3.Name = "tb_moneyAmount3";
            this.tb_moneyAmount3.Size = new System.Drawing.Size(193, 22);
            this.tb_moneyAmount3.TabIndex = 1;
            this.tb_moneyAmount3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_moneyAmount3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_moneyAmount3_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(10, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 22);
            this.label5.TabIndex = 3;
            this.label5.Text = "Сумма перевода:";
            // 
            // tb_transferDestination
            // 
            this.tb_transferDestination.Location = new System.Drawing.Point(3, 32);
            this.tb_transferDestination.Name = "tb_transferDestination";
            this.tb_transferDestination.Size = new System.Drawing.Size(291, 22);
            this.tb_transferDestination.TabIndex = 0;
            this.tb_transferDestination.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(10, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(197, 22);
            this.label6.TabIndex = 2;
            this.label6.Text = "Назначение перевода:";
            // 
            // SendMoneyFromAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 442);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(923, 489);
            this.MinimumSize = new System.Drawing.Size(623, 489);
            this.Name = "SendMoneyFromAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Перевод средств";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tb_recAccountId;
        private System.Windows.Forms.TextBox tb_moneyAmount1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_transferToUser1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_transferToUser2;
        private System.Windows.Forms.TextBox tb_moneyAmount2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_recCardNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_transferSomewhere;
        private System.Windows.Forms.TextBox tb_moneyAmount3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_transferDestination;
        private System.Windows.Forms.Label label6;
    }
}