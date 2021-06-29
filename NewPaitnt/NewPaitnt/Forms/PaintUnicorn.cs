﻿using NewPaitnt.Enum;
using NewPaitnt.Forms;
using NewPaitnt.Implementation;
using NewPaitnt.Interfaces;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;

namespace NewPaitnt
{
    public partial class MainPaint : Form
    {
        Process currentProcess;
        Settings settings;
        MouseHandler mouseHandler;
        PenPreview penPreview;
        DrawingEngine drawingEngine;
        IStorage storage;


        private bool _isBtnFillClicked;
        private bool _isFigureCreated;
        private bool _isLineFinished;
        private bool _isFirstPointAdd;
        private bool _isFigureSelected;


        public MainPaint()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }


        private void MainPaint_Load(object sender, EventArgs e)
        {
            settings = Settings.Initialize();
            mouseHandler = MouseHandler.Initialize();
            storage = Storage.Initialize();
            penPreview = PenPreview.Initialize(settings.PenColor, settings.PenWidth, settings.IsSmoothed, PictureBoxThickness.Width, PictureBoxThickness.Height);

            drawingEngine = new DrawingEngine(settings, mouseHandler, storage);

            PictureBoxThickness.Image = penPreview.PenBitmap;

            PictureBoxPaint.Image = drawingEngine.GetMainImage();

            currentProcess = Process.GetCurrentProcess();
            currentProcess.Refresh();
            memoryLabel.Text = "Memory usage: " + ((float)currentProcess.PrivateMemorySize64 / 1024f / 1024f).ToString("F1") + "MB";

            _isLineFinished = true;
            _isBtnFillClicked = false;
            _isFigureCreated = false;
            _isFirstPointAdd = false;
            _isFigureSelected = false;


            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

            NumericUpDownPolygon.Value = settings.numberOfPolygonApexes;
        }

        private void PictureBoxPaint_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                drawingEngine.DrawMainOnBackground();
                mouseHandler.NewClick(e.Location);

