namespace bank_forms
{
    partial class Main
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_noAccounts = new System.Windows.Forms.Label();
            this.btn_createNewUserAcc = new System.Windows.Forms.Button();
            this.UpdateAddress_btn = new System.Windows.Forms.Button();
            this.RemoveAddress_btn = new System.Windows.Forms.Button();
            this.AddAddress_btn = new System.Windows.Forms.Button();
            this.txtBx_INN = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.txtBx_Address = new System.Windows.Forms.TextBox();
            this.txtBx_Phone = new System.Windows.Forms.TextBox();
            this.txtBx_Second_Name = new System.Windows.Forms.TextBox();
            this.txtBx_Name = new System.Windows.Forms.TextBox();
            this.txtBx_Surname = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listV_accounts = new System.Windows.Forms.ListView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.lbl_noAccounts);
            this.groupBox1.Controls.Add(this.btn_createNewUserAcc);
            this.groupBox1.Controls.Add(this.UpdateAddress_btn);
            this.groupBox1.Controls.Add(this.RemoveAddress_btn);
            this.groupBox1.Controls.Add(this.AddAddress_btn);
            this.groupBox1.Controls.Add(this.txtBx_INN);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Controls.Add(this.btn_Edit);
            this.groupBox1.Controls.Add(this.txtBx_Address);
            this.groupBox1.Controls.Add(this.txtBx_Phone);
            this.groupBox1.Controls.Add(this.txtBx_Second_Name);
            this.groupBox1.Controls.Add(this.txtBx_Name);
            this.groupBox1.Controls.Add(this.txtBx_Surname);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(796, 742);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Профиль";
            // 
            // lbl_noAccounts
            // 
            this.lbl_noAccounts.AutoSize = true;
            this.lbl_noAccounts.Location = new System.Drawing.Point(289, 630);
            this.lbl_noAccounts.Name = "lbl_noAccounts";
            this.lbl_noAccounts.Size = new System.Drawing.Size(198, 40);
            this.lbl_noAccounts.TabIndex = 21;
            this.lbl_noAccounts.Text = "У Вас еще нет счетов,\r\nхотите открыть?";
            this.lbl_noAccounts.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_noAccounts.Visible = false;
            // 
            // btn_createNewUserAcc
            // 
            this.btn_createNewUserAcc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_createNewUserAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_createNewUserAcc.Location = new System.Drawing.Point(301, 689);
            this.btn_createNewUserAcc.Name = "btn_createNewUserAcc";
            this.btn_createNewUserAcc.Size = new System.Drawing.Size(176, 46);
            this.btn_createNewUserAcc.TabIndex = 20;
            this.btn_createNewUserAcc.Text = "Открыть счет";
            this.btn_createNewUserAcc.UseVisualStyleBackColor = true;
            this.btn_createNewUserAcc.Click += new System.EventHandler(this.btn_createNewUserAcc_Click);
            // 
            // UpdateAddress_btn
            // 
            this.UpdateAddress_btn.Enabled = false;
            this.UpdateAddress_btn.Location = new System.Drawing.Point(695, 257);
            this.UpdateAddress_btn.Margin = new System.Windows.Forms.Padding(4);
            this.UpdateAddress_btn.Name = "UpdateAddress_btn";
            this.UpdateAddress_btn.Size = new System.Drawing.Size(92, 37);
            this.UpdateAddress_btn.TabIndex = 19;
            this.UpdateAddress_btn.Text = "Upd";
            this.UpdateAddress_btn.UseVisualStyleBackColor = true;
            this.UpdateAddress_btn.Click += new System.EventHandler(this.UpdateAddress_btn_Click);
            // 
            // RemoveAddress_btn
            // 
            this.RemoveAddress_btn.Enabled = false;
            this.RemoveAddress_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RemoveAddress_btn.Location = new System.Drawing.Point(743, 204);
            this.RemoveAddress_btn.Margin = new System.Windows.Forms.Padding(4);
            this.RemoveAddress_btn.Name = "RemoveAddress_btn";
            this.RemoveAddress_btn.Size = new System.Drawing.Size(44, 46);
            this.RemoveAddress_btn.TabIndex = 18;
            this.RemoveAddress_btn.Text = "-";
            this.RemoveAddress_btn.UseVisualStyleBackColor = true;
            this.RemoveAddress_btn.Click += new System.EventHandler(this.RemoveAddress_btn_Click);
            // 
            // AddAddress_btn
            // 
            this.AddAddress_btn.Enabled = false;
            this.AddAddress_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddAddress_btn.Location = new System.Drawing.Point(695, 204);
            this.AddAddress_btn.Margin = new System.Windows.Forms.Padding(4);
            this.AddAddress_btn.Name = "AddAddress_btn";
            this.AddAddress_btn.Size = new System.Drawing.Size(40, 46);
            this.AddAddress_btn.TabIndex = 17;
            this.AddAddress_btn.Text = "+";
            this.AddAddress_btn.UseVisualStyleBackColor = true;
            this.AddAddress_btn.Click += new System.EventHandler(this.AddAddress_btn_Click);
            // 
            // txtBx_INN
            // 
            this.txtBx_INN.Enabled = false;
            this.txtBx_INN.Location = new System.Drawing.Point(123, 135);
            this.txtBx_INN.Margin = new System.Windows.Forms.Padding(4);
            this.txtBx_INN.Name = "txtBx_INN";
            this.txtBx_INN.Size = new System.Drawing.Size(335, 26);
            this.txtBx_INN.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 136);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "ИНН";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(15, 301);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(771, 84);
            this.listBox1.TabIndex = 13;
            this.listBox1.Visible = false;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            // 
            // btn_Edit
            // 
            this.btn_Edit.Location = new System.Drawing.Point(524, 35);
            this.btn_Edit.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(263, 52);
            this.btn_Edit.TabIndex = 10;
            this.btn_Edit.Text = "Редактировать";
            this.btn_Edit.UseVisualStyleBackColor = true;
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // txtBx_Address
            // 
            this.txtBx_Address.Enabled = false;
            this.txtBx_Address.Location = new System.Drawing.Point(123, 204);
            this.txtBx_Address.Margin = new System.Windows.Forms.Padding(4);
            this.txtBx_Address.Multiline = true;
            this.txtBx_Address.Name = "txtBx_Address";
            this.txtBx_Address.Size = new System.Drawing.Size(561, 89);
            this.txtBx_Address.TabIndex = 9;
            this.txtBx_Address.TextChanged += new System.EventHandler(this.txtBx_Address_TextChanged);
            // 
            // txtBx_Phone
            // 
            this.txtBx_Phone.Enabled = false;
            this.txtBx_Phone.Location = new System.Drawing.Point(123, 169);
            this.txtBx_Phone.Margin = new System.Windows.Forms.Padding(4);
            this.txtBx_Phone.Name = "txtBx_Phone";
            this.txtBx_Phone.Size = new System.Drawing.Size(335, 26);
            this.txtBx_Phone.TabIndex = 8;
            // 
            // txtBx_Second_Name
            // 
            this.txtBx_Second_Name.Enabled = false;
            this.txtBx_Second_Name.Location = new System.Drawing.Point(123, 100);
            this.txtBx_Second_Name.Margin = new System.Windows.Forms.Padding(4);
            this.txtBx_Second_Name.Name = "txtBx_Second_Name";
            this.txtBx_Second_Name.Size = new System.Drawing.Size(335, 26);
            this.txtBx_Second_Name.TabIndex = 7;
            // 
            // txtBx_Name
            // 
            this.txtBx_Name.Enabled = false;
            this.txtBx_Name.Location = new System.Drawing.Point(123, 66);
            this.txtBx_Name.Margin = new System.Windows.Forms.Padding(4);
            this.txtBx_Name.Name = "txtBx_Name";
            this.txtBx_Name.Size = new System.Drawing.Size(335, 26);
            this.txtBx_Name.TabIndex = 6;
            // 
            // txtBx_Surname
            // 
            this.txtBx_Surname.Enabled = false;
            this.txtBx_Surname.Location = new System.Drawing.Point(123, 31);
            this.txtBx_Surname.Margin = new System.Windows.Forms.Padding(4);
            this.txtBx_Surname.Name = "txtBx_Surname";
            this.txtBx_Surname.Size = new System.Drawing.Size(335, 26);
            this.txtBx_Surname.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 205);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Адрес";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 171);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Телефон";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 102);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Отчество";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 67);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Имя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 35);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Фамилия";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.listV_accounts);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(832, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(720, 742);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Счета";
            // 
            // listV_accounts
            // 
            this.listV_accounts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listV_accounts.BackColor = System.Drawing.SystemColors.Control;
            this.listV_accounts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listV_accounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listV_accounts.HideSelection = false;
            this.listV_accounts.Location = new System.Drawing.Point(7, 45);
            this.listV_accounts.Name = "listV_accounts";
            this.listV_accounts.Size = new System.Drawing.Size(706, 690);
            this.listV_accounts.TabIndex = 0;
            this.listV_accounts.TileSize = new System.Drawing.Size(300, 44);
            this.listV_accounts.UseCompatibleStateImageBehavior = false;
            this.listV_accounts.View = System.Windows.Forms.View.List;
            this.listV_accounts.ItemActivate += new System.EventHandler(this.listV_accounts_ItemActivate);
            this.listV_accounts.SelectedIndexChanged += new System.EventHandler(this.listV_accounts_SelectedIndexChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1568, 772);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.Text = "Онлайн-банк";
            this.Activated += new System.EventHandler(this.Main_Activated_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtBx_Phone;
        private System.Windows.Forms.TextBox txtBx_Second_Name;
        private System.Windows.Forms.TextBox txtBx_Name;
        private System.Windows.Forms.TextBox txtBx_Surname;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox txtBx_Address;
        private System.Windows.Forms.TextBox txtBx_INN;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button RemoveAddress_btn;
        private System.Windows.Forms.Button AddAddress_btn;
        private System.Windows.Forms.Button UpdateAddress_btn;
        private System.Windows.Forms.ListView listV_accounts;
        private System.Windows.Forms.Button btn_createNewUserAcc;
        private System.Windows.Forms.Label lbl_noAccounts;
    }
}