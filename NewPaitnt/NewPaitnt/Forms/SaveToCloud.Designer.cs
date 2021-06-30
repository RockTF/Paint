
namespace NewPaitnt.Forms
{
    partial class SaveToCloud
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
            this.comboBoxPictureType = new System.Windows.Forms.ComboBox();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.labelFileName = new System.Windows.Forms.Label();
            this.labelFileType = new System.Windows.Forms.Label();
            this.Close = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxPictureType
            // 
            this.comboBoxPictureType.FormattingEnabled = true;
            this.comboBoxPictureType.Items.AddRange(new object[] {
            "*.jpg",
            "*.bmp",
            "*.gif",
            "*.png",
            "*.json"});
            this.comboBoxPictureType.Location = new System.Drawing.Point(89, 72);
            this.comboBoxPictureType.Name = "comboBoxPictureType";
            this.comboBoxPictureType.Size = new System.Drawing.Size(194, 23);
            this.comboBoxPictureType.TabIndex = 0;
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Location = new System.Drawing.Point(89, 37);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(194, 23);
            this.textBoxFileName.TabIndex = 1;
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Location = new System.Drawing.Point(25, 40);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(60, 15);
            this.labelFileName.TabIndex = 2;
            this.labelFileName.Text = "File name";
            // 
            // labelFileType
            // 
            this.labelFileType.AutoSize = true;
            this.labelFileType.Location = new System.Drawing.Point(25, 75);
            this.labelFileType.Name = "labelFileType";
            this.labelFileType.Size = new System.Drawing.Size(54, 15);
            this.labelFileType.TabIndex = 3;
            this.labelFileType.Text = "File type";
            // 
            // Close
            // 
            this.Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.Close.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close.Location = new System.Drawing.Point(64, 145);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(94, 37);
            this.Close.TabIndex = 9;
            this.Close.Text = "Close";
            this.Close.UseVisualStyleBackColor = false;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // BtnOk
            // 
            this.BtnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.BtnOk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOk.Location = new System.Drawing.Point(176, 145);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(94, 37);
            this.BtnOk.TabIndex = 8;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = false;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // SaveToCloud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 221);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.labelFileType);
            this.Controls.Add(this.labelFileName);
            this.Controls.Add(this.textBoxFileName);
            this.Controls.Add(this.comboBoxPictureType);
            this.Name = "SaveToCloud";
            this.Text = "Save To Cloud";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxPictureType;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.Label labelFileType;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Button BtnOk;
    }
}