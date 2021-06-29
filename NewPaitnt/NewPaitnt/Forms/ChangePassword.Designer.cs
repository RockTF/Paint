
namespace NewPaitnt.Forms
{
    partial class ChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePassword));
            this.TextBoxReapeatPassword = new System.Windows.Forms.TextBox();
            this.LabelRepeatPassword = new System.Windows.Forms.Label();
            this.BtnBack = new System.Windows.Forms.Button();
            this.BtnChange = new System.Windows.Forms.Button();
            this.TextBoxNewPassword = new System.Windows.Forms.TextBox();
            this.LabelNewPassword = new System.Windows.Forms.Label();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.LabelEmail = new System.Windows.Forms.Label();
            this.LabelErrorEmail = new System.Windows.Forms.Label();
            this.LabelErrorPassword = new System.Windows.Forms.Label();
            this.LabelErrorRepeatPassword = new System.Windows.Forms.Label();
            this.CheckBoxRepeat = new System.Windows.Forms.CheckBox();
            this.CheckBoxNew = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // TextBoxReapeatPassword
            // 
            this.TextBoxReapeatPassword.Location = new System.Drawing.Point(48, 224);
            this.TextBoxReapeatPassword.Name = "TextBoxReapeatPassword";
            this.TextBoxReapeatPassword.Size = new System.Drawing.Size(308, 23);
            this.TextBoxReapeatPassword.TabIndex = 19;
            this.TextBoxReapeatPassword.UseSystemPasswordChar = true;
            this.TextBoxReapeatPassword.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxReapeatPassword_Validating);
            // 
            // LabelRepeatPassword
            // 
            this.LabelRepeatPassword.AutoSize = true;
            this.LabelRepeatPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelRepeatPassword.Location = new System.Drawing.Point(46, 195);
            this.LabelRepeatPassword.Name = "LabelRepeatPassword";
            this.LabelRepeatPassword.Size = new System.Drawing.Size(128, 21);
            this.LabelRepeatPassword.TabIndex = 18;
            this.LabelRepeatPassword.Text = "Repeat Password";
            // 
            // BtnBack
            // 
            this.BtnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.BtnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnBack.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnBack.Location = new System.Drawing.Point(63, 287);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(125, 45);
            this.BtnBack.TabIndex = 17;
            this.BtnBack.Text = "BACK";
            this.BtnBack.UseVisualStyleBackColor = false;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // BtnChange
            // 
            this.BtnChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.BtnChange.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnChange.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnChange.Location = new System.Drawing.Point(214, 287);
            this.BtnChange.Name = "BtnChange";
            this.BtnChange.Size = new System.Drawing.Size(125, 45);
            this.BtnChange.TabIndex = 16;
            this.BtnChange.Text = "CHANGE";
            this.BtnChange.UseVisualStyleBackColor = false;
            this.BtnChange.Click += new System.EventHandler(this.BtnChange_Click);
            // 
            // TextBoxNewPassword
            // 
            this.TextBoxNewPassword.Location = new System.Drawing.Point(48, 147);
            this.TextBoxNewPassword.Name = "TextBoxNewPassword";
            this.TextBoxNewPassword.Size = new System.Drawing.Size(308, 23);
            this.TextBoxNewPassword.TabIndex = 15;
            this.TextBoxNewPassword.UseSystemPasswordChar = true;
            this.TextBoxNewPassword.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxNewPassword_Validating);
            // 
            // LabelNewPassword
            // 
            this.LabelNewPassword.AutoSize = true;
            this.LabelNewPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelNewPassword.Location = new System.Drawing.Point(46, 115);
            this.LabelNewPassword.Name = "LabelNewPassword";
            this.LabelNewPassword.Size = new System.Drawing.Size(112, 21);
            this.LabelNewPassword.TabIndex = 14;
            this.LabelNewPassword.Text = "New Password";
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Location = new System.Drawing.Point(48, 69);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(308, 23);
            this.EmailTextBox.TabIndex = 21;
            this.EmailTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.EmailTextBox_Validating);
            // 
            // LabelEmail
            // 
            this.LabelEmail.AutoSize = true;
            this.LabelEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelEmail.Location = new System.Drawing.Point(46, 38);
            this.LabelEmail.Name = "LabelEmail";
            this.LabelEmail.Size = new System.Drawing.Size(48, 21);
            this.LabelEmail.TabIndex = 20;
            this.LabelEmail.Text = "Email";
            // 
            // LabelErrorEmail
            // 
            this.LabelErrorEmail.AutoSize = true;
            this.LabelErrorEmail.ForeColor = System.Drawing.Color.Red;
            this.LabelErrorEmail.Location = new System.Drawing.Point(45, 95);
            this.LabelErrorEmail.Name = "LabelErrorEmail";
            this.LabelErrorEmail.Size = new System.Drawing.Size(0, 15);
            this.LabelErrorEmail.TabIndex = 22;
            // 
            // LabelErrorPassword
            // 
            this.LabelErrorPassword.AutoSize = true;
            this.LabelErrorPassword.ForeColor = System.Drawing.Color.Red;
            this.LabelErrorPassword.Location = new System.Drawing.Point(45, 173);
            this.LabelErrorPassword.Name = "LabelErrorPassword";
            this.LabelErrorPassword.Size = new System.Drawing.Size(0, 15);
            this.LabelErrorPassword.TabIndex = 23;
            // 
            // LabelErrorRepeatPassword
            // 
            this.LabelErrorRepeatPassword.AutoSize = true;
            this.LabelErrorRepeatPassword.ForeColor = System.Drawing.Color.Red;
            this.LabelErrorRepeatPassword.Location = new System.Drawing.Point(46, 250);
            this.LabelErrorRepeatPassword.Name = "LabelErrorRepeatPassword";
            this.LabelErrorRepeatPassword.Size = new System.Drawing.Size(0, 15);
            this.LabelErrorRepeatPassword.TabIndex = 24;
            // 
            // CheckBoxRepeat
            // 
            this.CheckBoxRepeat.AutoSize = true;
            this.CheckBoxRepeat.Location = new System.Drawing.Point(339, 229);
            this.CheckBoxRepeat.Name = "CheckBoxRepeat";
            this.CheckBoxRepeat.Size = new System.Drawing.Size(15, 14);
            this.CheckBoxRepeat.TabIndex = 25;
            this.CheckBoxRepeat.UseVisualStyleBackColor = true;
            this.CheckBoxRepeat.CheckedChanged += new System.EventHandler(this.CheckBoxRepeat_CheckedChanged);
            // 
            // CheckBoxNew
            // 
            this.CheckBoxNew.AutoSize = true;
            this.CheckBoxNew.Location = new System.Drawing.Point(339, 152);
            this.CheckBoxNew.Name = "CheckBoxNew";
            this.CheckBoxNew.Size = new System.Drawing.Size(15, 14);
            this.CheckBoxNew.TabIndex = 26;
            this.CheckBoxNew.UseVisualStyleBackColor = true;
            this.CheckBoxNew.CheckedChanged += new System.EventHandler(this.CheckBoxNew_CheckedChanged);
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(402, 376);
            this.Controls.Add(this.CheckBoxNew);
            this.Controls.Add(this.CheckBoxRepeat);
            this.Controls.Add(this.LabelErrorRepeatPassword);
            this.Controls.Add(this.LabelErrorPassword);
            this.Controls.Add(this.LabelErrorEmail);
            this.Controls.Add(this.EmailTextBox);
            this.Controls.Add(this.LabelEmail);
            this.Controls.Add(this.TextBoxReapeatPassword);
            this.Controls.Add(this.LabelRepeatPassword);
            this.Controls.Add(this.BtnBack);
            this.Controls.Add(this.BtnChange);
            this.Controls.Add(this.TextBoxNewPassword);
            this.Controls.Add(this.LabelNewPassword);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxReapeatPassword;
        private System.Windows.Forms.Label LabelRepeatPassword;
        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.Button BtnChange;
        private System.Windows.Forms.TextBox TextBoxNewPassword;
        private System.Windows.Forms.Label LabelNewPassword;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.Label LabelEmail;
        private System.Windows.Forms.Label LabelErrorEmail;
        private System.Windows.Forms.Label LabelErrorPassword;
        private System.Windows.Forms.Label LabelErrorRepeatPassword;
        private System.Windows.Forms.CheckBox CheckBoxRepeat;
        private System.Windows.Forms.CheckBox CheckBoxNew;
    }
}