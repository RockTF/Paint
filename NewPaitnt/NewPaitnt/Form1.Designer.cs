
namespace NewPaitnt
{
    partial class mainPaint
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxPaint = new System.Windows.Forms.PictureBox();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.comboBoxContour = new System.Windows.Forms.ComboBox();
            this.comboBoxBrushes = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPaint)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxPaint
            // 
            this.pictureBoxPaint.BackColor = System.Drawing.Color.White;
            this.pictureBoxPaint.Location = new System.Drawing.Point(12, 81);
            this.pictureBoxPaint.Name = "pictureBoxPaint";
            this.pictureBoxPaint.Size = new System.Drawing.Size(831, 487);
            this.pictureBoxPaint.TabIndex = 0;
            this.pictureBoxPaint.TabStop = false;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.White;
            this.panelMenu.Controls.Add(this.comboBoxBrushes);
            this.panelMenu.Controls.Add(this.comboBoxContour);
            this.panelMenu.Controls.Add(this.btnDelete);
            this.panelMenu.Controls.Add(this.btnSave);
            this.panelMenu.Location = new System.Drawing.Point(0, -2);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(854, 72);
            this.panelMenu.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 21);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(90, 21);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(72, 30);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // comboBoxContour
            // 
            this.comboBoxContour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxContour.FormattingEnabled = true;
            this.comboBoxContour.Location = new System.Drawing.Point(194, 26);
            this.comboBoxContour.Name = "comboBoxContour";
            this.comboBoxContour.Size = new System.Drawing.Size(70, 23);
            this.comboBoxContour.TabIndex = 2;
            this.comboBoxContour.Text = "Contour";
            // 
            // comboBoxBrushes
            // 
            this.comboBoxBrushes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxBrushes.FormattingEnabled = true;
            this.comboBoxBrushes.Location = new System.Drawing.Point(284, 26);
            this.comboBoxBrushes.Name = "comboBoxBrushes";
            this.comboBoxBrushes.Size = new System.Drawing.Size(70, 23);
            this.comboBoxBrushes.TabIndex = 3;
            this.comboBoxBrushes.Text = "Brushes";
            // 
            // mainPaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 581);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.pictureBoxPaint);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "mainPaint";
            this.Text = "Paint";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPaint)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxPaint;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.ComboBox comboBoxBrushes;
        private System.Windows.Forms.ComboBox comboBoxContour;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
    }
}

