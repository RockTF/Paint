﻿using NewPaitnt.Implementation;
using NewPaitnt.Interfaces;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text.Json;
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
        IStorage storage;
        Service service;

        DrawingEngine drawingEngine;

        private bool _isBtnFillClicked;
        private bool _isFigureCreated;
        private bool _isLineFinished;
        private bool _isFirstPointAdd;


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
            penPreview = PenPreview.Initialize(settings.Pen, PictureBoxThickness.Width, PictureBoxThickness.Height);
            storage = Storage.Initialize();
            service = Service.Initialize();

            drawingEngine = DrawingEngine.Initialize(settings, mouseHandler, penPreview, storage, service);

            PictureBoxThickness.Image = drawingEngine.GetPenImage();
            PictureBoxPaint.Image = drawingEngine.MainImage;

            currentProcess = Process.GetCurrentProcess();
            currentProcess.Refresh();
            memoryLabel.Text = "Memory usage: " + ((float)currentProcess.PrivateMemorySize64 / 1024f / 1024f).ToString("F1") + "MB";

            _isLineFinished = true;
            _isBtnFillClicked = false;
            _isFigureCreated = false;
            _isFirstPointAdd = false;
            // Антон ещё меняет
            //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //DoubleBuffered = true;

            // Set the value of the double-buffering style bits to true.
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

                if (settings.Mode == EFigure.SmoothCurve)
                {
                    _isLineFinished = false;
                }

                if (!_isLineFinished && _isFirstPointAdd)
                {
                    drawingEngine.AddPointToCurve(mouseHandler.GetClick());
                }
                else if (!_isLineFinished && !_isFirstPointAdd)
                {
                    _isFirstPointAdd = true;
                }

                if (settings.Mode == EFigure.Dot)
                {
                    _isFigureCreated = true;

                    drawingEngine.DrawNewFigure();
                }
                else if (settings.Mode == EFigure.Move)
                {
                    drawingEngine.SelectFigure();
                }

                PictureBoxPaint.Image = drawingEngine.MainImage;
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
                if (settings.Mode != EFigure.Dot && settings.Mode != EFigure.Move)
                {
                    mouseHandler.NewMove(e.Location);
                }

                if (settings.Mode != EFigure.Move)
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

                PictureBoxPaint.Image = drawingEngine.MainImage;

                if (settings.Mode == EFigure.Move)
                {
                    mouseHandler.NewMove(e.Location);

                    drawingEngine.MoveFigure();

                    PictureBoxPaint.Image = drawingEngine.MainImage;
                }
            }
            else if (settings.Mode == EFigure.SmoothCurve && !_isLineFinished)
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

                PictureBoxPaint.Image = drawingEngine.MainImage;
            }
        }

        private void PictureBoxPaint_MouseUp(object sender, MouseEventArgs e)
        {
            if (settings.Mode != EFigure.SmoothCurve)
            {
                _isFigureCreated = false;
                drawingEngine.CleanBackground();
            }

            currentProcess.Refresh();
            memoryLabel.Text = "Memory usage: " + ((float)currentProcess.PrivateMemorySize64 / 1024f / 1024f).ToString("F1") + " MB";

            FiguresListBox.Items.Clear();
            FiguresListBox.Items.AddRange(drawingEngine.GetFigureList());

        }

        private void MenuCreate_Click(object sender, EventArgs e) //очищать лист при вызове метода
        {
            CreateNewCanvas createNewCanvas = (CreateNewCanvas)Application.OpenForms["CreateNewCanvas"];
            if (createNewCanvas == null)
            {
                if (BtnMove.Enabled)
                {
                    settings.SetMode(EFigure.Curve);
                }
                createNewCanvas = new CreateNewCanvas();
                createNewCanvas.Show();
            }
            else
            {
                createNewCanvas.Activate();
            }
        }

        private void MenuSave_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = "newUnicorn";
            saveFileDialog.Filter = "storege.json|*.json";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream("storege.json", FileMode.OpenOrCreate))
                {
                    string json = JsonSerializer.Serialize<IStorage>(storage);
                    JsonSerializer.SerializeAsync<IStorage>(fs, storage);
                    
                }
            }
            //saveFileDialog.FileName = "newUnicorn";
            //saveFileDialog.Filter = "JPG Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|PNG Image|*.png|storege";

            //if (saveFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    if (PictureBoxPaint != null)
            //    {
            //        PictureBoxPaint.Image.Save(saveFileDialog.FileName);

                    
            //    }
            //}
        }

        private void MenuOpen_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "storege.json";
            using (FileStream fs = new FileStream("storege.json", FileMode.OpenOrCreate))
            {
                JsonSerializer.DeserializeAsync<IStorage>(fs);

            }

            //openFileDialog.InitialDirectory = "c:\\";
            //openFileDialog.Filter = "JPG Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|PNG Image|*.png|storege Json|*.json|All|*.*";

            //openFileDialog.RestoreDirectory = true;

            //if (openFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    drawingEngine.Canvas = (Bitmap)Image.FromFile(openFileDialog.FileName);

            //    settings.SetImageWidth(Image.FromFile(openFileDialog.FileName).Width);
            //    settings.SetImageHeight(Image.FromFile(openFileDialog.FileName).Height);

            //    drawingEngine.DrawAllFigures();
            //    PictureBoxPaint.Image = drawingEngine.MainImage;

           // }
        }

        private void MenuClear_Click(object sender, EventArgs e)
        {
            drawingEngine.ClearStorage();
            drawingEngine.ClearCanvas();
            PictureBoxPaint.Image = drawingEngine.MainImage;
            FiguresListBox.Items.Clear();
            FiguresListBox.Items.AddRange(drawingEngine.GetFigureList());
            settings.SetMode(SettingsConstants.DefaultMode);
        }

        private void TrackBarThickness_Scroll(object sender, EventArgs e)
        {
            settings.SetPenWidth(TrackBarThickness.Value);
            PictureBoxThickness.Image = drawingEngine.GetPenImage();
        }

        private void BtnFill_Click(object sender, EventArgs e)
        {
            _isBtnFillClicked = true;
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            
            //DrawingEngine.Undo();
            //PictureBoxPaint.Image = DrawingEngine.MainImage;
        }

        private void BtnRedo_Click(object sender, EventArgs e)
        {
            //DrawingEngine.Redo();
            //PictureBoxPaint.Image = DrawingEngine.MainImage;
        }

        private void BtnPoint_Click(object sender, EventArgs e)
        {
            settings.SetMode(EFigure.Dot);
        }

        private void BtnRectangle_Click(object sender, EventArgs e)
        {
            settings.SetMode(EFigure.Rectangle);
        }

        private void BtnEllipse_Click(object sender, EventArgs e)
        {
            settings.SetMode(EFigure.Ellipse);
        }

        private void BtnCurve_Click(object sender, EventArgs e)
        {
            settings.SetMode(EFigure.Curve); 
        }

        private void BtnTriangle_Click(object sender, EventArgs e)
        {
            settings.SetMode(EFigure.Triangle);
        }

        private void BtnLine_Click(object sender, EventArgs e)
        {
            settings.SetMode(EFigure.Line);
        }

        private void SmoothCorve(object sender, EventArgs e)
        {
            settings.SetMode(EFigure.SmoothCurve);
        }

        private void BtnSguare_Click(object sender, EventArgs e)
        {
            settings.SetMode(EFigure.RoundedRectangle);
        }

        private void CheckBoxAntiAliasing_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxAntiAliasing.Checked)
            {
                settings.SetSmoothingMode(SmoothingMode.AntiAlias);
            }
            else
            {
                settings.SetSmoothingMode(SmoothingMode.None);
            }
            PictureBoxThickness.Image = drawingEngine.GetPenImage();
        }

        private void ComboBoxContour_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ComboBoxContour.SelectedIndex)
            {
                case 0:
                    settings.Pen.DashStyle = DashStyle.Solid;
                    break;
                case 1:
                    settings.Pen.DashStyle = DashStyle.Dash;
                    break;
                case 2:
                    settings.Pen.DashStyle = DashStyle.DashDot;
                    break;
                default:
                    break;
            }
        }

        private void Color_btn(object sender, EventArgs e)
        {
            if (_isBtnFillClicked)
            {
                settings.SetBrushColor(((Button)sender).BackColor);
                
                _isBtnFillClicked = false;
            }
            else
            {
                
                settings.SetPenColor(((Button)sender).BackColor);
                PictureBoxColorFillFigure.BackColor = ((Button)sender).BackColor;
                PictureBoxThickness.Image = drawingEngine.GetPenImage();
            }
        }

        private void PictureBoxColors_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                settings.SetBrushColor(colorDialog1.Color);
                settings.SetPenColor(colorDialog1.Color);
                PictureBoxColorFillFigure.BackColor = colorDialog1.Color;
                PictureBoxThickness.Image = drawingEngine.GetPenImage();
            }
        }

        private void FiguresListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            drawingEngine.SetSelectedFigure((sender as ListBox).SelectedIndex);
        }

        private void BtnMove_Click(object sender, EventArgs e)
        {
            settings.SetMode(EFigure.Move);
        }

        private void MainPaint_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (PictureBoxPaint.Image != null)
            {
                var result = MessageBox.Show("Save your changes before exiting?", "Attention", MessageBoxButtons.YesNoCancel);
                switch (result)
                {
                    case DialogResult.No: break;
                    case DialogResult.Yes: MenuSave_Click(sender, e); break;
                    case DialogResult.Cancel: return;
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            drawingEngine.DeleteFigure();
            FiguresListBox.Items.Clear();
            FiguresListBox.Items.AddRange(drawingEngine.GetFigureList());
            PictureBoxPaint.Image = drawingEngine.MainImage;
        }

        private void NumericUpDownPolygon_Click(object sender, EventArgs e)
        {
            settings.SetNumberOfPolygonApexes((int)(sender as NumericUpDown).Value);
        }

        private void BtnHexagon_Click(object sender, EventArgs e)
        {
            settings.SetMode(EFigure.Polygon);
        }

        private void BtnTransparent_Click(object sender, EventArgs e)
        {
            PictureBoxColorFillFigure.BackColor = Color.Transparent;
            PictureBoxThickness.Image = drawingEngine.GetPenImage();
        }
    }
}