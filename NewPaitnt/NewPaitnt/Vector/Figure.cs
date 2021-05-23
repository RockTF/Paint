using NewPaitnt.Implementation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPaitnt.Vector
{
    abstract class Figure : IDrawable, IFillable, ITransformable
    {
        public List<Point> initialPoints;
        public List<Point> visiblePoints;
        public List<Point> aroundCenterPoints;
        public Point center;
        public Pen pen;
        public Brush brush;
        public bool isSelected;
        private MouseHandeler mouseHandeler;
        private Settings settings;

        public abstract void Draw(ref Graphics graphics);
        public abstract void Refresh(ref Graphics graphics);
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

        public void Scale(float scaleFactor)
        {
            for (int i = 0; i < initialPoints.Count; i++)
            {
                int tempX = (int)((float)aroundCenterPoints[i].X * scaleFactor) + center.X;
                int tempY = (int)((float)aroundCenterPoints[i].Y * scaleFactor) + center.Y;
                visiblePoints[i] = new Point(tempX, tempY);
            }
        }

        public void Rotate(double rotationAngle)
        {
            for (int i = 0; i < initialPoints.Count; i++)
            {
                int tempX = (int)((double)aroundCenterPoints[i].X * Math.Cos(rotationAngle) - (double)aroundCenterPoints[i].Y * Math.Sin(rotationAngle)) + center.X;
                int tempY = (int)((double)aroundCenterPoints[i].X * Math.Sin(rotationAngle) + (double)aroundCenterPoints[i].Y * Math.Cos(rotationAngle)) + center.Y;
                
                visiblePoints[i] = new Point(tempX, tempY);
            }
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

        public void RefreshPen()
        {
            pen = (Pen)settings.Pen.Clone();
        }

        public void RefreshBrush()
        {
            brush = (Brush)settings.Brush.Clone();
        }
    }
}
