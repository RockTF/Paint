using NewPaitnt.Enum;
using NewPaitnt.VectorModel;
using System.Collections.Generic;

namespace NewPaitnt.VectorModel
{
    public class Line : Figure
    {
        private static int _count = 0;
        public Line(Point2D click, Point2D move, string penColor, float penWidth, EDashStyle penDashStyle, string brushColor, bool isSmoothed)
        {
            FigureType = EFigure.Line;
            Points = new List<Point2D>(2);
            Points.Add(click);
            Points.Add(move);
            Update(penColor, penWidth, penDashStyle, brushColor, isSmoothed);
            FigureName = FigureType.ToString() + _count++.ToString();
        }
    }
}
