using NewPaitnt.Enum;
using NewPaitnt.Implementation;
using NewPaitnt.Interfaces;
using System.Collections.Generic;

namespace NewPaitnt.VectorModel
{
    public abstract class Figure : IDrawableDTO, IDrawable
    {
        public EFigure FigureType { get; protected set; }
        public string FigureName { get; protected set; }
        public List<Point2D> Points { get; protected set; }
        public string PenColor { get; protected set; }
        public float PenWidth { get; protected set; }
        public EDashStyle PenDashStyle { get; protected set; }
        public string BrushColor { get; protected set; }
        public bool IsSmoothed { get; protected set; }

        public Figure(Settings settings)
        {
            Update(settings);
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

        public virtual void UpdatePoint(Point2D point)
        {
            Points[^1].Cnahge(point.X, point.Y);
        }

        public void AddNextPoint(Point2D point)
        {
            Points.Add(point);
        }

        public void Update(Settings settings)
        {
            PenColor = settings.PenColor;
            PenWidth = settings.PenWidth;
            PenDashStyle = settings.PenDashStyle;
            BrushColor = settings.BrushColor;
            IsSmoothed = settings.IsSmoothed;
        }
    }
}
