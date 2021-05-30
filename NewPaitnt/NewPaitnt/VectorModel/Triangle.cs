using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;

namespace NewPaitnt.VectorModel
{
    public class Triangle:Figure
    {
        private static int _count = 0;
        public Triangle(Point start, Point end, Pen pen, SmoothingMode smoothingMode)
        {
            Points = new List<Point>(2);

            Points.Add(start);
            Points.Add(end);

            Pen = (Pen)pen.Clone();
            SmoothingMode = smoothingMode;

            FigureName = "Triangle" + _count++.ToString();
        }

        public override void Draw(ref Graphics graphics)
        {

            List<Point> TrianglePoint = new List<Point>(3);
            TrianglePoint.Add(new Point(Points[1].X, Points[1].Y));
            TrianglePoint.Add(new Point(Points[0].X, Points[1].Y));
            TrianglePoint.Add(new Point((Points[0].X + Points[1].X) / 2, Points[0].Y));

            graphics.SmoothingMode = SmoothingMode;
            graphics.DrawPolygon(Pen, TrianglePoint.ToArray());
        }
        public override void Draw(ref Graphics graphics, Point end)
        {
            Points[1] = end;

            List<Point> TrianglePoint = new List<Point>(3);
            TrianglePoint.Add(new Point(Points[1].X, Points[1].Y));
            TrianglePoint.Add(new Point(Points[0].X, Points[1].Y));
            TrianglePoint.Add(new Point((Points[0].X + Points[1].X) / 2, Points[0].Y));

            graphics.SmoothingMode = SmoothingMode;
            graphics.DrawPolygon(Pen, TrianglePoint.ToArray());
        }

        public override void Refresh(ref Graphics graphics)
        {
            throw new NotImplementedException();
        }
    }
}
