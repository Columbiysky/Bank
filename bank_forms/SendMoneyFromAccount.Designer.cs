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
            this.tb_recCardNumber = new System.Windows.Forms.TextBox();
            this.tb_moneyAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_transferToUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_recCardNumber
            // 
            this.tb_recCardNumber.Location = new System.Drawing.Point(411, 54);
            this.tb_recCardNumber.Name = "tb_recCardNumber";
            this.tb_recCardNumber.Size = new System.Drawing.Size(362, 22);
            this.tb_recCardNumber.TabIndex = 0;
            // 
            // tb_moneyAmount
            // 
            this.tb_moneyAmount.Location = new System.Drawing.Point(489, 166);
            this.tb_moneyAmount.Name = "tb_moneyAmount";
            this.tb_moneyAmount.Size = new System.Drawing.Size(193, 22);
            this.tb_moneyAmount.TabIndex = 1;
            this.tb_moneyAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_moneyAmount_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(418, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Номер карты или телефона получателя:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(506, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Сумма перевода:";
            // 
            // btn_transferToUser
            // 
            this.btn_transferToUser.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_transferToUser.Location = new System.Drawing.Point(570, 419);
            this.btn_transferToUser.Name = "btn_transferToUser";
            this.btn_transferToUser.Size = new System.Drawing.Size(216, 50);
            this.btn_transferToUser.TabIndex = 4;
            this.btn_transferToUser.Text = "Перевести деньги пользователю";
            this.btn_transferToUser.UseVisualStyleBackColor = true;
            this.btn_transferToUser.Click += new System.EventHandler(this.btn_transferToUser_Click);
            // 
            // SendMoneyFromAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 481);
            this.Controls.Add(this.btn_transferToUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_moneyAmount);
            this.Controls.Add(this.tb_recCardNumber);
            this.Name = "SendMoneyFromAccount";
            this.Text = "Перевод средств";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_recCardNumber;
        private System.Windows.Forms.TextBox tb_moneyAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_transferToUser;
    }
}