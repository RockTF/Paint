using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPaitnt.Vector
{
    abstract class Figure
    {
        private List<Point> _initialPoints { get; set; }
        private List<Point> _visiblePoints { get; set; }
        private Point _center { get; set; }
        public Pen pen { get; set; }
        public Brush brush { get; set; }
        private bool isSelected { get; set; }

        public abstract void Draw();
        public void Move(Point from, Point to)
        {
            for (int i = 0; i < _initialPoints.Count; i++)
            {
                int tempX = _initialPoints[i].X + (to.X - from.X);
                int tempY = _initialPoints[i].Y + (to.Y - from.Y);
                _visiblePoints[i] = new Point(tempX, tempY);
            }
        }
        public void Move(int distanceX, int distanceY)
        {
            for (int i = 0; i < _initialPoints.Count; i++)
            {
                int tempX = _initialPoints[i].X + distanceX;
                int tempY = _initialPoints[i].Y + distanceY;
                _visiblePoints[i] = new Point(tempX, tempY);
            }
        }

        public abstract void Refresh();

        public void Rotate()
        {
            
        }

        public void Sckale()
        {
         
        }
    }
}
