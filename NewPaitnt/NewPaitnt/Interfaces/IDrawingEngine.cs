using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPaitnt.Interfaces
{
    interface IDrawingEngine
    {
        Bitmap TempImage { get; set; }
        Bitmap Figure { get; set; }
        Bitmap Transparent { get; set; }
        Graphics MainGraphics { get; set; }
        Graphics FigureGraphics { get; set; }
        void Initialize();
        void Draw();
        void DrawPoint();
        void DrawCurve();
        void DrawLine();
        void DrawSmoothCurve();
        void DrawRectangle();
        void DrawEllipse();
        void ClearCanvas();
    }
}
