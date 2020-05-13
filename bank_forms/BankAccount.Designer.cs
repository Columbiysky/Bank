namespace bank_forms
{
    partial class BankAccount
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
            this.btn_addDebitCard = new System.Windows.Forms.Button();
            this.btn_getCreditCard = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lv_clientCards = new System.Windows.Forms.ListView();
            this.btn_transferMoney = new System.Windows.Forms.Button();
            this.lbl_accType = new System.Windows.Forms.Label();
            this.lbl_accBalance = new System.Windows.Forms.Label();
            this.lbl_accStart = new System.Windows.Forms.Label();
            this.lbl_accFinish = new System.Windows.Forms.Label();
            this.lbl_accId = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_noCards = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_addDebitCard
            // 
            this.btn_addDebitCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_addDebitCard.Location = new System.Drawing.Point(222, 487);
            this.btn_addDebitCard.Name = "btn_addDebitCard";
            this.btn_addDebitCard.Size = new System.Drawing.Size(196, 49);
            this.btn_addDebitCard.TabIndex = 0;
            this.btn_addDebitCard.Text = "Добавить дебетовую карту";
            this.btn_addDebitCard.UseVisualStyleBackColor = true;
            // 
            // btn_getCreditCard
            // 
            this.btn_getCreditCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_getCreditCard.Location = new System.Drawing.Point(431, 487);
            this.btn_getCreditCard.Name = "btn_getCreditCard";
            this.btn_getCreditCard.Size = new System.Drawing.Size(196, 49);
            this.btn_getCreditCard.TabIndex = 1;
            this.btn_getCreditCard.Text = "Оформить кредит";
            this.btn_getCreditCard.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lv_clientCards);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(633, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(361, 545);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ваши карты:";
            // 
            // lv_clientCards
            // 
            this.lv_clientCards.BackColor = System.Drawing.SystemColors.Control;
            this.lv_clientCards.HideSelection = false;
            this.lv_clientCards.Location = new System.Drawing.Point(3, 29);
            this.lv_clientCards.Name = "lv_clientCards";
            this.lv_clientCards.Size = new System.Drawing.Size(353, 511);
            this.lv_clientCards.TabIndex = 4;
            this.lv_clientCards.UseCompatibleStateImageBehavior = false;
            this.lv_clientCards.View = System.Windows.Forms.View.List;
            // 
            // btn_transferMoney
            // 
            this.btn_transferMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_transferMoney.Location = new System.Drawing.Point(12, 487);
            this.btn_transferMoney.Name = "btn_transferMoney";
            this.btn_transferMoney.Size = new System.Drawing.Size(196, 49);
            this.btn_transferMoney.TabIndex = 4;
            this.btn_transferMoney.Text = "Совершить \r\nперевод";
            this.btn_transferMoney.UseVisualStyleBackColor = true;
            // 
            // lbl_accType
            // 
            this.lbl_accType.AutoSize = true;
            this.lbl_accType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_accType.Location = new System.Drawing.Point(8, 82);
            this.lbl_accType.Name = "lbl_accType";
            this.lbl_accType.Size = new System.Drawing.Size(125, 20);
            this.lbl_accType.TabIndex = 5;
            this.lbl_accType.Text = "Тип аккаунта:";
            // 
            // lbl_accBalance
            // 
            this.lbl_accBalance.AutoSize = true;
            this.lbl_accBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_accBalance.Location = new System.Drawing.Point(8, 130);
            this.lbl_accBalance.Name = "lbl_accBalance";
            this.lbl_accBalance.Size = new System.Drawing.Size(75, 20);
            this.lbl_accBalance.TabIndex = 5;
            this.lbl_accBalance.Text = "Баланс:";
            // 
            // lbl_accStart
            // 
            this.lbl_accStart.AutoSize = true;
            this.lbl_accStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_accStart.Location = new System.Drawing.Point(8, 185);
            this.lbl_accStart.Name = "lbl_accStart";
            this.lbl_accStart.Size = new System.Drawing.Size(143, 20);
            this.lbl_accStart.TabIndex = 5;
            this.lbl_accStart.Text = "Дата открытия:";
            // 
            // lbl_accFinish
            // 
            this.lbl_accFinish.AutoSize = true;
            this.lbl_accFinish.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_accFinish.Location = new System.Drawing.Point(8, 240);
            this.lbl_accFinish.Name = "lbl_accFinish";
            this.lbl_accFinish.Size = new System.Drawing.Size(142, 20);
            this.lbl_accFinish.TabIndex = 5;
            this.lbl_accFinish.Text = "Дата закрытия:";
            // 
            // lbl_accId
            // 
            this.lbl_accId.AutoSize = true;
            this.lbl_accId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_accId.Location = new System.Drawing.Point(8, 32);
            this.lbl_accId.Name = "lbl_accId";
            this.lbl_accId.Size = new System.Drawing.Size(260, 20);
            this.lbl_accId.TabIndex = 5;
            this.lbl_accId.Text = "Номер банковского аккаунта:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 17);
            this.label7.TabIndex = 5;
            // 
            // lbl_noCards
            // 
            this.lbl_noCards.AutoSize = true;
            this.lbl_noCards.Location = new System.Drawing.Point(213, 441);
            this.lbl_noCards.Name = "lbl_noCards";
            this.lbl_noCards.Size = new System.Drawing.Size(215, 34);
            this.lbl_noCards.TabIndex = 6;
            this.lbl_noCards.Text = "У Вас еще нет ни одной карты,\r\n хотите добавить?";
            this.lbl_noCards.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_noCards.Visible = false;
            // 
            // BankAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 548);
            this.Controls.Add(this.lbl_noCards);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbl_accFinish);
            this.Controls.Add(this.lbl_accStart);
            this.Controls.Add(this.lbl_accBalance);
            this.Controls.Add(this.lbl_accId);
            this.Controls.Add(this.lbl_accType);
            this.Controls.Add(this.btn_transferMoney);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_getCreditCard);
            this.Controls.Add(this.btn_addDebitCard);
            this.Name = "BankAccount";
            this.Text = "BankAccount";
            this.Load += new System.EventHandler(this.BankAccount_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_addDebitCard;
        private System.Windows.Forms.Button btn_getCreditCard;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lv_clientCards;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_transferMoney;
        private System.Windows.Forms.Label lbl_accType;
        private System.Windows.Forms.Label lbl_accBalance;
        private System.Windows.Forms.Label lbl_accStart;
        private System.Windows.Forms.Label lbl_accFinish;
        private System.Windows.Forms.Label lbl_accId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_noCards;
    }
}