using NewPaitnt.Enum;
using NewPaitnt.Interfaces;
using System.Collections.Generic;

namespace NewPaitnt.VectorModel
{
    public class Dot : IDrawable
    {
        public EFigure FigureType { get; }
        public string FigureName { get; private set; }
        public List<Point2D> Points { get; private set; }
        public string PenColor { get; private set; }
        public float PenWidth { get; private set; }
        public EDashStyle PenDashStyle { get; private set; }
        public string BrushColor { get; private set; }
        public bool IsSmoothed { get; private set; }

        private static int _count = 0;

        public Dot(Point2D click, string penColor, float penWidth, bool isSmoothed)
        {
            FigureType = EFigure.Dot;
            Points = new List<Point2D>(2);
            Points.Add(click);
            Points.Add(new Point2D(click.X + 1, click.Y + 1));
            PenColor = penColor;
            PenWidth = penWidth;
            PenDashStyle = EDashStyle.Solid;
            BrushColor = "#00000000";

            FigureName = FigureType.ToString() + _count++.ToString();

            IsSmoothed = isSmoothed;
        }

        public void Move(Point2D from, Point2D to)
        {
            for (int i = 0; i < Points.Count; i++)
            {
                int tempX = Points[i].X + (to.X - from.X);
                int tempY = Points[i].Y + (to.Y - from.Y);
                Points[i].Cnahge(tempX, tempY);
            }
        }

        public void UpdatePoint(Point2D point)
        {
            throw new System.NotImplementedException();
        }

        public void Update(string penColor, float penWidth, EDashStyle penDashStyle, string brushColor, bool isSmoothed)
        {
            PenColor = penColor;
            PenWidth = penWidth;
            IsSmoothed = isSmoothed;
        }
    }
}
