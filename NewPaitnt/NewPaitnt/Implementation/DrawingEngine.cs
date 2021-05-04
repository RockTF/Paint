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
        public static Bitmap ClearTransparent { get; set; }
        public static Graphics MainGraphics { get; set; }
        public static Graphics FigureGraphics { get; set; }

        public static void ClearCanvas()
        {
            MainGraphics.Clear(Color.White);
        }

        public static void Draw()
        {
            switch (Settings.Mode)
            {
                case "rectangle":
                    DrawRectangle();
                    break;
                default:
                    break;
            }
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
            mainPaint.MainImage = (Bitmap)TempImage.Clone();
            MainGraphics = Graphics.FromImage(mainPaint.MainImage);
            Transparent = (Bitmap)ClearTransparent.Clone();
            FigureGraphics = Graphics.FromImage(Transparent);
            FigureGraphics.DrawRectangle(Settings.Pen, mainPaint.Xstart, mainPaint.Ystart, mainPaint.Xend - mainPaint.Xstart, mainPaint.Yend - mainPaint.Ystart);
            MainGraphics.DrawImage(Transparent, 0, 0);
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