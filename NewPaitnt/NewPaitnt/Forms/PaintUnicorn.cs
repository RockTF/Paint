using NewPaitnt.Implementation;
using NewPaitnt.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewPaitnt
{
    public partial class MainPaint : Form
    {
        Process currentProcess;
        bool IsBtnFillClicked;
        public EFigure Mode;
        public SmoothingMode SmoothingMode;
        public Pen Pen;

        public MainPaint()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        private void MainPaint_Load(object sender, EventArgs e)
        {
            //settings = Settings.Initialize();
            //mouseHandeler = MouseHandeler.Initialize();
            //// Прокидываем предыдущие через конструктор явно
            //drawingEngine = DrawingEngine.Initialize(settings, mouseHandeler);
            //// Костыль чтобы не было переполнения стека
            //mouseHandeler.SetDrawingEngine(drawingEngine);
            //penPreview = PenPreview.Initialize(settings, pictureBoxPen.Width, pictureBoxPen.Height);

            //pictureBoxPen.Image = penPreview.PenBitmap;
            //pictureBoxPaint.Image = drawingEngine.MainImage;

            //currentProcess = Process.GetCurrentProcess();
            //currentProcess.Refresh();
            //memoryLabel.Text = "Memory usage: " + ((float)currentProcess.PrivateMemorySize64 / 1024f / 1024f).ToString("F1") + " MB";

            //IsBtnFillClicked = false;


            // Антон ещё меняет
            //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //DoubleBuffered = true;

            //// Set the value of the double-buffering style bits to true.
            //this.SetStyle(ControlStyles.DoubleBuffer |
            //   ControlStyles.UserPaint |
            //   ControlStyles.AllPaintingInWmPaint,
            //   true);
            //this.UpdateStyles();
        }

        private void PictureBoxPaint_MouseDown(object sender, MouseEventArgs e)
        {
            //mouseHandeler.MouseDown(sender, e);
            //pictureBoxPaint.Image = drawingEngine.MainImage;
        }

        private void PictureBoxPaint_MouseMove(object sender, MouseEventArgs e)
        {
            //mouseHandeler.MouseMove(sender, e);
            //pictureBoxPaint.Image = drawingEngine.MainImage;
        }

        private void PictureBoxPaint_MouseUp(object sender, MouseEventArgs e)
        {
            //currentProcess.Refresh();
            //memoryLabel.Text = "Memory usage: " + ((float)currentProcess.PrivateMemorySize64 / 1024f / 1024f).ToString("F1") + " MB";
            //mouseHandeler.MouseUp(sender, e);
            //pictureBoxPaint.Image = drawingEngine.MainImage;
        }


        // кнопок и методов нет - оставила для Наташи
        /*private void btnSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "JPG(*.JPG)|*.jpg";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (pictureBoxPaint != null)
                {
                    pictureBoxPaint.Image.Save(saveFileDialog1.FileName);
                }
            }
        }*/

        /*private void btnClear_Click(object sender, EventArgs e)
        {
            DrawingEngine.ClearCanvas();
            pictureBoxPaint.Image = DrawingEngine.MainImage;
        }*/


        private void TrackBarThickness_Scroll(object sender, EventArgs e)
        {
            //Settings.Pen.Width = TrackBarThickness.Value;
            PenPreview.Refresh();
            PictureBoxThickness.Image = PenPreview.PenBitmap;
        }

        // кнопки цвет больше нет, метод надо менять 
        //private void BtnColor_Click(object sender, EventArgs e)
        //{
        //    if (colorDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        Settings.Pen.Color = colorDialog1.Color;
        //        btnColor.BackColor = colorDialog1.Color;
        //        PenPreview.Refresh();
        //        pictureBoxPen.Image = PenPreview.PenBitmap;
        //    }
        //}

        //private void BtnColor_Click_1(object sender, EventArgs e)
        //{
        //    if (IsBtnFillClicked)
        //    {

        //        Settings.Brush = new SolidBrush(((Button)sender).BackColor);
        //        btnColor.BackColor = ((Button)sender).BackColor;
        //        IsBtnFillClicked = false;
        //    }
        //    else
        //    {
        //        Settings.Pen.Color = ((Button)sender).BackColor;
        //        PenPreview.Refresh();
        //        pictureBoxPen.Image = PenPreview.PenBitmap;
        //    }

        //}

        private void BtnRectangle_Click(object sender, EventArgs e)
        {
            Mode = EFigure.Curve; 
        }

        private void BtnEllipse_Click(object sender, EventArgs e)
        {
           Mode = EFigure.Ellipse;
        }

        private void BtnFill_Click(object sender, EventArgs e)
        {
            IsBtnFillClicked = true;
        }

        private void BtnPoint_Click(object sender, EventArgs e)
        {
            Mode = EFigure.Dot;
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

        private void BtnCurve_Click(object sender, EventArgs e)
        {
            Mode = EFigure.Curve;
        }

        private void BtnTriangle_Click(object sender, EventArgs e)
        {
            Mode = EFigure.Triangle;
        }

        private void BtnLine_Click(object sender, EventArgs e)
        {
            Mode = EFigure.Line;
        }

        private void SmoothCorve(object sender, EventArgs e)
        {
            Mode = EFigure.SmoothCorv;
        }

        private void CheckBoxAntiAliasing_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxAntiAliasing.Checked)
            {
               SmoothingMode = SmoothingMode.AntiAlias;
            }
            else
            {
               SmoothingMode = SmoothingMode.None;
            }
            PenPreview.Refresh();
            PictureBoxThickness.Image = PenPreview.PenBitmap;
        }

        private void ComboBoxContour_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ComboBoxContour.SelectedIndex)
            {
                case 0:
                    Pen.DashStyle = DashStyle.Solid;
                    break;
                case 1:
                    Pen.DashStyle = DashStyle.Dash;
                    break;
                case 2:
                    Pen.DashStyle = DashStyle.DashDot;
                    break;
                default:
                    break;
            }
        }

        private void PictureBoxPaint_Click(object sender, EventArgs e)
        {

        }
    }
}