using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace NewPaitnt.VectorModel
{
    public class Ellipse : Figure
    {
        private static int _count = 0;
        public Ellipse(Point start, Point end, Pen pen, Brush brush, SmoothingMode smoothingMode)
        {
            Points = new List<Point>(2);

            Points.Add(start);
            Points.Add(end);

            Pen = (Pen)pen.Clone();
            Brush = (Brush)brush.Clone();
            SmoothingMode = smoothingMode;

            FigureName = "Ellipse" + _count++.ToString();
        }

        public override void Draw(ref Graphics graphics)
        {
            int Xstart = (Points[0].X < Points[1].X) ? Points[0].X : Points[1].X;
            int Xend = (Points[0].X < Points[1].X) ? Points[1].X : Points[0].X;
            int Ystart = (Points[0].Y < Points[1].Y) ? Points[0].Y : Points[1].Y;
            int Yend = (Points[0].Y < Points[1].Y) ? Points[1].Y : Points[0].Y;

            graphics.SmoothingMode = SmoothingMode;
            graphics.FillEllipse(Brush, Xstart, Ystart, Xend - Xstart, Yend - Ystart);
            graphics.DrawEllipse(Pen, Xstart, Ystart, Xend - Xstart, Yend - Ystart);
            
        }

        public override void Draw(ref Graphics graphics, Point end)
        {
            Points[1] = end;

            int Xstart = (Points[0].X < Points[1].X) ? Points[0].X : Points[1].X;
            int Xend = (Points[0].X < Points[1].X) ? Points[1].X : Points[0].X;
            int Ystart = (Points[0].Y < Points[1].Y) ? Points[0].Y : Points[1].Y;
            int Yend = (Points[0].Y < Points[1].Y) ? Points[1].Y : Points[0].Y;

            graphics.SmoothingMode = SmoothingMode;
            graphics.FillEllipse(Brush, Xstart, Ystart, Xend - Xstart, Yend - Ystart);
            graphics.DrawEllipse(Pen, Xstart, Ystart, Xend - Xstart, Yend - Ystart);
        }

        public override void Refresh(ref Graphics graphics)
        {
            throw new NotImplementedException();
        }
    }
}
