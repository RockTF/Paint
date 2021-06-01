using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPaitnt.Interfaces
{
    interface IFigure
    {
        string FigureName { get; }
        List<Point> Points { get; }
        Pen Pen { get; }
        Brush Brush { get; }
        SmoothingMode SmoothingMode { get; }
        void ChangePen(Pen pen);
    }
}
