namespace bank_forms
{
    partial class Login
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
            this.Btn_login = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBx_login = new System.Windows.Forms.TextBox();
            this.txtBx_password = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Btn_login
            // 
            this.Btn_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Btn_login.Location = new System.Drawing.Point(70, 186);
            this.Btn_login.Name = "Btn_login";
            this.Btn_login.Size = new System.Drawing.Size(100, 26);
            this.Btn_login.TabIndex = 0;
            this.Btn_login.Text = "Login";
            this.Btn_login.UseVisualStyleBackColor = true;
            this.Btn_login.Click += new System.EventHandler(this.Btn_login_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(98, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(86, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // txtBx_login
            // 
            this.txtBx_login.Location = new System.Drawing.Point(70, 41);
            this.txtBx_login.Name = "txtBx_login";
            this.txtBx_login.Size = new System.Drawing.Size(100, 20);
            this.txtBx_login.TabIndex = 3;
            // 
            // txtBx_password
            // 
            this.txtBx_password.Location = new System.Drawing.Point(70, 122);
            this.txtBx_password.Name = "txtBx_password";
            this.txtBx_password.Size = new System.Drawing.Size(100, 20);
            this.txtBx_password.TabIndex = 4;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 263);
            this.Controls.Add(this.txtBx_password);
            this.Controls.Add(this.txtBx_login);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_login);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBx_login;
        private System.Windows.Forms.TextBox txtBx_password;
    }
}

