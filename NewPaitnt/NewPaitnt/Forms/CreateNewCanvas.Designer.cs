
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
            this.PanelCreate.Location = new System.Drawing.Point(30, 25);
            this.PanelCreate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PanelCreate.Name = "PanelCreate";
            this.PanelCreate.Size = new System.Drawing.Size(216, 186);
            this.PanelCreate.TabIndex = 0;
            // 
            // Close
            // 
            this.Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.Close.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close.Location = new System.Drawing.Point(109, 134);
            this.Close.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(91, 37);
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
            this.BtnOk.Location = new System.Drawing.Point(12, 134);
            this.BtnOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(91, 37);
            this.BtnOk.TabIndex = 4;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = false;
            this.BtnOk.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // NumericUpDownHeight
            // 
            this.NumericUpDownHeight.Location = new System.Drawing.Point(101, 71);
            this.NumericUpDownHeight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NumericUpDownHeight.Name = "NumericUpDownHeight";
            this.NumericUpDownHeight.Size = new System.Drawing.Size(73, 27);
            this.NumericUpDownHeight.TabIndex = 3;
            // 
            // LabelHeight
            // 
            this.LabelHeight.AutoSize = true;
            this.LabelHeight.Location = new System.Drawing.Point(34, 74);
            this.LabelHeight.Name = "LabelHeight";
            this.LabelHeight.Size = new System.Drawing.Size(54, 20);
            this.LabelHeight.TabIndex = 2;
            this.LabelHeight.Text = "Height";
            // 
            // NumericUpDownWidth
            // 
            this.NumericUpDownWidth.Location = new System.Drawing.Point(101, 28);
            this.NumericUpDownWidth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NumericUpDownWidth.Name = "NumericUpDownWidth";
            this.NumericUpDownWidth.Size = new System.Drawing.Size(73, 27);
            this.NumericUpDownWidth.TabIndex = 1;
            // 
            // LabelWidth
            // 
            this.LabelWidth.AutoSize = true;
            this.LabelWidth.Location = new System.Drawing.Point(34, 31);
            this.LabelWidth.Name = "LabelWidth";
            this.LabelWidth.Size = new System.Drawing.Size(49, 20);
            this.LabelWidth.TabIndex = 0;
            this.LabelWidth.Text = "Width";
            // 
            // LabelCanvassize
            // 
            this.LabelCanvassize.AutoSize = true;
            this.LabelCanvassize.Location = new System.Drawing.Point(43, 16);
            this.LabelCanvassize.Name = "LabelCanvassize";
            this.LabelCanvassize.Size = new System.Drawing.Size(84, 20);
            this.LabelCanvassize.TabIndex = 1;
            this.LabelCanvassize.Text = "Canvas size";
            // 
            // CreateNewCanvas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 228);
            this.Controls.Add(this.LabelCanvassize);
            this.Controls.Add(this.PanelCreate);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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