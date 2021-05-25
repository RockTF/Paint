using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace NewPaitnt.Interfaces
{
   public interface IDrawable
   {
        string FigureName { get; }
        List<Point> Points { get; }
        Pen Pen { get; }
        Brush Brush { get; }
        SmoothingMode SmoothingMode { get; }

        abstract void Draw(ref Graphics graphics);
        void Move(Point from, Point to);
        void ChangePen(Pen pen);
    }
}
