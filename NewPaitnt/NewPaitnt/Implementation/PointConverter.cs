using NewPaitnt.VectorModel;
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
    }
}
