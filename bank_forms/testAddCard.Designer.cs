namespace bank_forms
{
    partial class testAddCard
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
            this.addCardBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnAddCard = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addCardBtn
            // 
            this.addCardBtn.Location = new System.Drawing.Point(97, 36);
            this.addCardBtn.Name = "addCardBtn";
            this.addCardBtn.Size = new System.Drawing.Size(158, 58);
            this.addCardBtn.TabIndex = 0;
            this.addCardBtn.Text = "Add Card";
            this.addCardBtn.UseVisualStyleBackColor = true;
            this.addCardBtn.Click += new System.EventHandler(this.addCardBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(87, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 59);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add creditCard";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(498, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(208, 81);
            this.button2.TabIndex = 2;
            this.button2.Text = "Create New UserBank Acc";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAddCard
            // 
            this.btnAddCard.Location = new System.Drawing.Point(473, 115);
            this.btnAddCard.Name = "btnAddCard";
            this.btnAddCard.Size = new System.Drawing.Size(256, 80);
            this.btnAddCard.TabIndex = 3;
            this.btnAddCard.Text = "Add a debit card to user acc";
            this.btnAddCard.UseVisualStyleBackColor = true;
            this.btnAddCard.Click += new System.EventHandler(this.btnAddCard_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(845, 44);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(207, 69);
            this.button3.TabIndex = 4;
            this.button3.Text = "Nu tupa test pizdec...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(73, 336);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(302, 84);
            this.button4.TabIndex = 5;
            this.button4.Text = "Get user bank acc";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(473, 216);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(256, 85);
            this.button5.TabIndex = 6;
            this.button5.Text = "Add a credit card to user acc";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(73, 439);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(302, 60);
            this.button6.TabIndex = 7;
            this.button6.Text = "Get bankAccId by userBankAcc";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // testAddCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 757);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnAddCard);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.addCardBtn);
            this.Name = "testAddCard";
            this.Text = "testAddCard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addCardBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnAddCard;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}