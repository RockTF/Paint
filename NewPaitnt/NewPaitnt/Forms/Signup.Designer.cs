
namespace NewPaitnt.Forms
{
    partial class Signup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Signup));
            this.LabelFirstName = new System.Windows.Forms.Label();
            this.TextBoxFirstName = new System.Windows.Forms.TextBox();
            this.TextBoxLastName = new System.Windows.Forms.TextBox();
            this.LabelLastName = new System.Windows.Forms.Label();
            this.TextBoxPassword = new System.Windows.Forms.TextBox();
            this.LabelPassword = new System.Windows.Forms.Label();
            this.TextBoxEmail = new System.Windows.Forms.TextBox();
            this.LabelEmail = new System.Windows.Forms.Label();
            this.BtnBack = new System.Windows.Forms.Button();
            this.BtnSignup = new System.Windows.Forms.Button();
            this.TextBoxReapeatPassword = new System.Windows.Forms.TextBox();
            this.LabelRepeatPassword = new System.Windows.Forms.Label();
            this.LabelErrorFirstName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LabelFirstName
            // 
            this.LabelFirstName.AutoSize = true;
            this.LabelFirstName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelFirstName.Location = new System.Drawing.Point(47, 38);
            this.LabelFirstName.Name = "LabelFirstName";
            this.LabelFirstName.Size = new System.Drawing.Size(86, 21);
            this.LabelFirstName.TabIndex = 2;
            this.LabelFirstName.Text = "First Name";
            // 
            // TextBoxFirstName
            // 
            this.TextBoxFirstName.Location = new System.Drawing.Point(50, 66);
            this.TextBoxFirstName.Name = "TextBoxFirstName";
            this.TextBoxFirstName.Size = new System.Drawing.Size(308, 23);
            this.TextBoxFirstName.TabIndex = 3;
            this.TextBoxFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxFirstName_Validating);
            // 
            // TextBoxLastName
            // 
            this.TextBoxLastName.Location = new System.Drawing.Point(49, 144);
            this.TextBoxLastName.Name = "TextBoxLastName";
            this.TextBoxLastName.Size = new System.Drawing.Size(308, 23);
            this.TextBoxLastName.TabIndex = 5;
            this.TextBoxLastName.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxLastName_Validating);
            // 
            // LabelLastName
            // 
            this.LabelLastName.AutoSize = true;
            this.LabelLastName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelLastName.Location = new System.Drawing.Point(46, 116);
            this.LabelLastName.Name = "LabelLastName";
            this.LabelLastName.Size = new System.Drawing.Size(84, 21);
            this.LabelLastName.TabIndex = 4;
            this.LabelLastName.Text = "Last Name";
            // 
            // TextBoxPassword
            // 
            this.TextBoxPassword.Location = new System.Drawing.Point(48, 298);
            this.TextBoxPassword.Name = "TextBoxPassword";
            this.TextBoxPassword.Size = new System.Drawing.Size(308, 23);
            this.TextBoxPassword.TabIndex = 9;
            // 
            // LabelPassword
            // 
            this.LabelPassword.AutoSize = true;
            this.LabelPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelPassword.Location = new System.Drawing.Point(45, 270);
            this.LabelPassword.Name = "LabelPassword";
            this.LabelPassword.Size = new System.Drawing.Size(76, 21);
            this.LabelPassword.TabIndex = 8;
            this.LabelPassword.Text = "Password";
            // 
            // TextBoxEmail
            // 
            this.TextBoxEmail.Location = new System.Drawing.Point(49, 220);
            this.TextBoxEmail.Name = "TextBoxEmail";
            this.TextBoxEmail.Size = new System.Drawing.Size(308, 23);
            this.TextBoxEmail.TabIndex = 7;
            // 
            // LabelEmail
            // 
            this.LabelEmail.AutoSize = true;
            this.LabelEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelEmail.Location = new System.Drawing.Point(46, 192);
            this.LabelEmail.Name = "LabelEmail";
            this.LabelEmail.Size = new System.Drawing.Size(48, 21);
            this.LabelEmail.TabIndex = 6;
            this.LabelEmail.Text = "Email";
            // 
            // BtnBack
            // 
            this.BtnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.BtnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnBack.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnBack.Location = new System.Drawing.Point(63, 439);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(125, 45);
            this.BtnBack.TabIndex = 11;
            this.BtnBack.Text = "BACK";
            this.BtnBack.UseVisualStyleBackColor = false;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // BtnSignup
            // 
            this.BtnSignup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.BtnSignup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnSignup.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnSignup.Location = new System.Drawing.Point(214, 439);
            this.BtnSignup.Name = "BtnSignup";
            this.BtnSignup.Size = new System.Drawing.Size(125, 45);
            this.BtnSignup.TabIndex = 10;
            this.BtnSignup.Text = "SIGN UP";
            this.BtnSignup.UseVisualStyleBackColor = false;
            this.BtnSignup.Click += new System.EventHandler(this.BtnSignup_Click);
            // 
            // TextBoxReapeatPassword
            // 
            this.TextBoxReapeatPassword.Location = new System.Drawing.Point(48, 375);
            this.TextBoxReapeatPassword.Name = "TextBoxReapeatPassword";
            this.TextBoxReapeatPassword.Size = new System.Drawing.Size(308, 23);
            this.TextBoxReapeatPassword.TabIndex = 13;
            // 
            // LabelRepeatPassword
            // 
            this.LabelRepeatPassword.AutoSize = true;
            this.LabelRepeatPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelRepeatPassword.Location = new System.Drawing.Point(45, 347);
            this.LabelRepeatPassword.Name = "LabelRepeatPassword";
            this.LabelRepeatPassword.Size = new System.Drawing.Size(128, 21);
            this.LabelRepeatPassword.TabIndex = 12;
            this.LabelRepeatPassword.Text = "Repeat Password";
            // 
            // LabelErrorFirstName
            // 
            this.LabelErrorFirstName.AutoSize = true;
            this.LabelErrorFirstName.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelErrorFirstName.ForeColor = System.Drawing.Color.Red;
            this.LabelErrorFirstName.Location = new System.Drawing.Point(48, 95);
            this.LabelErrorFirstName.Name = "LabelErrorFirstName";
            this.LabelErrorFirstName.Size = new System.Drawing.Size(0, 12);
            this.LabelErrorFirstName.TabIndex = 14;
            // 
            // Signup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(402, 524);
            this.Controls.Add(this.LabelErrorFirstName);
            this.Controls.Add(this.TextBoxReapeatPassword);
            this.Controls.Add(this.LabelRepeatPassword);
            this.Controls.Add(this.BtnBack);
            this.Controls.Add(this.BtnSignup);
            this.Controls.Add(this.TextBoxPassword);
            this.Controls.Add(this.LabelPassword);
            this.Controls.Add(this.TextBoxEmail);
            this.Controls.Add(this.LabelEmail);
            this.Controls.Add(this.TextBoxLastName);
            this.Controls.Add(this.LabelLastName);
            this.Controls.Add(this.TextBoxFirstName);
            this.Controls.Add(this.LabelFirstName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Signup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SIGN UP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LabelFirstName;
        private System.Windows.Forms.Button BtnFirst;
        private System.Windows.Forms.TextBox TextBoxFirstName;
        private System.Windows.Forms.TextBox TextBoxLastName;
        private System.Windows.Forms.Label LabelLastName;
        private System.Windows.Forms.TextBox TextBoxPassword;
        private System.Windows.Forms.Label LabelPassword;
        private System.Windows.Forms.TextBox TextBoxEmail;
        private System.Windows.Forms.Label LabelEmail;
        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.Button BtnSignup;
        private System.Windows.Forms.TextBox TextBoxReapeatPassword;
        private System.Windows.Forms.Label LabelRepeatPassword;
        private System.Windows.Forms.Label LabelErrorFirstName;
    }
}