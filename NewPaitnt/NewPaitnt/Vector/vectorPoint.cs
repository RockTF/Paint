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
        public List<Point> initialPoints;
        public List<Point> visiblePoints;
        public Pen pen;
        public bool isSelected;
        private MouseHandeler _mouseHandeler;
        private Settings _settings;

        public vectorPoint()
        {
            _mouseHandeler = MouseHandeler.Initialize();
            _settings = Settings.Initialize();
            initialPoints.Add(_mouseHandeler.Click);
            initialPoints.Add(new Point(_mouseHandeler.Click.X, _mouseHandeler.Click.Y));
            visiblePoints = new List<Point>(initialPoints);
            pen = (Pen)_settings.Pen.Clone();
            pen.DashPattern = new float[] { 1f, 1f };
        }
        public void Draw(ref Graphics graphics)
        {
            graphics.DrawLine(pen, visiblePoints[0], visiblePoints[1]);
        }
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
        public void RefreshPen()
        {
            pen = (Pen)_settings.Pen.Clone();
            pen.DashPattern = new float[] { 1f, 1f };
        }
        public void Selest()
        {
            isSelected = true;
        }
        public void Deselect()
        {
            initialPoints = visiblePoints;
            isSelected = false;
        }
    }
}
