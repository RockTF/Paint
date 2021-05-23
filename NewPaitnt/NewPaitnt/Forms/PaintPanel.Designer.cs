
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainPaint));
            this.pictureBoxPaint = new System.Windows.Forms.PictureBox();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.labelPolygon = new System.Windows.Forms.Label();
            this.numericUpDownPolygon = new System.Windows.Forms.NumericUpDown();
            this.labelFigures = new System.Windows.Forms.Label();
            this.panelMenuFigures = new System.Windows.Forms.Panel();
            this.btnSguare = new System.Windows.Forms.Button();
            this.btnRectangle = new System.Windows.Forms.Button();
            this.btnHexagon = new System.Windows.Forms.Button();
            this.btnEllipse = new System.Windows.Forms.Button();
            this.btnTriangle = new System.Windows.Forms.Button();
            this.btnSmoothCorve = new System.Windows.Forms.Button();
            this.btnPoint = new System.Windows.Forms.Button();
            this.btnLine = new System.Windows.Forms.Button();
            this.pictureBoxColorFillFigure = new System.Windows.Forms.PictureBox();
            this.labelColor2 = new System.Windows.Forms.Label();
            this.labelColors = new System.Windows.Forms.Label();
            this.pictureBoxColors = new System.Windows.Forms.PictureBox();
            this.checkBoxAntiAliasing = new System.Windows.Forms.CheckBox();
            this.pictureBoxPen = new System.Windows.Forms.PictureBox();
            this.btnCurve = new System.Windows.Forms.Button();
            this.btnRedo = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnFill = new System.Windows.Forms.Button();
            this.btnMidnightBlue = new System.Windows.Forms.Button();
            this.btnIndigo = new System.Windows.Forms.Button();
            this.btnTan = new System.Windows.Forms.Button();
            this.btnOliveDrab = new System.Windows.Forms.Button();
            this.btnBlack = new System.Windows.Forms.Button();
            this.btnPlum = new System.Windows.Forms.Button();
            this.btnGray = new System.Windows.Forms.Button();
            this.btnPink = new System.Windows.Forms.Button();
            this.btnSteelBlue = new System.Windows.Forms.Button();
            this.btnOrange = new System.Windows.Forms.Button();
            this.btnGold = new System.Windows.Forms.Button();
            this.btnMarron = new System.Windows.Forms.Button();
            this.btnDarkOliveGreen = new System.Windows.Forms.Button();
            this.btnWheat = new System.Windows.Forms.Button();
            this.btnWhite = new System.Windows.Forms.Button();
            this.btnRed = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labelSize = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.comboBoxContour = new System.Windows.Forms.ComboBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.footer = new System.Windows.Forms.Panel();
            this.memoryLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuClear = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPaint)).BeginInit();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPolygon)).BeginInit();
            this.panelMenuFigures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColorFillFigure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.footer.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxPaint
            // 
            this.pictureBoxPaint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxPaint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.pictureBoxPaint.Location = new System.Drawing.Point(11, 156);
            this.pictureBoxPaint.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxPaint.Name = "pictureBoxPaint";
            this.pictureBoxPaint.Size = new System.Drawing.Size(1046, 551);
            this.pictureBoxPaint.TabIndex = 0;
            this.pictureBoxPaint.TabStop = false;
            this.pictureBoxPaint.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxPaint_MouseDown);
            this.pictureBoxPaint.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxPaint_MouseMove);
            this.pictureBoxPaint.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxPaint_MouseUp);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.SystemColors.Control;
            this.panelMenu.Controls.Add(this.labelFigures);
            this.panelMenu.Controls.Add(this.panelMenuFigures);
            this.panelMenu.Controls.Add(this.pictureBoxColorFillFigure);
            this.panelMenu.Controls.Add(this.labelColor2);
            this.panelMenu.Controls.Add(this.labelColors);
            this.panelMenu.Controls.Add(this.pictureBoxColors);
            this.panelMenu.Controls.Add(this.checkBoxAntiAliasing);
            this.panelMenu.Controls.Add(this.pictureBoxPen);
            this.panelMenu.Controls.Add(this.btnCurve);
            this.panelMenu.Controls.Add(this.btnRedo);
            this.panelMenu.Controls.Add(this.btnUndo);
            this.panelMenu.Controls.Add(this.btnFill);
            this.panelMenu.Controls.Add(this.btnMidnightBlue);
            this.panelMenu.Controls.Add(this.btnIndigo);
            this.panelMenu.Controls.Add(this.btnTan);
            this.panelMenu.Controls.Add(this.btnOliveDrab);
            this.panelMenu.Controls.Add(this.btnBlack);
            this.panelMenu.Controls.Add(this.btnPlum);
            this.panelMenu.Controls.Add(this.btnGray);
            this.panelMenu.Controls.Add(this.btnPink);
            this.panelMenu.Controls.Add(this.btnSteelBlue);
            this.panelMenu.Controls.Add(this.btnOrange);
            this.panelMenu.Controls.Add(this.btnGold);
            this.panelMenu.Controls.Add(this.btnMarron);
            this.panelMenu.Controls.Add(this.btnDarkOliveGreen);
            this.panelMenu.Controls.Add(this.btnWheat);
            this.panelMenu.Controls.Add(this.btnWhite);
            this.panelMenu.Controls.Add(this.btnRed);
            this.panelMenu.Controls.Add(this.pictureBox2);
            this.panelMenu.Controls.Add(this.labelSize);
            this.panelMenu.Controls.Add(this.trackBar1);
            this.panelMenu.Controls.Add(this.comboBoxContour);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(0, 24);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(1054, 107);
            this.panelMenu.TabIndex = 1;
            // 
            // labelPolygon
            // 
            this.labelPolygon.AutoSize = true;
            this.labelPolygon.BackColor = System.Drawing.Color.Transparent;
            this.labelPolygon.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPolygon.Location = new System.Drawing.Point(4, 58);
            this.labelPolygon.Name = "labelPolygon";
            this.labelPolygon.Size = new System.Drawing.Size(49, 13);
            this.labelPolygon.TabIndex = 58;
            this.labelPolygon.Text = "Polygon";
            // 
            // numericUpDownPolygon
            // 
            this.numericUpDownPolygon.Location = new System.Drawing.Point(58, 56);
            this.numericUpDownPolygon.Name = "numericUpDownPolygon";
            this.numericUpDownPolygon.Size = new System.Drawing.Size(40, 23);
            this.numericUpDownPolygon.TabIndex = 57;
            // 
            // labelFigures
            // 
            this.labelFigures.AutoSize = true;
            this.labelFigures.BackColor = System.Drawing.Color.Transparent;
            this.labelFigures.Location = new System.Drawing.Point(427, 9);
            this.labelFigures.Name = "labelFigures";
            this.labelFigures.Size = new System.Drawing.Size(45, 15);
            this.labelFigures.TabIndex = 56;
            this.labelFigures.Text = "Figures";
            // 
            // panelMenuFigures
            // 
            this.panelMenuFigures.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMenuFigures.Controls.Add(this.labelPolygon);
            this.panelMenuFigures.Controls.Add(this.numericUpDownPolygon);
            this.panelMenuFigures.Controls.Add(this.btnSguare);
            this.panelMenuFigures.Controls.Add(this.btnRectangle);
            this.panelMenuFigures.Controls.Add(this.btnHexagon);
            this.panelMenuFigures.Controls.Add(this.btnEllipse);
            this.panelMenuFigures.Controls.Add(this.btnTriangle);
            this.panelMenuFigures.Controls.Add(this.btnSmoothCorve);
            this.panelMenuFigures.Controls.Add(this.btnPoint);
            this.panelMenuFigures.Controls.Add(this.btnLine);
            this.panelMenuFigures.Location = new System.Drawing.Point(416, 15);
            this.panelMenuFigures.Name = "panelMenuFigures";
            this.panelMenuFigures.Size = new System.Drawing.Size(101, 79);
            this.panelMenuFigures.TabIndex = 55;
            // 
            // btnSguare
            // 
            this.btnSguare.FlatAppearance.BorderSize = 0;
            this.btnSguare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSguare.Image = ((System.Drawing.Image)(resources.GetObject("btnSguare.Image")));
            this.btnSguare.Location = new System.Drawing.Point(28, 11);
            this.btnSguare.Name = "btnSguare";
            this.btnSguare.Size = new System.Drawing.Size(20, 20);
            this.btnSguare.TabIndex = 47;
            this.btnSguare.UseVisualStyleBackColor = true;
            // 
            // btnRectangle
            // 
            this.btnRectangle.FlatAppearance.BorderSize = 0;
            this.btnRectangle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRectangle.Image = ((System.Drawing.Image)(resources.GetObject("btnRectangle.Image")));
            this.btnRectangle.Location = new System.Drawing.Point(4, 11);
            this.btnRectangle.Name = "btnRectangle";
            this.btnRectangle.Size = new System.Drawing.Size(20, 20);
            this.btnRectangle.TabIndex = 8;
            this.btnRectangle.UseVisualStyleBackColor = true;
            this.btnRectangle.Click += new System.EventHandler(this.btnRectangle_Click);
            // 
            // btnHexagon
            // 
            this.btnHexagon.FlatAppearance.BorderSize = 0;
            this.btnHexagon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHexagon.Image = ((System.Drawing.Image)(resources.GetObject("btnHexagon.Image")));
            this.btnHexagon.Location = new System.Drawing.Point(75, 11);
            this.btnHexagon.Name = "btnHexagon";
            this.btnHexagon.Size = new System.Drawing.Size(20, 20);
            this.btnHexagon.TabIndex = 48;
            this.btnHexagon.UseVisualStyleBackColor = true;
            // 
            // btnEllipse
            // 
            this.btnEllipse.FlatAppearance.BorderSize = 0;
            this.btnEllipse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEllipse.Image = ((System.Drawing.Image)(resources.GetObject("btnEllipse.Image")));
            this.btnEllipse.Location = new System.Drawing.Point(52, 11);
            this.btnEllipse.Name = "btnEllipse";
            this.btnEllipse.Size = new System.Drawing.Size(20, 20);
            this.btnEllipse.TabIndex = 10;
            this.btnEllipse.UseVisualStyleBackColor = true;
            this.btnEllipse.Click += new System.EventHandler(this.btnEllipse_Click);
            // 
            // btnTriangle
            // 
            this.btnTriangle.FlatAppearance.BorderSize = 0;
            this.btnTriangle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTriangle.Image = ((System.Drawing.Image)(resources.GetObject("btnTriangle.Image")));
            this.btnTriangle.Location = new System.Drawing.Point(5, 32);
            this.btnTriangle.Name = "btnTriangle";
            this.btnTriangle.Size = new System.Drawing.Size(20, 20);
            this.btnTriangle.TabIndex = 9;
            this.btnTriangle.UseVisualStyleBackColor = true;
            this.btnTriangle.Click += new System.EventHandler(this.btnTriangle_Click);
            // 
            // btnSmoothCorve
            // 
            this.btnSmoothCorve.FlatAppearance.BorderSize = 0;
            this.btnSmoothCorve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSmoothCorve.Image = ((System.Drawing.Image)(resources.GetObject("btnSmoothCorve.Image")));
            this.btnSmoothCorve.Location = new System.Drawing.Point(52, 33);
            this.btnSmoothCorve.Name = "btnSmoothCorve";
            this.btnSmoothCorve.Size = new System.Drawing.Size(20, 20);
            this.btnSmoothCorve.TabIndex = 45;
            this.btnSmoothCorve.UseVisualStyleBackColor = true;
            this.btnSmoothCorve.Click += new System.EventHandler(this.SmoothCorve);
            // 
            // btnPoint
            // 
            this.btnPoint.FlatAppearance.BorderSize = 0;
            this.btnPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPoint.Image = ((System.Drawing.Image)(resources.GetObject("btnPoint.Image")));
            this.btnPoint.Location = new System.Drawing.Point(76, 33);
            this.btnPoint.Name = "btnPoint";
            this.btnPoint.Size = new System.Drawing.Size(20, 20);
            this.btnPoint.TabIndex = 15;
            this.btnPoint.UseVisualStyleBackColor = true;
            this.btnPoint.Click += new System.EventHandler(this.btnPoint_Click);
            // 
            // btnLine
            // 
            this.btnLine.FlatAppearance.BorderSize = 0;
            this.btnLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLine.Image = ((System.Drawing.Image)(resources.GetObject("btnLine.Image")));
            this.btnLine.Location = new System.Drawing.Point(29, 32);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(20, 20);
            this.btnLine.TabIndex = 7;
            this.btnLine.UseVisualStyleBackColor = true;
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // pictureBoxColorFillFigure
            // 
            this.pictureBoxColorFillFigure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxColorFillFigure.Location = new System.Drawing.Point(766, 27);
            this.pictureBoxColorFillFigure.Name = "pictureBoxColorFillFigure";
            this.pictureBoxColorFillFigure.Size = new System.Drawing.Size(35, 35);
            this.pictureBoxColorFillFigure.TabIndex = 51;
            this.pictureBoxColorFillFigure.TabStop = false;
            // 
            // labelColor2
            // 
            this.labelColor2.AutoSize = true;
            this.labelColor2.BackColor = System.Drawing.Color.Transparent;
            this.labelColor2.Location = new System.Drawing.Point(766, 65);
            this.labelColor2.Name = "labelColor2";
            this.labelColor2.Size = new System.Drawing.Size(36, 15);
            this.labelColor2.TabIndex = 48;
            this.labelColor2.Text = "Color";
            // 
            // labelColors
            // 
            this.labelColors.AutoSize = true;
            this.labelColors.BackColor = System.Drawing.Color.Transparent;
            this.labelColors.Location = new System.Drawing.Point(988, 65);
            this.labelColors.Name = "labelColors";
            this.labelColors.Size = new System.Drawing.Size(41, 15);
            this.labelColors.TabIndex = 46;
            this.labelColors.Text = "Colors";
            // 
            // pictureBoxColors
            // 
            this.pictureBoxColors.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxColors.ErrorImage = null;
            this.pictureBoxColors.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxColors.Image")));
            this.pictureBoxColors.Location = new System.Drawing.Point(979, 27);
            this.pictureBoxColors.Name = "pictureBoxColors";
            this.pictureBoxColors.Size = new System.Drawing.Size(60, 38);
            this.pictureBoxColors.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxColors.TabIndex = 45;
            this.pictureBoxColors.TabStop = false;
            // 
            // checkBoxAntiAliasing
            // 
            this.checkBoxAntiAliasing.AutoSize = true;
            this.checkBoxAntiAliasing.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxAntiAliasing.Location = new System.Drawing.Point(301, 62);
            this.checkBoxAntiAliasing.Name = "checkBoxAntiAliasing";
            this.checkBoxAntiAliasing.Size = new System.Drawing.Size(88, 17);
            this.checkBoxAntiAliasing.TabIndex = 44;
            this.checkBoxAntiAliasing.Text = "AntiAliasing";
            this.checkBoxAntiAliasing.UseVisualStyleBackColor = true;
            this.checkBoxAntiAliasing.CheckedChanged += new System.EventHandler(this.checkBoxAntiAliasing_CheckedChanged);
            // 
            // pictureBoxPen
            // 
            this.pictureBoxPen.BackColor = System.Drawing.Color.White;
            this.pictureBoxPen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPen.Location = new System.Drawing.Point(260, 20);
            this.pictureBoxPen.Name = "pictureBoxPen";
            this.pictureBoxPen.Size = new System.Drawing.Size(35, 35);
            this.pictureBoxPen.TabIndex = 43;
            this.pictureBoxPen.TabStop = false;
            // 
            // btnCurve
            // 
            this.btnCurve.FlatAppearance.BorderSize = 0;
            this.btnCurve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCurve.Image = ((System.Drawing.Image)(resources.GetObject("btnCurve.Image")));
            this.btnCurve.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCurve.Location = new System.Drawing.Point(127, 15);
            this.btnCurve.Name = "btnCurve";
            this.btnCurve.Size = new System.Drawing.Size(57, 20);
            this.btnCurve.TabIndex = 14;
            this.btnCurve.Text = "Pen";
            this.btnCurve.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCurve.UseVisualStyleBackColor = true;
            this.btnCurve.Click += new System.EventHandler(this.btnCurve_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.FlatAppearance.BorderSize = 0;
            this.btnRedo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRedo.Image = ((System.Drawing.Image)(resources.GetObject("btnRedo.Image")));
            this.btnRedo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRedo.Location = new System.Drawing.Point(21, 56);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(66, 23);
            this.btnRedo.TabIndex = 42;
            this.btnRedo.Text = "Redo";
            this.btnRedo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRedo.UseVisualStyleBackColor = true;
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.FlatAppearance.BorderSize = 0;
            this.btnUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUndo.Image = ((System.Drawing.Image)(resources.GetObject("btnUndo.Image")));
            this.btnUndo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUndo.Location = new System.Drawing.Point(21, 28);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(66, 23);
            this.btnUndo.TabIndex = 40;
            this.btnUndo.Text = "Undo";
            this.btnUndo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnFill
            // 
            this.btnFill.FlatAppearance.BorderSize = 0;
            this.btnFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFill.Image = ((System.Drawing.Image)(resources.GetObject("btnFill.Image")));
            this.btnFill.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFill.Location = new System.Drawing.Point(122, 70);
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(95, 23);
            this.btnFill.TabIndex = 39;
            this.btnFill.Text = "Fill figures";
            this.btnFill.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFill.UseVisualStyleBackColor = true;
            this.btnFill.Click += new System.EventHandler(this.btnFill_Click);
            // 
            // btnMidnightBlue
            // 
            this.btnMidnightBlue.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnMidnightBlue.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMidnightBlue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMidnightBlue.Location = new System.Drawing.Point(911, 54);
            this.btnMidnightBlue.Name = "btnMidnightBlue";
            this.btnMidnightBlue.Size = new System.Drawing.Size(18, 18);
            this.btnMidnightBlue.TabIndex = 37;
            this.btnMidnightBlue.UseVisualStyleBackColor = false;
            // 
            // btnIndigo
            // 
            this.btnIndigo.BackColor = System.Drawing.Color.Indigo;
            this.btnIndigo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnIndigo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIndigo.Location = new System.Drawing.Point(871, 54);
            this.btnIndigo.Name = "btnIndigo";
            this.btnIndigo.Size = new System.Drawing.Size(18, 18);
            this.btnIndigo.TabIndex = 36;
            this.btnIndigo.UseVisualStyleBackColor = false;
            // 
            // btnTan
            // 
            this.btnTan.BackColor = System.Drawing.Color.Tan;
            this.btnTan.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnTan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTan.Location = new System.Drawing.Point(851, 34);
            this.btnTan.Name = "btnTan";
            this.btnTan.Size = new System.Drawing.Size(18, 18);
            this.btnTan.TabIndex = 33;
            this.btnTan.UseVisualStyleBackColor = false;
            // 
            // btnOliveDrab
            // 
            this.btnOliveDrab.BackColor = System.Drawing.Color.OliveDrab;
            this.btnOliveDrab.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOliveDrab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOliveDrab.Location = new System.Drawing.Point(811, 54);
            this.btnOliveDrab.Name = "btnOliveDrab";
            this.btnOliveDrab.Size = new System.Drawing.Size(18, 18);
            this.btnOliveDrab.TabIndex = 32;
            this.btnOliveDrab.UseVisualStyleBackColor = false;
            // 
            // btnBlack
            // 
            this.btnBlack.BackColor = System.Drawing.Color.Black;
            this.btnBlack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBlack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBlack.Location = new System.Drawing.Point(951, 54);
            this.btnBlack.Name = "btnBlack";
            this.btnBlack.Size = new System.Drawing.Size(18, 18);
            this.btnBlack.TabIndex = 25;
            this.btnBlack.UseVisualStyleBackColor = false;
            // 
            // btnPlum
            // 
            this.btnPlum.BackColor = System.Drawing.Color.Plum;
            this.btnPlum.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPlum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlum.Location = new System.Drawing.Point(851, 54);
            this.btnPlum.Name = "btnPlum";
            this.btnPlum.Size = new System.Drawing.Size(18, 18);
            this.btnPlum.TabIndex = 24;
            this.btnPlum.UseVisualStyleBackColor = false;
            // 
            // btnGray
            // 
            this.btnGray.BackColor = System.Drawing.Color.DimGray;
            this.btnGray.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGray.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGray.Location = new System.Drawing.Point(931, 54);
            this.btnGray.Name = "btnGray";
            this.btnGray.Size = new System.Drawing.Size(18, 18);
            this.btnGray.TabIndex = 23;
            this.btnGray.UseVisualStyleBackColor = false;
            // 
            // btnPink
            // 
            this.btnPink.BackColor = System.Drawing.Color.Pink;
            this.btnPink.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPink.Location = new System.Drawing.Point(911, 34);
            this.btnPink.Name = "btnPink";
            this.btnPink.Size = new System.Drawing.Size(18, 18);
            this.btnPink.TabIndex = 22;
            this.btnPink.UseVisualStyleBackColor = false;
            // 
            // btnSteelBlue
            // 
            this.btnSteelBlue.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSteelBlue.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSteelBlue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSteelBlue.Location = new System.Drawing.Point(891, 54);
            this.btnSteelBlue.Name = "btnSteelBlue";
            this.btnSteelBlue.Size = new System.Drawing.Size(18, 18);
            this.btnSteelBlue.TabIndex = 21;
            this.btnSteelBlue.UseVisualStyleBackColor = false;
            // 
            // btnOrange
            // 
            this.btnOrange.BackColor = System.Drawing.Color.Orange;
            this.btnOrange.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOrange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrange.Location = new System.Drawing.Point(891, 34);
            this.btnOrange.Name = "btnOrange";
            this.btnOrange.Size = new System.Drawing.Size(18, 18);
            this.btnOrange.TabIndex = 20;
            this.btnOrange.UseVisualStyleBackColor = false;
            // 
            // btnGold
            // 
            this.btnGold.BackColor = System.Drawing.Color.Gold;
            this.btnGold.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGold.Location = new System.Drawing.Point(871, 34);
            this.btnGold.Name = "btnGold";
            this.btnGold.Size = new System.Drawing.Size(18, 18);
            this.btnGold.TabIndex = 19;
            this.btnGold.UseVisualStyleBackColor = false;
            // 
            // btnMarron
            // 
            this.btnMarron.BackColor = System.Drawing.Color.Maroon;
            this.btnMarron.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMarron.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarron.Location = new System.Drawing.Point(951, 34);
            this.btnMarron.Name = "btnMarron";
            this.btnMarron.Size = new System.Drawing.Size(18, 18);
            this.btnMarron.TabIndex = 18;
            this.btnMarron.UseVisualStyleBackColor = false;
            // 
            // btnDarkOliveGreen
            // 
            this.btnDarkOliveGreen.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnDarkOliveGreen.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDarkOliveGreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDarkOliveGreen.Location = new System.Drawing.Point(831, 54);
            this.btnDarkOliveGreen.Name = "btnDarkOliveGreen";
            this.btnDarkOliveGreen.Size = new System.Drawing.Size(18, 18);
            this.btnDarkOliveGreen.TabIndex = 17;
            this.btnDarkOliveGreen.UseVisualStyleBackColor = false;
            // 
            // btnWheat
            // 
            this.btnWheat.BackColor = System.Drawing.Color.Wheat;
            this.btnWheat.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnWheat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWheat.Location = new System.Drawing.Point(831, 34);
            this.btnWheat.Name = "btnWheat";
            this.btnWheat.Size = new System.Drawing.Size(18, 18);
            this.btnWheat.TabIndex = 16;
            this.btnWheat.UseVisualStyleBackColor = false;
            // 
            // btnWhite
            // 
            this.btnWhite.BackColor = System.Drawing.Color.White;
            this.btnWhite.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnWhite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWhite.Location = new System.Drawing.Point(811, 34);
            this.btnWhite.Name = "btnWhite";
            this.btnWhite.Size = new System.Drawing.Size(18, 18);
            this.btnWhite.TabIndex = 15;
            this.btnWhite.UseVisualStyleBackColor = false;
            // 
            // btnRed
            // 
            this.btnRed.BackColor = System.Drawing.Color.Red;
            this.btnRed.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRed.Location = new System.Drawing.Point(931, 34);
            this.btnRed.Name = "btnRed";
            this.btnRed.Size = new System.Drawing.Size(18, 18);
            this.btnRed.TabIndex = 14;
            this.btnRed.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(128, 42);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.BackColor = System.Drawing.Color.Transparent;
            this.labelSize.Location = new System.Drawing.Point(330, 16);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(27, 15);
            this.labelSize.TabIndex = 5;
            this.labelSize.Text = "Size";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(290, 28);
            this.trackBar1.Maximum = 32;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(107, 45);
            this.trackBar1.TabIndex = 4;
            this.trackBar1.TickFrequency = 2;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // comboBoxContour
            // 
            this.comboBoxContour.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxContour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxContour.FormattingEnabled = true;
            this.comboBoxContour.Items.AddRange(new object[] {
            "―――",
            "-------",
            "− ∙ − ∙"});
            this.comboBoxContour.Location = new System.Drawing.Point(151, 41);
            this.comboBoxContour.Name = "comboBoxContour";
            this.comboBoxContour.Size = new System.Drawing.Size(70, 23);
            this.comboBoxContour.TabIndex = 2;
            this.comboBoxContour.Text = "Contour";
            this.comboBoxContour.SelectedIndexChanged += new System.EventHandler(this.comboBoxContour_SelectedIndexChanged);
            // 
            // footer
            // 
            this.footer.BackColor = System.Drawing.SystemColors.Control;
            this.footer.Controls.Add(this.memoryLabel);
            this.footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer.Location = new System.Drawing.Point(0, 707);
            this.footer.Margin = new System.Windows.Forms.Padding(0);
            this.footer.Name = "footer";
            this.footer.Size = new System.Drawing.Size(1054, 20);
            this.footer.TabIndex = 2;
            // 
            // memoryLabel
            // 
            this.memoryLabel.AutoSize = true;
            this.memoryLabel.Location = new System.Drawing.Point(11, 3);
            this.memoryLabel.Margin = new System.Windows.Forms.Padding(0);
            this.memoryLabel.Name = "memoryLabel";
            this.memoryLabel.Size = new System.Drawing.Size(128, 15);
            this.memoryLabel.TabIndex = 0;
            this.memoryLabel.Text = "Memory usage: 0,0 MB";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1054, 24);
            this.menuStrip1.TabIndex = 3;
            // 
            // toolStripMenuFile
            // 
            this.toolStripMenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuCreate,
            this.toolStripMenuOpen,
            this.toolStripMenuSave,
            this.toolStripMenuClear});
            this.toolStripMenuFile.Name = "toolStripMenuFile";
            this.toolStripMenuFile.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuFile.Text = "File";
            // 
            // toolStripMenuCreate
            // 
            this.toolStripMenuCreate.Name = "toolStripMenuCreate";
            this.toolStripMenuCreate.Size = new System.Drawing.Size(108, 22);
            this.toolStripMenuCreate.Text = "Create";
            // 
            // toolStripMenuOpen
            // 
            this.toolStripMenuOpen.Name = "toolStripMenuOpen";
            this.toolStripMenuOpen.Size = new System.Drawing.Size(108, 22);
            this.toolStripMenuOpen.Text = "Open";
            // 
            // toolStripMenuSave
            // 
            this.toolStripMenuSave.Name = "toolStripMenuSave";
            this.toolStripMenuSave.Size = new System.Drawing.Size(108, 22);
            this.toolStripMenuSave.Text = "Save";
            // 
            // toolStripMenuClear
            // 
            this.toolStripMenuClear.Name = "toolStripMenuClear";
            this.toolStripMenuClear.Size = new System.Drawing.Size(108, 22);
            this.toolStripMenuClear.Text = "Clear";
            // 
            // mainPaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1054, 727);
            this.Controls.Add(this.footer);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.pictureBoxPaint);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "mainPaint";
            this.Text = "Paint";
            this.Load += new System.EventHandler(this.mainPaint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPaint)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPolygon)).EndInit();
            this.panelMenuFigures.ResumeLayout(false);
            this.panelMenuFigures.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColorFillFigure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.footer.ResumeLayout(false);
            this.footer.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxPaint;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.ComboBox comboBoxContour;
        private System.Windows.Forms.Button btnRed;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button btnBlack;
        private System.Windows.Forms.Button btnPlum;
        private System.Windows.Forms.Button btnGray;
        private System.Windows.Forms.Button btnPink;
        private System.Windows.Forms.Button btnSteelBlue;
        private System.Windows.Forms.Button btnOrange;
        private System.Windows.Forms.Button btnGold;
        private System.Windows.Forms.Button btnMarron;
        private System.Windows.Forms.Button btnWheat;
        private System.Windows.Forms.Button btnWhite;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Button btnDarkOliveGreen;
        private System.Windows.Forms.Button btnMidnightBlue;
        private System.Windows.Forms.Button btnIndigo;
        private System.Windows.Forms.Button btnTan;
        private System.Windows.Forms.Button btnOliveDrab;
        private System.Windows.Forms.Button btnPoint;
        private System.Windows.Forms.Button btnCurve;
        private System.Windows.Forms.Button btnEllipse;
        private System.Windows.Forms.Button btnTriangle;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Button btnRectangle;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnFill;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.Panel footer;
        private System.Windows.Forms.Label memoryLabel;
        private System.Windows.Forms.PictureBox pictureBoxPen;
        private System.Windows.Forms.CheckBox checkBoxAntiAliasing;
        private System.Windows.Forms.Button btnSmoothCorve;
        private System.Windows.Forms.PictureBox pictureBoxColors;
        private System.Windows.Forms.Label labelColors;
        private System.Windows.Forms.Label labelColor2;
        private System.Windows.Forms.Button btnHexagon;
        private System.Windows.Forms.Button btnSguare;
        private System.Windows.Forms.PictureBox pictureBoxColorFillFigure;
        private System.Windows.Forms.Label labelFigures;
        private System.Windows.Forms.Panel panelMenuFigures;
        private System.Windows.Forms.Label labelPolygon;
        private System.Windows.Forms.NumericUpDown numericUpDownPolygon;
        private System.Windows.Forms.Label LAPolygon;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuCreate;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuOpen;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuSave;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuClear;
    }
}

