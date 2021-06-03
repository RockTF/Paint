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
        public SmoothCurve(Point click, Point move, Pen pen, SmoothingMode smoothingMode)
        {
            Points = new List<Point>();

            Points.Add(click);
            Points.Add(move);

            Pen = (Pen)pen.Clone();

            FigureName = "SmoothCurve" + _count++.ToString();

            SmoothingMode = smoothingMode;

            //if (AddNextPoint)
            //{
            //   Points.Add(new Point(move.X, move.Y));
            //}
            //else
            //{
            //   Points[Points.Count - 1] = new Point(move.X,move.Y);
            //}

            //if (IsLineFinished)
            //{
            //    Points.Add(new Point(end.X, end.Y));
            //}





        }
        public override void Draw(ref Graphics graphics)
        {
            graphics.DrawCurve(Pen, Points.ToArray());

        }

        public override void Draw(ref Graphics graphics, Point end)
        {
            Points[Points.Count - 1] = end;
            graphics.DrawCurve(Pen, Points.ToArray());
        }

        public override void Refresh(ref Graphics graphics)
        {
            throw new NotImplementedException();
        }
    }


}
