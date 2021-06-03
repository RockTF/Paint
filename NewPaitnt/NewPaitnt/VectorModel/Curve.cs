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
    public class Curve : Figure
    {
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

        public override void Draw(ref Graphics graphics)
        {
            graphics.SmoothingMode = SmoothingMode;
            graphics.DrawCurve(Pen, Points.ToArray());
        }

        public override void Draw(ref Graphics graphics, Point end)
        {

            Points.Add(new Point(end.X, end.Y));
            graphics.SmoothingMode = SmoothingMode;
            graphics.DrawCurve(Pen, Points.ToArray());
        }

        public override void Refresh(ref Graphics graphics)
        {
            throw new NotImplementedException();
        }
    }
}
