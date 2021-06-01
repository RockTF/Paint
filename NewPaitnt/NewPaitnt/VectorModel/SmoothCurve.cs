using NewPaitnt.VectorModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPaitnt.Vector
{
    class SmoothCurve : Figure
    {
        private static int _count = 0;
        public SmoothCurve(Point click, Point move, Point end, Pen pen, SmoothingMode smoothingMode, bool AddNextPoint, bool IsLineFinished)
        {
            Points = new List<Point>();

            if (Points.Count == 0)
            {
                Points.Add(new Point(click.X, click.Y));
            }

            if (AddNextPoint)
            {
               Points.Add(new Point(move.X, move.Y));
            }
            else
            {
               Points[Points.Count - 1] = new Point(move.X,move.Y);
            }

            if (IsLineFinished)
            {
                Points.Add(new Point(end.X, end.Y));
            }
            Pen = (Pen)pen.Clone();
            Pen.DashPattern = new float[] { 1f, 1f };
            Brush = new SolidBrush(Color.FromArgb(0, 0, 0, 0));

            FigureName = "SmoothCurve" + _count++.ToString();

            SmoothingMode = smoothingMode;
        }
        public override void Draw(ref Graphics graphics)
        {
            graphics.DrawCurve(Pen, Points.ToArray());
           
        }

        public override void Draw(ref Graphics graphics, Point end)
        {
            throw new NotImplementedException();
        }

        public override void Refresh(ref Graphics graphics)
        {
            throw new NotImplementedException();
        }
    }

   
}
