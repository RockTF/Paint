using NewPaitnt.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPaitnt.Implementation
{
    class DrawingEngine : IDrawingEngine
    {
        public Bitmap TempImage { get; set; }
        public Bitmap Figure { get ; set; }
        public Bitmap Transparent { get; set; }
        public Graphics MainGraphics { get; set; }
        public Graphics FigureGraphics { get; set; }

        public void ClearCanvas()
        {
            throw new NotImplementedException();
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }

        public void DrawCurve()
        {
            throw new NotImplementedException();
        }

        public void DrawEllipse()
        {
            throw new NotImplementedException();
        }

        public void DrawLine()
        {
            throw new NotImplementedException();
        }

        public void DrawPoint()
        {
            throw new NotImplementedException();
        }

        public void DrawRectangle()
        {
            throw new NotImplementedException();
        }

        public void DrawSmoothCurve()
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
