using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace NewPaitnt.Interfaces
{
    public interface IFigure
    {
        string FigureName { get; }
        List<Point> Points { get; }
        Pen Pen { get; }
        Brush Brush { get; }
        SmoothingMode SmoothingMode { get; }
        void ChangePen(Pen pen);
    }
}
