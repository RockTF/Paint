﻿using NewPaitnt.Interfaces;
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
        public static int Xclick { get; set; }
        public static int Yclick { get; set; }
        public static int Xstart { get; set; }
        public static int Ystart { get; set; }
        public static int Xend { get; set; }
        public static int Yend { get; set; }
        public static Bitmap MainImage { get; set; }
        public static List<Bitmap> History { get; set; }
        public static Bitmap TempImage { get; set; }
        public static Bitmap Figure { get ; set; }
        public static Bitmap Transparent { get; set; }
        public static Bitmap ClearTransparent { get; set; }
        public static Graphics MainGraphics { get; set; }
        public static Graphics FigureGraphics { get; set; }

        public static void Initialize()
        {
            MainImage = new Bitmap(Settings.ImageWidth, Settings.ImageHeight);
            ClearTransparent = new Bitmap(Settings.ImageWidth, Settings.ImageHeight);
            MainGraphics = Graphics.FromImage(MainImage);
            MainGraphics.Clear(Color.White);
        }
        public static void ClearCanvas()
        {
            MainGraphics.Clear(Color.White);
        }

        public static void CalculateCoordinates(int Xcurrent, int Ycurrent)
        {
            Xstart = (Xclick < Xcurrent) ? Xclick : Xcurrent;
            Xend = (Xclick < Xcurrent) ? Xcurrent : Xclick;
            Ystart = (Yclick < Ycurrent) ? Yclick : Ycurrent;
            Yend = (Yclick < Ycurrent) ? Ycurrent : Yclick;
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
            MainImage = (Bitmap)TempImage.Clone();
            MainGraphics = Graphics.FromImage(MainImage);
            Transparent = (Bitmap)ClearTransparent.Clone();
            FigureGraphics = Graphics.FromImage(Transparent);
            FigureGraphics.DrawRectangle(Settings.Pen, Xstart, Ystart, Xend - Xstart, Yend - Ystart);
            MainGraphics.DrawImage(Transparent, 0, 0);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public static void DrawSmoothCurve()
        {
            throw new NotImplementedException();
        }

        public static void MainImageToTemporary()
        {
            TempImage = (Bitmap)MainImage.Clone();
        }

        public static void SaveToHistory()
        {

        }

        public static void Undo()
        {

        }

        public static void Redo()
        {

        }
    }
}