                if (settings.Mode == EMode.SmoothCurve)
                {
                    _isLineFinished = false;
                }
                if (!_isLineFinished && _isFirstPointAdd)
                {
                    drawingEngine.AddPointToCurve();
                }
                else if (!_isLineFinished && !_isFirstPointAdd)
                {
                    _isFirstPointAdd = true;
                }
                if (settings.Mode == EMode.Dot)
                {
                    _isFigureCreated = true;
                    drawingEngine.DrawNewFigure();
                }
                else if (settings.Mode == EMode.Move)
                {
                    drawingEngine.SelectFigure();
                }
                PictureBoxPaint.Image = drawingEngine.GetMainImage();
            }
            if (e.Button == MouseButtons.Right)
            {
                _isLineFinished = true;
                _isFigureCreated = false;
                _isFirstPointAdd = false;
            }
        }

        private void PictureBoxPaint_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (settings.Mode != EMode.Dot && settings.Mode != EMode.Move)
                {
                    mouseHandler.NewMove(e.Location);
                }
                if (settings.Mode != EMode.Move)
                {
                    if (!_isFigureCreated)
                    {
                        _isFigureCreated = true;
                        drawingEngine.DrawNewFigure();
                    }
                    else
                    {
                        drawingEngine.RedrawNewFigure();
                    }
                }

                PictureBoxPaint.Image = drawingEngine.GetMainImage();

                if (settings.Mode == EMode.Move)
                {
                    mouseHandler.NewMove(e.Location);
                    drawingEngine.MoveFigure();
                    PictureBoxPaint.Image = drawingEngine.GetMainImage();
                }
            }
            else if (settings.Mode == EMode.SmoothCurve && !_isLineFinished)
            {
                mouseHandler.NewMove(e.Location);
                if (!_isFigureCreated)
                {
                    _isFigureCreated = true;
                    drawingEngine.DrawNewFigure();
                }
                else
                {
                    drawingEngine.ClearAllExceptMainImage();
                    drawingEngine.RedrawNewFigure();
                }
                PictureBoxPaint.Image = drawingEngine.GetMainImage();
            }
        }

        private void PictureBoxPaint_MouseUp(object sender, MouseEventArgs e)
        {
            if (settings.Mode != EMode.SmoothCurve)
            {
                _isFigureCreated = false;
                drawingEngine.CleanBackground();
            }

            currentProcess.Refresh();
            memoryLabel.Text = "Memory usage: " + ((float)currentProcess.PrivateMemorySize64 / 1024f / 1024f).ToString("F1") + " MB";

            FiguresListBox.Items.Clear();
            FiguresListBox.Items.AddRange(drawingEngine.GetFigureList());
        }

        private void MenuCreate_Click(object sender, EventArgs e)
        {
            CreateNewCanvas createNewCanvas = (CreateNewCanvas)Application.OpenForms["CreateNewCanvas"];

            if (createNewCanvas == null)
            {
                if (BtnMove.Enabled)
                {
                    settings.SetMode(EMode.Curve);
                }
                createNewCanvas = new CreateNewCanvas(this, drawingEngine);
                createNewCanvas.Show();
            }
            else
            {
                createNewCanvas.Activate();

                if (createNewCanvas.ShowDialog() == DialogResult.OK)
                {
                    FigureFactory figureFactory = new FigureFactory();
                    figureFactory.ResetAllCounters();
                    PictureBoxPaint.Image = drawingEngine.GetMainImage();
                }
            }
            
        }

        private void MenuSave_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = "newUnicorn";
            saveFileDialog.Filter = "JPG Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|PNG Image|*.png|JSON File|*.json";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog.FilterIndex == 5)
                {
                    File.WriteAllText(saveFileDialog.FileName, storage.GetJson());
                }
                else if (PictureBoxPaint != null)
                {
                    PictureBoxPaint.Image.Save(saveFileDialog.FileName);
                }
            }
        }

        private void MenuOpen_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "JPG Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|PNG Image|*.png|JSON File|*.json|All|*.*";

            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.FilterIndex == 5)
                {
                    FigureFactory figureFactory = new FigureFactory();
                    figureFactory.ResetAllCounters();
                    string json = File.ReadAllText(openFileDialog.FileName);
                    storage.SetJson(json);
                    drawingEngine.DrawAllFigures();
                    PictureBoxPaint.Image = drawingEngine.GetMainImage();
                    FiguresListBox.Items.Clear();
                    FiguresListBox.Items.AddRange(drawingEngine.GetFigureList());
                }
                else
                {
                    drawingEngine.SetCanvasImage((Bitmap)Image.FromFile(openFileDialog.FileName));
                    settings.SetImageWidth(Image.FromFile(openFileDialog.FileName).Width);
                    settings.SetImageHeight(Image.FromFile(openFileDialog.FileName).Height);
                    drawingEngine.DrawAllFigures();
                    PictureBoxPaint.Image = drawingEngine.GetMainImage();
                }
            }
        }

        private void MenuClear_Click(object sender, EventArgs e)
        {
            drawingEngine.ClearStorage();
            drawingEngine.ClearCanvas();
            PictureBoxPaint.Image = drawingEngine.GetMainImage();
            FiguresListBox.Items.Clear();
            FiguresListBox.Items.AddRange(drawingEngine.GetFigureList());
            settings.SetMode(SettingsConstants.DefaultMode);
            _isFigureSelected = false;
        }

        private void TrackBarThickness_Scroll(object sender, EventArgs e)
        {
            settings.SetPenWidth(TrackBarThickness.Value);

            RefreshPenPreview();

            if (_isFigureSelected)
            {
                drawingEngine.UpdateFigure();
                drawingEngine.SelectFigure();
                PictureBoxPaint.Image = drawingEngine.GetMainImage();
            }
        }

        private void BtnFill_Click(object sender, EventArgs e)
        {
            _isBtnFillClicked = true;
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            drawingEngine.Undo();
            PictureBoxPaint.Image = drawingEngine.GetMainImage();
            FiguresListBox.Items.Clear();
            FiguresListBox.Items.AddRange(drawingEngine.GetFigureList());
        }

        private void BtnRedo_Click(object sender, EventArgs e)
        {
            drawingEngine.Redo();
            PictureBoxPaint.Image = drawingEngine.GetMainImage();
            FiguresListBox.Items.Clear();
            FiguresListBox.Items.AddRange(drawingEngine.GetFigureList());
        }

        private void BtnPoint_Click(object sender, EventArgs e)
        {
            settings.SetMode(EMode.Dot);
            _isFigureSelected = false;
        }

        private void BtnRectangle_Click(object sender, EventArgs e)
        {
            settings.SetMode(EMode.Rectangle);
            _isFigureSelected = false;
        }

        private void BtnEllipse_Click(object sender, EventArgs e)
        {
            settings.SetMode(EMode.Ellipse);
            _isFigureSelected = false;
        }

        private void BtnCurve_Click(object sender, EventArgs e)
        {
            settings.SetMode(EMode.Curve);
            _isFigureSelected = false;
        }

        private void BtnTriangle_Click(object sender, EventArgs e)
        {
            settings.SetMode(EMode.Triangle);
            _isFigureSelected = false;
        }

        private void BtnLine_Click(object sender, EventArgs e)
        {
            settings.SetMode(EMode.Line);
            _isFigureSelected = false;
        }

        private void SmoothCorve(object sender, EventArgs e)
        {
            settings.SetMode(EMode.SmoothCurve);
            _isFigureSelected = false;
        }

        private void BtnSguare_Click(object sender, EventArgs e)
        {
            settings.SetMode(EMode.RoundedRectangle);
            _isFigureSelected = false;
        }

        private void CheckBoxAntiAliasing_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxAntiAliasing.Checked)
            {
                settings.SetSmooth();
                ChangeAntiAliasing(SmoothingMode.AntiAlias);
            }
            else
            {
                settings.SetUnsmooth();
                ChangeAntiAliasing(SmoothingMode.AntiAlias);
            }
            
            RefreshPenPreview(); 
        }
        private void ChangeAntiAliasing(SmoothingMode smoothingMode)
        {
            if (_isFigureSelected)
            {
                drawingEngine.UpdateFigure();
                drawingEngine.SelectFigure();
                PictureBoxPaint.Image = drawingEngine.GetMainImage();
            }
        }

        private void ComboBoxContour_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ComboBoxContour.SelectedIndex)
            {
                case 0:
                    settings.SetPenDashStyle(EDashStyle.Solid);
                    ChangeDashStyle(DashStyle.Solid);
                    break;
                case 1:
                    settings.SetPenDashStyle(EDashStyle.Dash);
                    ChangeDashStyle(DashStyle.Dash);
                    break;
                case 2:
                    settings.SetPenDashStyle(EDashStyle.DashDot);
                    ChangeDashStyle(DashStyle.DashDot);
                    break;
                default:
                    break;
            }
        }

        private void ChangeDashStyle(DashStyle dashStyle)
        {
            if (_isFigureSelected)
            {
                drawingEngine.UpdateFigure();
                drawingEngine.SelectFigure();
                PictureBoxPaint.Image = drawingEngine.GetMainImage();
            }
        }

        private void Color_btn(object sender, EventArgs e)
        {
            if (_isBtnFillClicked)
            {
                settings.SetBrushColor(HexColorConverter.ColorToHex((sender as Button).BackColor));
                PictureBoxColorFillFigure.BackColor = ((Button)sender).BackColor; 
                _isBtnFillClicked = false;
                if (_isFigureSelected)
                {
                    drawingEngine.UpdateFigure();
                    drawingEngine.SelectFigure();
                }
            }
            else
            {
                settings.SetPenColor(HexColorConverter.ColorToHex((sender as Button).BackColor));
                PictureBoxColorFillFigure.BackColor = ((Button)sender).BackColor; 

                RefreshPenPreview();

                if (_isFigureSelected)
                {
                    drawingEngine.UpdateFigure();
                    drawingEngine.SelectFigure();
                }
            }
            PictureBoxPaint.Image = drawingEngine.GetMainImage();
        }

        private void PictureBoxColors_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                settings.SetBrushColor(HexColorConverter.ColorToHex(colorDialog1.Color));
                settings.SetPenColor(HexColorConverter.ColorToHex(colorDialog1.Color));
                PictureBoxColorFillFigure.BackColor = colorDialog1.Color; 

                RefreshPenPreview();
            }
        }

        private void FiguresListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            drawingEngine.SetSelectedFigure((sender as ListBox).SelectedIndex);
            _isFigureSelected = true;
        }

        private void BtnMove_Click(object sender, EventArgs e)
        {
            settings.SetMode(EMode.Move);
        }

        private void MainPaint_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (PictureBoxPaint.Image != null)
            {
                var result = MessageBox.Show("Save your changes before exiting?", "Attention", MessageBoxButtons.YesNo);
                switch (result)
                {
                    case DialogResult.No: Application.Exit();
                        break;
                    case DialogResult.Yes: MenuSave_Click(sender, e); break;
                }    
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            drawingEngine.DeleteFigure();
            FiguresListBox.Items.Clear();
            FiguresListBox.Items.AddRange(drawingEngine.GetFigureList());
            PictureBoxPaint.Image = drawingEngine.GetMainImage();
            drawingEngine.SetSelectedFigure(-1);
            _isFigureSelected = false;
        }

        private void NumericUpDownPolygon_Click(object sender, EventArgs e)
        {
            settings.SetNumberOfPolygonApexes((int)(sender as NumericUpDown).Value);
        }

        private void BtnHexagon_Click(object sender, EventArgs e)
        {
            settings.SetMode(EMode.Polygon);
            _isFigureSelected = false;
        }

        private void BtnTransparent_Click(object sender, EventArgs e)
        {
            if (_isBtnFillClicked)
            {
                settings.SetBrushColor(HexColorConverter.ColorToHex(Color.Transparent));
                PictureBoxColorFillFigure.BackColor = Color.Transparent; 
                _isBtnFillClicked = false;
                if (_isFigureSelected)
                {
                    drawingEngine.UpdateFigure();
                    drawingEngine.SelectFigure();
                }
            }
            else
            {
                settings.SetPenColor(HexColorConverter.ColorToHex(Color.Transparent));
                PictureBoxColorFillFigure.BackColor = Color.Transparent; 

                RefreshPenPreview();

                if (_isFigureSelected)
                {
                    drawingEngine.UpdateFigure();
                    drawingEngine.SelectFigure();
                }
            }
            PictureBoxPaint.Image = drawingEngine.GetMainImage();
        }

        public void RefreshPenPreview()
        {
            penPreview.DrawPen(settings.PenColor, settings.PenWidth, settings.IsSmoothed);
            PictureBoxThickness.Image = penPreview.PenBitmap;
        }

        private void BtnMyStatistics_Click(object sender, EventArgs e)
        {
            this.Hide();
            Statistics statistics = (Statistics)Application.OpenForms["Statistics"];
            if(statistics == null)
            {
                statistics = new Statistics();
                statistics.Show();
            }
            else
            {
                statistics.Activate();
                statistics.Show();
            }
        }

        private void BtnLoginOut_Click(object sender, EventArgs e)
        {
            settings.SetUserID(null);
            this.Hide();
            Welcome welcome = (Welcome)Application.OpenForms["Welcome"];
            if (welcome == null)
            {
                welcome = new Welcome();
                welcome.Show();
            }
            else
            {
                welcome.Activate();
                welcome.Show();
            }
        }

        public void RefreshPictureBox()
        {
            PictureBoxPaint.Image = drawingEngine.GetMainImage();
        }

        private void openFromCloudToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenPicture openPicture = (OpenPicture)Application.OpenForms["OpenPicture"];
            if (openPicture == null)
            {
                openPicture = new OpenPicture();
                openPicture.Show();
            }
            else
            {
                openPicture.Activate();
                openPicture.Show();
            }
        }

        private void saveToCloudToolStripMenuItem_Click(object sender, EventArgs e)
        {
            storage.SetBitmapToSave((Bitmap)PictureBoxPaint.Image);
        }
    }
}