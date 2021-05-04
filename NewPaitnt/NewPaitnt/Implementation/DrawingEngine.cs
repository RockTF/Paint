using NewPaitnt.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPaitnt.Implementation
{
    public static class DrawingEngine
    {
        public static Bitmap TempImage { get; set; }
        public static Bitmap Figure { get ; set; }
        public static Bitmap Transparent { get; set; }
        public static Graphics MainGraphics { get; set; }
        public static Graphics FigureGraphics { get; set; }

        public static void ClearCanvas()
        {
            throw new NotImplementedException();
        }

        public static void Draw()
        {
            
        }

        public static void DrawCurve()
        {
            throw new NotImplementedException();
        }

        public static void DrawEllipse()
        {
            throw new NotImplementedException();
        }

        public static void DrawLine()
        {
            throw new NotImplementedException();
        }

        public static void DrawPoint()
        {
            throw new NotImplementedException();
        }

        public static void DrawRectangle()
        {
            throw new NotImplementedException();
        }

        public static void DrawSmoothCurve()
        {
            throw new NotImplementedException();
        }

        public static void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}