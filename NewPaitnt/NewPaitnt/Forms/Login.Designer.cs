
namespace NewPaitnt.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.BtnForgot = new System.Windows.Forms.Button();
            this.BtnLogin = new System.Windows.Forms.Button();
            this.BtnBack = new System.Windows.Forms.Button();
            this.TextBoxPassword = new System.Windows.Forms.TextBox();
            this.LabelPassword = new System.Windows.Forms.Label();
            this.TextBoxEmail = new System.Windows.Forms.TextBox();
            this.LabelEmail = new System.Windows.Forms.Label();
            this.LabelErrorEmailName = new System.Windows.Forms.Label();
            this.LabelErrorPassword = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnForgot
            // 
            this.BtnForgot.FlatAppearance.BorderSize = 0;
            this.BtnForgot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnForgot.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnForgot.Location = new System.Drawing.Point(219, 193);
            this.BtnForgot.Name = "BtnForgot";
            this.BtnForgot.Size = new System.Drawing.Size(157, 34);
            this.BtnForgot.TabIndex = 4;
            this.BtnForgot.Text = "Forgot your password?";
            this.BtnForgot.UseVisualStyleBackColor = true;
            this.BtnForgot.Click += new System.EventHandler(this.BtnForgot_Click);
            // 
            // BtnLogin
            // 
            this.BtnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.BtnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnLogin.Location = new System.Drawing.Point(222, 266);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(125, 45);
            this.BtnLogin.TabIndex = 5;
            this.BtnLogin.Text = "LOG IN";
            this.BtnLogin.UseVisualStyleBackColor = false;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // BtnBack
            // 
            this.BtnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.BtnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnBack.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnBack.Location = new System.Drawing.Point(71, 266);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(125, 45);
            this.BtnBack.TabIndex = 6;
            this.BtnBack.Text = "BACK";
            this.BtnBack.UseVisualStyleBackColor = false;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // TextBoxPassword
            // 
            this.TextBoxPassword.Location = new System.Drawing.Point(59, 144);
            this.TextBoxPassword.Name = "TextBoxPassword";
            this.TextBoxPassword.Size = new System.Drawing.Size(308, 23);
            this.TextBoxPassword.TabIndex = 10;
            this.TextBoxPassword.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxPassword_Validating);
            // 
            // LabelPassword
            // 
            this.LabelPassword.AutoSize = true;
            this.LabelPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelPassword.Location = new System.Drawing.Point(56, 116);
            this.LabelPassword.Name = "LabelPassword";
            this.LabelPassword.Size = new System.Drawing.Size(76, 21);
            this.LabelPassword.TabIndex = 9;
            this.LabelPassword.Text = "Password";
            // 
            // TextBoxEmail
            // 
            this.TextBoxEmail.Location = new System.Drawing.Point(60, 66);
            this.TextBoxEmail.Name = "TextBoxEmail";
            this.TextBoxEmail.Size = new System.Drawing.Size(308, 23);
            this.TextBoxEmail.TabIndex = 8;
            this.TextBoxEmail.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxEmail_Validating);
            // 
            // LabelEmail
            // 
            this.LabelEmail.AutoSize = true;
            this.LabelEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelEmail.Location = new System.Drawing.Point(57, 38);
            this.LabelEmail.Name = "LabelEmail";
            this.LabelEmail.Size = new System.Drawing.Size(48, 21);
            this.LabelEmail.TabIndex = 7;
            this.LabelEmail.Text = "Email";
            // 
            // LabelErrorEmailName
            // 
            this.LabelErrorEmailName.AutoSize = true;
            this.LabelErrorEmailName.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelErrorEmailName.ForeColor = System.Drawing.Color.Red;
            this.LabelErrorEmailName.Location = new System.Drawing.Point(64, 95);
            this.LabelErrorEmailName.Name = "LabelErrorEmailName";
            this.LabelErrorEmailName.Size = new System.Drawing.Size(0, 12);
            this.LabelErrorEmailName.TabIndex = 18;
            // 
            // LabelErrorPassword
            // 
            this.LabelErrorPassword.AutoSize = true;
            this.LabelErrorPassword.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelErrorPassword.ForeColor = System.Drawing.Color.Red;
            this.LabelErrorPassword.Location = new System.Drawing.Point(63, 173);
            this.LabelErrorPassword.Name = "LabelErrorPassword";
            this.LabelErrorPassword.Size = new System.Drawing.Size(0, 12);
            this.LabelErrorPassword.TabIndex = 19;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(424, 365);
            this.Controls.Add(this.LabelErrorPassword);
            this.Controls.Add(this.LabelErrorEmailName);
            this.Controls.Add(this.TextBoxPassword);
            this.Controls.Add(this.LabelPassword);
            this.Controls.Add(this.TextBoxEmail);
            this.Controls.Add(this.LabelEmail);
            this.Controls.Add(this.BtnBack);
            this.Controls.Add(this.BtnLogin);
            this.Controls.Add(this.BtnForgot);
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOG IN";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnForgot;
        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.TextBox TextBoxPassword;
        private System.Windows.Forms.Label LabelPassword;
        private System.Windows.Forms.TextBox TextBoxEmail;
        private System.Windows.Forms.Label LabelEmail;
        private System.Windows.Forms.Label LabelErrorEmailName;
        private System.Windows.Forms.Label LabelErrorPassword;
    }
}