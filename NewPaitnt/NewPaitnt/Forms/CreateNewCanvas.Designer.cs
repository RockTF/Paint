﻿
namespace NewPaitnt
{
    partial class CreateNewCanvas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateNewCanvas));
            this.PanelCreate = new System.Windows.Forms.Panel();
            this.Close = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.NumericUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.LabelHeight = new System.Windows.Forms.Label();
            this.NumericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.LabelWidth = new System.Windows.Forms.Label();
            this.LabelCanvassize = new System.Windows.Forms.Label();
            this.PanelCreate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelCreate
            // 
            this.PanelCreate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelCreate.Controls.Add(this.Close);
            this.PanelCreate.Controls.Add(this.BtnOk);
            this.PanelCreate.Controls.Add(this.NumericUpDownHeight);
            this.PanelCreate.Controls.Add(this.LabelHeight);
            this.PanelCreate.Controls.Add(this.NumericUpDownWidth);
            this.PanelCreate.Controls.Add(this.LabelWidth);
            this.PanelCreate.Location = new System.Drawing.Point(26, 19);
            this.PanelCreate.Name = "PanelCreate";
            this.PanelCreate.Size = new System.Drawing.Size(189, 140);
            this.PanelCreate.TabIndex = 0;
            // 
            // Close
            // 
            this.Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.Close.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close.Location = new System.Drawing.Point(95, 100);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(80, 28);
            this.Close.TabIndex = 5;
            this.Close.Text = "Close";
            this.Close.UseVisualStyleBackColor = false;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // BtnOk
            // 
            this.BtnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.BtnOk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOk.Location = new System.Drawing.Point(10, 100);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(80, 28);
            this.BtnOk.TabIndex = 4;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = false;
            this.BtnOk.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // NumericUpDownHeight
            // 
            this.NumericUpDownHeight.Location = new System.Drawing.Point(88, 53);
            this.NumericUpDownHeight.Maximum = new decimal(new int[] {
            2500,
            0,
            0,
            0});
            this.NumericUpDownHeight.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.NumericUpDownHeight.Name = "NumericUpDownHeight";
            this.NumericUpDownHeight.Size = new System.Drawing.Size(64, 23);
            this.NumericUpDownHeight.TabIndex = 3;
            this.NumericUpDownHeight.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // LabelHeight
            // 
            this.LabelHeight.AutoSize = true;
            this.LabelHeight.Location = new System.Drawing.Point(30, 55);
            this.LabelHeight.Name = "LabelHeight";
            this.LabelHeight.Size = new System.Drawing.Size(43, 15);
            this.LabelHeight.TabIndex = 2;
            this.LabelHeight.Text = "Height";
            // 
            // NumericUpDownWidth
            // 
            this.NumericUpDownWidth.Location = new System.Drawing.Point(88, 21);
            this.NumericUpDownWidth.Maximum = new decimal(new int[] {
            2500,
            0,
            0,
            0});
            this.NumericUpDownWidth.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.NumericUpDownWidth.Name = "NumericUpDownWidth";
            this.NumericUpDownWidth.Size = new System.Drawing.Size(64, 23);
            this.NumericUpDownWidth.TabIndex = 1;
            this.NumericUpDownWidth.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // LabelWidth
            // 
            this.LabelWidth.AutoSize = true;
            this.LabelWidth.Location = new System.Drawing.Point(30, 23);
            this.LabelWidth.Name = "LabelWidth";
            this.LabelWidth.Size = new System.Drawing.Size(39, 15);
            this.LabelWidth.TabIndex = 0;
            this.LabelWidth.Text = "Width";
            // 
            // LabelCanvassize
            // 
            this.LabelCanvassize.AutoSize = true;
            this.LabelCanvassize.Location = new System.Drawing.Point(38, 12);
            this.LabelCanvassize.Name = "LabelCanvassize";
            this.LabelCanvassize.Size = new System.Drawing.Size(67, 15);
            this.LabelCanvassize.TabIndex = 1;
            this.LabelCanvassize.Text = "Canvas size";
            // 
            // CreateNewCanvas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 171);
            this.Controls.Add(this.LabelCanvassize);
            this.Controls.Add(this.PanelCreate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateNewCanvas";
            this.Text = "CreateNewCanvas";
            this.PanelCreate.ResumeLayout(false);
            this.PanelCreate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelCreate;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.NumericUpDown NumericUpDownHeight;
        private System.Windows.Forms.Label LabelHeight;
        private System.Windows.Forms.NumericUpDown NumericUpDownWidth;
        private System.Windows.Forms.Label LabelWidth;
        private System.Windows.Forms.Label LabelCanvassize;
        private System.Windows.Forms.Button Close;
    }
}