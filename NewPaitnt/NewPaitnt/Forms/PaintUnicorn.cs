using NewPaitnt.Implementation;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace NewPaitnt
{
    public partial class MainPaint : Form
    {
        Process currentProcess;
        bool IsBtnFillClicked;
        DrawingEngine drawingEngine;

        public MainPaint()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        private void MainPaint_Load(object sender, EventArgs e)
        {
            drawingEngine = DrawingEngine.Initialize(PictureBoxThickness.Width, PictureBoxThickness.Height);

            PictureBoxThickness.Image = drawingEngine.GetPenImage();
            PictureBoxPaint.Image = drawingEngine.MainImage;

            currentProcess = Process.GetCurrentProcess();
            currentProcess.Refresh();
            memoryLabel.Text = "Memory usage: " + ((float)currentProcess.PrivateMemorySize64 / 1024f / 1024f).ToString("F1") + " MB";

            IsBtnFillClicked = false;


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
            if (e.Button == MouseButtons.Left)
            {
                drawingEngine.NewClick(e.Location);
                drawingEngine.CreateFigure();
                drawingEngine.DrawAllFigures();
                PictureBoxPaint.Image = drawingEngine.MainImage;
            }
        }

        private void PictureBoxPaint_MouseMove(object sender, MouseEventArgs e)
        {
            //PictureBoxPaint.Image = drawingEngine.MainImage;
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
            drawingEngine.SetPenWidth(TrackBarThickness.Value);
            PictureBoxThickness.Image = drawingEngine.GetPenImage();
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
            drawingEngine.SetMode(EFigure.Rectangle);
        }

        private void BtnEllipse_Click(object sender, EventArgs e)
        {
           //Mode = EFigure.Ellipse;
        }

        private void BtnFill_Click(object sender, EventArgs e)
        {
            IsBtnFillClicked = true;
        }

        private void BtnPoint_Click(object sender, EventArgs e)
        {
            //Mode = EFigure.Dot;
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
            //Mode = EFigure.Curve;
        }

        private void BtnTriangle_Click(object sender, EventArgs e)
        {
            //Mode = EFigure.Triangle;
        }

        private void BtnLine_Click(object sender, EventArgs e)
        {
            //Mode = EFigure.Line;
        }

        private void SmoothCorve(object sender, EventArgs e)
        {
            //Mode = EFigure.SmoothCorv;
        }

        private void CheckBoxAntiAliasing_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxAntiAliasing.Checked)
            {
               drawingEngine.SetSmoothingMode(SmoothingMode.AntiAlias);
            }
            else
            {
                drawingEngine.SetSmoothingMode(SmoothingMode.None);
            }
            PictureBoxThickness.Image = drawingEngine.GetPenImage();
        }

        private void ComboBoxContour_SelectedIndexChanged(object sender, EventArgs e)
        {
            //switch (ComboBoxContour.SelectedIndex)
            //{
            //    case 0:
            //        Pen.DashStyle = DashStyle.Solid;
            //        break;
            //    case 1:
            //        Pen.DashStyle = DashStyle.Dash;
            //        break;
            //    case 2:
            //        Pen.DashStyle = DashStyle.DashDot;
            //        break;
            //    default:
            //        break;
            //}
        }

        private void PictureBoxPaint_Click(object sender, EventArgs e)
        {

        }
    }
}