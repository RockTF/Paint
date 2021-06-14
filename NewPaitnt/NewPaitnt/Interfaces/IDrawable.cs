using NewPaitnt.Enum;
using NewPaitnt.Implementation;
using NewPaitnt.VectorModel;
using System.Collections.Generic;

namespace NewPaitnt.Interfaces
{
   public interface IDrawable
   {
        EFigure FigureType { get; }
        string FigureName { get; }
        List<Point2D> Points { get; }
        string PenColor { get; }
        float PenWidth { get; }
        EDashStyle PenDashStyle { get; }
        string BrushColor { get; }
        bool IsSmoothed { get; }

        public void UpdatePoint(Point2D point);
        void Move(Point2D from, Point2D to);
        void Update(Settings settings);
   }
}
