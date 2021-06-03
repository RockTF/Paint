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
    public class Polygon : Figure
    {
        private static int _count = 0;
        private int _numberOfApex;
        private double _angularStep;
        private Point _center;
        private List<Point> _aroundCenterPoints;
        public Polygon(Point click, Point move, int numberOfApex, Pen pen, Brush brush, SmoothingMode smoothingMode)
        {
            _numberOfApex = numberOfApex;
            Points = new List<Point>(_numberOfApex);
            _aroundCenterPoints = new List<Point>(_numberOfApex);
            for (int i = 0; i < _numberOfApex; i++)
            {
                Points.Add(new Point(0, 0));
                _aroundCenterPoints.Add(new Point(0, 0));
            }
            _angularStep = 2.0 * Math.PI / _numberOfApex;

            Pen = (Pen)pen.Clone();
            Brush = (Brush)brush.Clone();
            SmoothingMode = smoothingMode;

            _center = click;
            RecalculateCoordinates(move);

            FigureName = "Polygon" + _count++.ToString();
        }
        public override void Draw(ref Graphics graphics)
        {
            graphics.SmoothingMode = SmoothingMode;
            graphics.FillPolygon(Brush, Points.ToArray());
            graphics.DrawPolygon(Pen, Points.ToArray());
        }

        public override void Draw(ref Graphics graphics, Point move)
        {
            RecalculateCoordinates(move);
            graphics.SmoothingMode = SmoothingMode;
            graphics.FillPolygon(Brush, Points.ToArray());
            graphics.DrawPolygon(Pen, Points.ToArray());
        }

        public override void Refresh(ref Graphics graphics)
        {
            throw new NotImplementedException();
        }

        private void RecalculateCoordinates(Point move)
        {
            Points[0] = move;
            _aroundCenterPoints[0] = new Point(move.X - _center.X, move.Y - _center.Y);
            for (int i = 1; i < _numberOfApex; i++)
            {
                int tempX = (int)((double)_aroundCenterPoints[0].X * Math.Cos((double)i * _angularStep) - (double)_aroundCenterPoints[0].Y * Math.Sin((double)i * _angularStep));
                int tempY = (int)((double)_aroundCenterPoints[0].X * Math.Sin((double)i * _angularStep) + (double)_aroundCenterPoints[0].Y * Math.Cos((double)i * _angularStep));
                _aroundCenterPoints[i] = new Point(tempX, tempY);
                Points[i] = new Point(tempX + _center.X, tempY + _center.Y);
            }
        }
    }
}
