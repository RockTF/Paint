using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPaitnt.Implementation
{
    public static class PenPreview
    {
        public static int Xcenter { get; set; }
        public static int Ycenter { get; set; }
        public static Bitmap PenBitmap { get; set; }
        public static Graphics PenGraphics { get; set; }
        public static void Initialize(int Width, int Height)
        {
            PenBitmap = new Bitmap(Width, Height);
            Xcenter = Width / 2 - 1;
            Ycenter = Height / 2 - 1;
            PenGraphics = Graphics.FromImage(PenBitmap);
            PenGraphics.SmoothingMode = Settings.SmoothingMode;
            Refresh();
        }
        public static void Refresh()
        {
            PenGraphics.Clear(Color.White);
            Pen pointPen = (Pen)Settings.Pen.Clone();
            pointPen.DashPattern = new float[] { 1f, 1f };
            PenGraphics.SmoothingMode = Settings.SmoothingMode;
            PenGraphics.DrawLine(pointPen, Xcenter, Ycenter, Xcenter + 1, Ycenter + 1);
        }


    }
}
