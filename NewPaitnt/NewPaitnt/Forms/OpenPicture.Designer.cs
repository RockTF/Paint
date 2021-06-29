
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
            // OpenPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 219);
            this.Controls.Add(this.ListBoxPicture);
            this.Name = "OpenPicture";
            this.Text = "Open Picture";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ListBoxPicture;
    }
}