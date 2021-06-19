using NewPaitnt.Enum;
using NewPaitnt.Implementation;
using System.Collections.Generic;

namespace NewPaitnt.VectorModel
{
    public class Rectangle : Figure
    {
        private static int _count = 0;
        public Rectangle(Point2D click, Point2D move, Settings settings) : base(settings)
        {
            FigureType = EFigure.Rectangle;
            Points = new List<Point2D>(2);
            Points.Add(click);
            Points.Add(move);
            FigureName = FigureType.ToString() + _count++.ToString();
        }

        public void ResetCounter()
        {
            _count = 0;
        }
    }
}
