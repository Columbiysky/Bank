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
            this.SuspendLayout();
            // 
            // addCardBtn
            // 
            this.addCardBtn.Location = new System.Drawing.Point(308, 91);
            this.addCardBtn.Name = "addCardBtn";
            this.addCardBtn.Size = new System.Drawing.Size(158, 58);
            this.addCardBtn.TabIndex = 0;
            this.addCardBtn.Text = "Add Card";
            this.addCardBtn.UseVisualStyleBackColor = true;
            this.addCardBtn.Click += new System.EventHandler(this.addCardBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(289, 229);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 59);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add creditCard";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // testAddCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.addCardBtn);
            this.Name = "testAddCard";
            this.Text = "testAddCard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addCardBtn;
        private System.Windows.Forms.Button button1;
    }
}