using NewPaitnt.Implementation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewPaitnt
{
    public partial class mainPaint
    {
        private void pictureBoxPaint_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DrawingEngine.ClearUnnecessaryHistory();

                if (DrawingEngine.IsLineFinished)
                {
                    // Копирование текущего изображения во временное для того, чтобы не затронуть его, пока нажата кнопка мыши
                    // и фигура динамически изменяется
                    DrawingEngine.MainImageToTemporary();
                }

                // Передача координат клика в класс DrawingEngine
                DrawingEngine.Xclick = e.X;
                DrawingEngine.Yclick = e.Y;

                if (Settings.Mode == "point")
                {
                    DrawingEngine.Draw();
                    pictureBoxPaint.Image = DrawingEngine.MainImage;
                }

                if (Settings.Mode == "smoothCorv")
                {
                    DrawingEngine.IsLineFinished = false;
                    DrawingEngine.AddNextPoint = true;
                }
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

            if (Settings.Mode == "smoothCorv" && e.Button == MouseButtons.Right && DrawingEngine.SmoothCurvePoints.Count > 0)
            {
                DrawingEngine.IsLineFinished = true;

                DrawingEngine.Xend = e.X;
                DrawingEngine.Yend = e.Y;

                DrawingEngine.Draw();
                pictureBoxPaint.Image = DrawingEngine.MainImage;
                DrawingEngine.SmoothCurvePoints = new List<Point>();
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

            if (Settings.Mode == "smoothCorv" && DrawingEngine.SmoothCurvePoints.Count > 0 && !DrawingEngine.IsLineFinished)
            {
                DrawingEngine.AddNextPoint = false;

                DrawingEngine.Xmove = e.X;
                DrawingEngine.Ymove = e.Y;

                DrawingEngine.Draw();
                pictureBoxPaint.Image = DrawingEngine.MainImage;
            }
        }
    }
}
