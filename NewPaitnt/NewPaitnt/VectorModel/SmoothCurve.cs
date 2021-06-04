using NewPaitnt.VectorModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace NewPaitnt.Vector
{
    public class SmoothCurve : Figure
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
    }


}
