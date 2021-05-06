using NewPaitnt.Implementation;
using NewPaitnt.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewPaitnt
{
    public partial class mainPaint : Form
    {
      

        public mainPaint()
        {
            InitializeComponent();
        }

        private void mainPaint_Load(object sender, EventArgs e)
        {
            Settings.Init1ialize();
            DrawingEngine.Initialize();
            pictureBoxPaint.Image = DrawingEngine.MainImage;
        }

        private void pictureBoxPaint_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Копирование текущего изображения во временное
                DrawingEngine.MainImageToTemporary();
                // Передача координат клика в класс DrawingEngine
                DrawingEngine.Xclick = e.X;
                DrawingEngine.Yclick = e.Y;
            }
        }

        private void pictureBoxPaint_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
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
        }

        private void btnCollor_Click(object sender, EventArgs e)
        {
            Settings.Pen.Color= ((Button)sender).BackColor;
        }

        private void btnOther_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Settings.Pen.Color = colorDialog1.Color;
                ((Button)sender).BackColor = colorDialog1.Color;
            }
        }

        private void pictureBoxPaint_MouseUp(object sender, MouseEventArgs e)
        {
            DrawingEngine.Points.ResetPoints();
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            Settings.Mode = "Rectangle";
        }

        private void btnEllipse_Click(object sender, EventArgs e)
        {
            Settings.Mode = "Ellipse";
        }

        private void btnFill_Click(object sender, EventArgs e)
        {

        }
    }
}
