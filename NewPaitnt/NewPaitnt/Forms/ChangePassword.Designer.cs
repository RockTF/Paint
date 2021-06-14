
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
            this.SuspendLayout();
            // 
            // TextBoxReapeatPassword
            // 
            this.TextBoxReapeatPassword.Location = new System.Drawing.Point(49, 143);
            this.TextBoxReapeatPassword.Name = "TextBoxReapeatPassword";
            this.TextBoxReapeatPassword.Size = new System.Drawing.Size(308, 23);
            this.TextBoxReapeatPassword.TabIndex = 19;
            // 
            // LabelRepeatPassword
            // 
            this.LabelRepeatPassword.AutoSize = true;
            this.LabelRepeatPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelRepeatPassword.Location = new System.Drawing.Point(46, 115);
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
            this.BtnBack.Location = new System.Drawing.Point(64, 207);
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
            this.BtnChange.Location = new System.Drawing.Point(215, 207);
            this.BtnChange.Name = "BtnChange";
            this.BtnChange.Size = new System.Drawing.Size(125, 45);
            this.BtnChange.TabIndex = 16;
            this.BtnChange.Text = "CHANGE";
            this.BtnChange.UseVisualStyleBackColor = false;
            this.BtnChange.Click += new System.EventHandler(this.BtnChange_Click);
            // 
            // TextBoxNewPassword
            // 
            this.TextBoxNewPassword.Location = new System.Drawing.Point(49, 66);
            this.TextBoxNewPassword.Name = "TextBoxNewPassword";
            this.TextBoxNewPassword.Size = new System.Drawing.Size(308, 23);
            this.TextBoxNewPassword.TabIndex = 15;
            // 
            // LabelNewPassword
            // 
            this.LabelNewPassword.AutoSize = true;
            this.LabelNewPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelNewPassword.Location = new System.Drawing.Point(46, 38);
            this.LabelNewPassword.Name = "LabelNewPassword";
            this.LabelNewPassword.Size = new System.Drawing.Size(112, 21);
            this.LabelNewPassword.TabIndex = 14;
            this.LabelNewPassword.Text = "New Password";
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(402, 305);
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
    }
}