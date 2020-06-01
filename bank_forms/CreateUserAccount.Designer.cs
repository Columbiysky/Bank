namespace bank_forms
{
    partial class CreateUserAccount
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
            this.btn_createNewAcc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_accInfo = new System.Windows.Forms.TextBox();
            this.tb_confirmINN = new System.Windows.Forms.TextBox();
            this.tb_cofirmPass = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lbl_warning = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_createNewAcc
            // 
            this.btn_createNewAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_createNewAcc.Location = new System.Drawing.Point(359, 251);
            this.btn_createNewAcc.Name = "btn_createNewAcc";
            this.btn_createNewAcc.Size = new System.Drawing.Size(175, 111);
            this.btn_createNewAcc.TabIndex = 0;
            this.btn_createNewAcc.Text = "Подтвердить данные и создать аккаунт";
            this.btn_createNewAcc.UseVisualStyleBackColor = true;
            this.btn_createNewAcc.Click += new System.EventHandler(this.btn_createNewAcc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(129, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "Назначение аккаунта\r\n(например: \"Коплю на квартиру\")";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tb_accInfo
            // 
            this.tb_accInfo.Location = new System.Drawing.Point(75, 64);
            this.tb_accInfo.Multiline = true;
            this.tb_accInfo.Name = "tb_accInfo";
            this.tb_accInfo.Size = new System.Drawing.Size(382, 58);
            this.tb_accInfo.TabIndex = 2;
            // 
            // tb_confirmINN
            // 
            this.tb_confirmINN.Location = new System.Drawing.Point(131, 39);
            this.tb_confirmINN.Name = "tb_confirmINN";
            this.tb_confirmINN.Size = new System.Drawing.Size(199, 22);
            this.tb_confirmINN.TabIndex = 3;
            // 
            // tb_cofirmPass
            // 
            this.tb_cofirmPass.Location = new System.Drawing.Point(131, 83);
            this.tb_cofirmPass.Name = "tb_cofirmPass";
            this.tb_cofirmPass.Size = new System.Drawing.Size(199, 22);
            this.tb_cofirmPass.TabIndex = 4;
            this.tb_cofirmPass.UseSystemPasswordChar = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tb_confirmINN);
            this.groupBox1.Controls.Add(this.tb_cofirmPass);
            this.groupBox1.Location = new System.Drawing.Point(2, 245);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 117);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Подтвердите Ваш номер паспорта и пароль";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Пароль:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Номер паспорта:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkLabel1.Location = new System.Drawing.Point(11, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(20, 24);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "?";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lbl_warning
            // 
            this.lbl_warning.AutoSize = true;
            this.lbl_warning.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_warning.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl_warning.Location = new System.Drawing.Point(142, 189);
            this.lbl_warning.Name = "lbl_warning";
            this.lbl_warning.Size = new System.Drawing.Size(258, 18);
            this.lbl_warning.TabIndex = 8;
            this.lbl_warning.Text = "Заполните данные/данные неверны";
            this.lbl_warning.Visible = false;
            // 
            // CreateUserAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 364);
            this.Controls.Add(this.lbl_warning);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tb_accInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_createNewAcc);
            this.MaximumSize = new System.Drawing.Size(556, 411);
            this.MinimumSize = new System.Drawing.Size(556, 411);
            this.Name = "CreateUserAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Открыть счет";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_createNewAcc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_accInfo;
        private System.Windows.Forms.TextBox tb_confirmINN;
        private System.Windows.Forms.TextBox tb_cofirmPass;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label lbl_warning;
    }
}