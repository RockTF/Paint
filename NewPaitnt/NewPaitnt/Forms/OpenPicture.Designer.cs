
namespace NewPaitnt.Forms
{
    partial class OpenPicture
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
            this.ListBoxPicture = new System.Windows.Forms.ListBox();
            this.Close = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListBoxPicture
            // 
            this.ListBoxPicture.FormattingEnabled = true;
            this.ListBoxPicture.ItemHeight = 15;
            this.ListBoxPicture.Location = new System.Drawing.Point(12, 12);
            this.ListBoxPicture.Name = "ListBoxPicture";
            this.ListBoxPicture.ScrollAlwaysVisible = true;
            this.ListBoxPicture.Size = new System.Drawing.Size(246, 184);
            this.ListBoxPicture.TabIndex = 0;
            // 
            // Close
            // 
            this.Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.Close.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close.Location = new System.Drawing.Point(32, 224);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(94, 37);
            this.Close.TabIndex = 7;
            this.Close.Text = "Close";
            this.Close.UseVisualStyleBackColor = false;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // BtnOk
            // 
            this.BtnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.BtnOk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOk.Location = new System.Drawing.Point(144, 224);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(94, 37);
            this.BtnOk.TabIndex = 6;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = false;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // OpenPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 295);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.ListBoxPicture);
            this.Name = "OpenPicture";
            this.Text = "Open Picture";
            this.Load += new System.EventHandler(this.OpenPicture_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ListBoxPicture;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Button BtnOk;
    }
}