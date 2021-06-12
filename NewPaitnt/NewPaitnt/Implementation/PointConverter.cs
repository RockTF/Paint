using NewPaitnt.VectorModel;
using System.Collections.Generic;
using System.Drawing;

namespace NewPaitnt.Implementation
{
    public static class PointConverter
    {
        public static Point2D SystemToCustom(Point point)
        {
            return new Point2D(point.X, point.Y);
        }
        public static Point CustomToSystem(Point2D point)
        {
            return new Point(point.X, point.Y);
        }
        public static Point[] CustomToSystem(List<Point2D> points)
        {
            Point[] systemPoints = new Point[points.Count];
            for (int i = 0; i < points.Count; i++)
            {
                systemPoints[i] = new Point(points[i].X, points[i].Y);
            }
            return systemPoints;
        }
    }
}
