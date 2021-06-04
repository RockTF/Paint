using NewPaitnt.VectorModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace NewPaitnt.Vector
{
    public class Line : Figure
    {
        private static int _count = 0;
        public Line(Point start, Point end, Pen pen, SmoothingMode smoothingMode)
        {
            Points = new List<Point>(2);

            Points.Add(start);
            Points.Add(end);

            Pen = (Pen)pen.Clone();
            SmoothingMode = smoothingMode;

            FigureName = "Line" + _count++.ToString();
        }

        public override void Draw(ref Graphics graphics)
        { 
            graphics.SmoothingMode = SmoothingMode;
            graphics.DrawLine(Pen, Points[0], Points[1]);
        }

        public override void Draw(ref Graphics graphics, Point end)
        {
            Points[1] = end;
            graphics.SmoothingMode = SmoothingMode;
            graphics.DrawLine(Pen, Points[0], Points[1]);
        }
    }
}
