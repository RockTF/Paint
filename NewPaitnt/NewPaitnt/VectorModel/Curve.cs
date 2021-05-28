using NewPaitnt.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPaitnt.Vector
{
    public class Curve : IDrawable
    {
        public string FigureName { get; private set; }

        public List<Point> Points { get; set; }

        public Pen Pen { get; set; }

        public Brush Brush { get; set; }

        public SmoothingMode SmoothingMode { get; private set; }
        private static int _count = 0;

        public Curve(Point start, Point move, Pen pen, SmoothingMode smoothingMode)
        {
            Points = new List<Point>();
           if(Points.Count ==0)
            {
                Points.Add(new Point(start.X, start.Y));
            }
                       
            Points.Add(new Point(move.X, move.Y));
          

            Pen = (Pen)pen.Clone();
          
            FigureName = "Curve" + _count++.ToString();

            SmoothingMode = smoothingMode;
        }
        public void ChangePen(Pen pen)
        {
            Pen = (Pen)pen.Clone();
            Pen.DashPattern = new float[] { 1f, 1f };
           
        }

        public void Draw(ref Graphics graphics)
        {
            graphics.SmoothingMode = SmoothingMode;
            graphics.DrawCurve(Pen, Points.ToArray());
        }

        public void Draw(ref Graphics graphics, Point end)
        {

            Points.Add(new Point(end.X, end.Y));
            graphics.SmoothingMode = SmoothingMode;
            graphics.DrawCurve(Pen, Points.ToArray());
        }

        public void Move(Point from, Point to)
        {
            throw new NotImplementedException();
        }
    }
}
