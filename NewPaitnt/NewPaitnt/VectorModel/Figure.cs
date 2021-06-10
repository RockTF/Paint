using NewPaitnt.Enum;
using NewPaitnt.Interfaces;
using System.Collections.Generic;

namespace NewPaitnt.VectorModel
{
    public abstract class Figure : IDrawable 
    {
        public EFigure FigureType { get; protected set; }
        public string FigureName { get; protected set; }
        public List<Point2D> Points { get; protected set; }
        public string PenColor { get; protected set; }
        public float PenWidth { get; protected set; }
        public EDashStyle PenDashStyle { get; protected set; }
        public string BrushColor { get; protected set; }
        public bool IsSmoothed { get; protected set; }

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
            Points[^1].Cnahge(point.X, point.Y);
        }

        public void Update(string penColor, float penWidth, EDashStyle penDashStyle, string brushColor, bool isSmoothed)
        {
            PenColor = penColor;
            PenWidth = penWidth;
            PenDashStyle = penDashStyle;
            BrushColor = brushColor;
            IsSmoothed = isSmoothed;
        }
    }
}
