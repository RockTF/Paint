using NewPaitnt.Enum;
using NewPaitnt.Implementation;
using System;
using System.Collections.Generic;


namespace NewPaitnt.VectorModel
{
    public class Polygon : Figure
    {
        private static int _count = 0;
        private int _numberOfApex;
        private double _angularStep;
        private Point2D _center;
        private List<Point2D> _aroundCenterPoints;
        public Polygon(Point2D click, Point2D move, Settings settings) : base(settings)
        {
            _numberOfApex = settings.numberOfPolygonApexes;

            FigureType = EFigure.Polygon;
            Points = new List<Point2D>(_numberOfApex);
            FigureName = FigureType.ToString() + _count++.ToString();

            _aroundCenterPoints = new List<Point2D>(_numberOfApex);
            for (int i = 0; i < _numberOfApex; i++)
            {
                Points.Add(new Point2D(0, 0));
                _aroundCenterPoints.Add(new Point2D(0, 0));
            }
            _angularStep = 2.0 * Math.PI / _numberOfApex;

            _center = click;
            RecalculateCoordinates(move);
        }

        public override void UpdatePoint(Point2D point)
        {
            RecalculateCoordinates(point);
        }

        private void RecalculateCoordinates(Point2D move)
        {
            Points[0] = move;
            _aroundCenterPoints[0] = new Point2D(move.X - _center.X, move.Y - _center.Y);
            for (int i = 1; i < _numberOfApex; i++)
            {
                int tempX = (int)((double)_aroundCenterPoints[0].X * Math.Cos((double)i * _angularStep) - (double)_aroundCenterPoints[0].Y * Math.Sin((double)i * _angularStep));
                int tempY = (int)((double)_aroundCenterPoints[0].X * Math.Sin((double)i * _angularStep) + (double)_aroundCenterPoints[0].Y * Math.Cos((double)i * _angularStep));
                _aroundCenterPoints[i] = new Point2D(tempX, tempY);
                Points[i] = new Point2D(tempX + _center.X, tempY + _center.Y);
            }
        }
    }
}
