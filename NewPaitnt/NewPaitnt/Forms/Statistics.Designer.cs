﻿
namespace NewPaitnt.Forms
{
    partial class Statistics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Statistics));
            this.BtnBack = new System.Windows.Forms.Button();
            this.PictureBoxArrow = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxArrow)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnBack
            // 
            this.BtnBack.FlatAppearance.BorderSize = 0;
            this.BtnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBack.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnBack.Location = new System.Drawing.Point(38, 8);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(41, 31);
            this.BtnBack.TabIndex = 0;
            this.BtnBack.Text = "Back";
            this.BtnBack.UseVisualStyleBackColor = true;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // PictureBoxArrow
            // 
            this.PictureBoxArrow.BackColor = System.Drawing.Color.White;
            this.PictureBoxArrow.Image = ((System.Drawing.Image)(resources.GetObject("PictureBoxArrow.Image")));
            this.PictureBoxArrow.Location = new System.Drawing.Point(12, 12);
            this.PictureBoxArrow.Name = "PictureBoxArrow";
            this.PictureBoxArrow.Size = new System.Drawing.Size(24, 24);
            this.PictureBoxArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBoxArrow.TabIndex = 1;
            this.PictureBoxArrow.TabStop = false;
            // 
            // Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PictureBoxArrow);
            this.Controls.Add(this.BtnBack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Statistics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statistics";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxArrow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.PictureBox PictureBoxArrow;
    }
}