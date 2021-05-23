using NewPaitnt.Implementation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPaitnt.Vector
{
    class vectorPoint : IDrawable
    {
        // Исходные точки фигуры. Нужны для того, чтобы динамично изменять выделенную фигуру, не затронув исходное положение
        public List<Point> initialPoints;
        // Вычисляются на основе исходных с учетом текущих трансформаций, по ним фигура рисуется
        public List<Point> visiblePoints;
        public Pen pen;
        public bool isSelected;
        private MouseHandeler _mouseHandeler;
        private Settings _settings;

        public vectorPoint(Settings settings, MouseHandeler mouseHandeler)
        {
            _settings = settings;
            _mouseHandeler = mouseHandeler;
            // Создаем список на две точки
            initialPoints = new List<Point>(2);
            // Добавляем в него точку клика и рядом стоящую точку
            initialPoints.Add(_mouseHandeler.Click);
            initialPoints.Add(new Point(_mouseHandeler.Click.X + 1, _mouseHandeler.Click.Y + 1));
            // Копируем исходные точки в видимые
            visiblePoints = new List<Point>(initialPoints);
            // Модифицируем перо для отрисовки точки вместо линии
            pen = (Pen)_settings.Pen.Clone();
            pen.DashPattern = new float[] { 1f, 1f };
        }
        public void Draw(ref Graphics graphics)
        {
            // Вызываем рисование линии, а по скольку перо модифицировано, выглядеть будет как точка
            graphics.DrawLine(pen, visiblePoints[0], visiblePoints[1]);
        }

        // Переопределяет видимые точки на основе смещения
        public void Move(Point from, Point to)
        {
            for (int i = 0; i < initialPoints.Count; i++)
            {
                int tempX = initialPoints[i].X + (to.X - from.X);
                int tempY = initialPoints[i].Y + (to.Y - from.Y);
                visiblePoints[i] = new Point(tempX, tempY);
            }
        }
        public void Move(int distanceX, int distanceY)
        {
            for (int i = 0; i < initialPoints.Count; i++)
            {
                int tempX = initialPoints[i].X + distanceX;
                int tempY = initialPoints[i].Y + distanceY;
                visiblePoints[i] = new Point(tempX, tempY);
            }
        }

        // Меняет точке перо в соответствии с текущими настройками
        public void RefreshPen()
        {
            pen = (Pen)_settings.Pen.Clone();
            pen.DashPattern = new float[] { 1f, 1f };
        }

        // Выделяет точку
        public void Selest()
        {
            isSelected = true;
        }

        public void Deselect()
        {
            // записывает текущие видимые точки в исходные
            initialPoints = visiblePoints;
            // уберает выделение
            isSelected = false;
        }
    }
}
