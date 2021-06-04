using NewPaitnt.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPaitnt.VectorModel
{
    public abstract class Figure: IDrawable 
    {
        public List<Point> Points { get; set; }
        public  Pen  Pen { get; set; }
        public  Brush Brush { get; set; }
        public string FigureName { get; set; }
        public SmoothingMode SmoothingMode { get; set; }
        public abstract void Draw(ref Graphics graphics);


        public void Move(Point from, Point to)
        {
            for (int i = 0; i < Points.Count; i++)
            {
                int tempX = Points[i].X + (to.X - from.X);
                int tempY = Points[i].Y + (to.Y - from.Y);
                Points[i] = new Point(tempX, tempY);
            }
        }

        public void ChangePen(Pen pen)
        {
            Pen = (Pen)pen.Clone();
        }

        public abstract void Draw(ref Graphics graphics, Point end);

        public void AddNextPoint(Point click)
        {
            Points.Add(click);
        }
    }
}
