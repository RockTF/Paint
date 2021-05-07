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
    public partial class mainPaint : Form
    {
        Process currentProcess;
        bool IsBtnFillClicked;
        public mainPaint()
        {
            InitializeComponent();
        }

        private void mainPaint_Load(object sender, EventArgs e)
        {
            Settings.Init1ialize();
            DrawingEngine.Initialize();
            PenPreview.Initialize(pictureBoxPen.Width, pictureBoxPen.Height);
            pictureBoxPen.Image = PenPreview.PenBitmap;
            pictureBoxPaint.Image = DrawingEngine.MainImage;

            currentProcess = Process.GetCurrentProcess();
            currentProcess.Refresh();
            memoryLabel.Text = "Memory usage: " + ((float)currentProcess.PrivateMemorySize64 / 1024f /1024f).ToString("F1") + " MB";

            IsBtnFillClicked = false;
        }

        private void pictureBoxPaint_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DrawingEngine.ClearUnnecessaryHistory();
                // Копирование текущего изображения во временное
                DrawingEngine.MainImageToTemporary();
                // Передача координат клика в класс DrawingEngine
                DrawingEngine.Xclick = e.X;
                DrawingEngine.Yclick = e.Y;

                if (Settings.Mode == "point")
                {
                    DrawingEngine.Draw();
                    pictureBoxPaint.Image = DrawingEngine.MainImage;
                }
            }
        }

        private void pictureBoxPaint_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && Settings.Mode != "point")
            {
                DrawingEngine.Xmove = e.X;
                DrawingEngine.Ymove = e.Y;
                
                // Расчет координат для отрисовки фигуры
                DrawingEngine.CalculateCoordinates(e.X, e.Y);
                // Вызов общего метода рисования
                DrawingEngine.Draw();
                // Обновление основного изображения в PictureBox
                pictureBoxPaint.Image = DrawingEngine.MainImage;
            }
        }

        private void Triangle_Click(object sender, EventArgs e) // Треугольник
        {

        }

        private void CurvedLine_Click(object sender, EventArgs e) // Кривая линия
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "JPG(*.JPG)|*.jpg";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (pictureBoxPaint != null)
                {
                    pictureBoxPaint.Image.Save(saveFileDialog1.FileName);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DrawingEngine.ClearCanvas();
            pictureBoxPaint.Image = DrawingEngine.MainImage;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DrawingEngine.Undo();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Settings.Pen.Width = trackBar1.Value;
            PenPreview.Refresh();
            pictureBoxPen.Image = PenPreview.PenBitmap;
        }

        private void btnCollor_Click(object sender, EventArgs e)
        {
            if (IsBtnFillClicked)
            {
                Settings.Brush = new SolidBrush(((Button)sender).BackColor);
                IsBtnFillClicked = false;
            }
            else
            {
                Settings.Pen.Color = ((Button)sender).BackColor;
                PenPreview.Refresh();
                pictureBoxPen.Image = PenPreview.PenBitmap;
            }
        }

        private void btnOther_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Settings.Pen.Color = colorDialog1.Color;
                ((Button)sender).BackColor = colorDialog1.Color;
                PenPreview.Refresh();
                pictureBoxPen.Image = PenPreview.PenBitmap;
            }
        }

        private void pictureBoxPaint_MouseUp(object sender, MouseEventArgs e)
        {
            DrawingEngine.Points.ResetPoints(); // Метод Наташи
            DrawingEngine.SaveToHistory();
            DrawingEngine.CurvePoints = new List<Point>(); //Мой вариант

            // Приводим в порядок память
            GC.Collect();
            GC.WaitForPendingFinalizers();
            currentProcess.Refresh();
            memoryLabel.Text = "Memory usage: " + ((float)currentProcess.PrivateMemorySize64 / 1024f / 1024f).ToString("F1") + " MB";
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            Settings.Mode = "rectangle";
        }

        private void btnEllipse_Click(object sender, EventArgs e)
        {
            Settings.Mode = "ellipse";
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            IsBtnFillClicked = true;
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            Settings.Mode = "point";
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            DrawingEngine.Undo();
            pictureBoxPaint.Image = DrawingEngine.MainImage;
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            DrawingEngine.Redo();
            pictureBoxPaint.Image = DrawingEngine.MainImage;
        }

        private void btnCurve_Click(object sender, EventArgs e)
        {
            Settings.Mode = "curve";
        }

        private void comboBoxContour_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxContour.SelectedIndex)
            {
                case 0:
                    Settings.Pen.DashStyle = DashStyle.Solid;
                    break;
                case 1:
                    Settings.Pen.DashStyle = DashStyle.Dash;
                    break;
                case 2:
                    Settings.Pen.DashStyle = DashStyle.DashDot;
                    break;
                default:
                    break;
            }
        }

        private void checkBoxAntiAliasing_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                Settings.SmoothingMode = SmoothingMode.AntiAlias;
            }
            else
            {
                Settings.SmoothingMode = SmoothingMode.None;
            }
            PenPreview.Refresh();
            pictureBoxPen.Image = PenPreview.PenBitmap;
        }
    }
}
