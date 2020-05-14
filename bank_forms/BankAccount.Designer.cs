﻿namespace bank_forms
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
            this.lv_clientCards = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_transferMoney = new System.Windows.Forms.Button();
            this.lbl_accType = new System.Windows.Forms.Label();
            this.lbl_accBalance = new System.Windows.Forms.Label();
            this.lbl_accStart = new System.Windows.Forms.Label();
            this.lbl_accFinish = new System.Windows.Forms.Label();
            this.lbl_accId = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_noCards = new System.Windows.Forms.Label();
            this.btn_transferMoneyToCard = new System.Windows.Forms.Button();
            this.tb_moneyAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_addMoney = new System.Windows.Forms.Button();
            this.tb_addMoney = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_addDebitCard
            // 
            this.btn_addDebitCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_addDebitCard.Location = new System.Drawing.Point(157, 567);
            this.btn_addDebitCard.Name = "btn_addDebitCard";
            this.btn_addDebitCard.Size = new System.Drawing.Size(196, 49);
            this.btn_addDebitCard.TabIndex = 0;
            this.btn_addDebitCard.Text = "Добавить дебетовую карту";
            this.btn_addDebitCard.UseVisualStyleBackColor = true;
            this.btn_addDebitCard.Click += new System.EventHandler(this.btn_addDebitCard_Click);
            // 
            // btn_getCreditCard
            // 
            this.btn_getCreditCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_getCreditCard.Location = new System.Drawing.Point(359, 567);
            this.btn_getCreditCard.Name = "btn_getCreditCard";
            this.btn_getCreditCard.Size = new System.Drawing.Size(146, 49);
            this.btn_getCreditCard.TabIndex = 1;
            this.btn_getCreditCard.Text = "Оформить кредит";
            this.btn_getCreditCard.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lv_clientCards);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(713, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(470, 615);
            this.panel1.TabIndex = 3;
            // 
            // lv_clientCards
            // 
            this.lv_clientCards.BackColor = System.Drawing.SystemColors.Control;
            this.lv_clientCards.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lv_clientCards.HideSelection = false;
            this.lv_clientCards.Location = new System.Drawing.Point(3, 29);
            this.lv_clientCards.MaximumSize = new System.Drawing.Size(462, 581);
            this.lv_clientCards.MinimumSize = new System.Drawing.Size(462, 581);
            this.lv_clientCards.Name = "lv_clientCards";
            this.lv_clientCards.Size = new System.Drawing.Size(462, 581);
            this.lv_clientCards.TabIndex = 4;
            this.lv_clientCards.UseCompatibleStateImageBehavior = false;
            this.lv_clientCards.View = System.Windows.Forms.View.SmallIcon;
            this.lv_clientCards.ItemActivate += new System.EventHandler(this.lv_clientCards_ItemActivate);
            this.lv_clientCards.SelectedIndexChanged += new System.EventHandler(this.lv_clientCards_SelectedIndexChanged);
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
            // btn_transferMoney
            // 
            this.btn_transferMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_transferMoney.Location = new System.Drawing.Point(5, 567);
            this.btn_transferMoney.Name = "btn_transferMoney";
            this.btn_transferMoney.Size = new System.Drawing.Size(146, 49);
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
            this.lbl_noCards.Location = new System.Drawing.Point(154, 521);
            this.lbl_noCards.Name = "lbl_noCards";
            this.lbl_noCards.Size = new System.Drawing.Size(215, 34);
            this.lbl_noCards.TabIndex = 6;
            this.lbl_noCards.Text = "У Вас еще нет ни одной карты,\r\n хотите добавить?";
            this.lbl_noCards.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_noCards.Visible = false;
            // 
            // btn_transferMoneyToCard
            // 
            this.btn_transferMoneyToCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_transferMoneyToCard.Location = new System.Drawing.Point(511, 567);
            this.btn_transferMoneyToCard.Name = "btn_transferMoneyToCard";
            this.btn_transferMoneyToCard.Size = new System.Drawing.Size(196, 49);
            this.btn_transferMoneyToCard.TabIndex = 7;
            this.btn_transferMoneyToCard.Text = "Перевести средства на карту";
            this.btn_transferMoneyToCard.UseVisualStyleBackColor = true;
            this.btn_transferMoneyToCard.Click += new System.EventHandler(this.btn_transferMoneyToCard_Click);
            // 
            // tb_moneyAmount
            // 
            this.tb_moneyAmount.Location = new System.Drawing.Point(511, 539);
            this.tb_moneyAmount.Name = "tb_moneyAmount";
            this.tb_moneyAmount.Size = new System.Drawing.Size(196, 22);
            this.tb_moneyAmount.TabIndex = 8;
            this.tb_moneyAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(554, 519);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Сумма перевода:";
            // 
            // btn_addMoney
            // 
            this.btn_addMoney.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_addMoney.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_addMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_addMoney.Location = new System.Drawing.Point(5, 322);
            this.btn_addMoney.Name = "btn_addMoney";
            this.btn_addMoney.Size = new System.Drawing.Size(189, 41);
            this.btn_addMoney.TabIndex = 10;
            this.btn_addMoney.Text = "Пополнить баланс";
            this.btn_addMoney.UseVisualStyleBackColor = true;
            this.btn_addMoney.Click += new System.EventHandler(this.btn_addMoney_Click);
            // 
            // tb_addMoney
            // 
            this.tb_addMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_addMoney.Location = new System.Drawing.Point(211, 329);
            this.tb_addMoney.Name = "tb_addMoney";
            this.tb_addMoney.Size = new System.Drawing.Size(163, 27);
            this.tb_addMoney.TabIndex = 11;
            this.tb_addMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BankAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 628);
            this.Controls.Add(this.tb_addMoney);
            this.Controls.Add(this.btn_addMoney);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_moneyAmount);
            this.Controls.Add(this.btn_transferMoneyToCard);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.Button btn_transferMoneyToCard;
        private System.Windows.Forms.TextBox tb_moneyAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_addMoney;
        private System.Windows.Forms.TextBox tb_addMoney;
    }
}