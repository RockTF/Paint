using NewPaitnt.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPaitnt.Implementation
{
    public static class Settings
    {
        public static ushort ImageWidth { get; set; }
        public static ushort ImageHeight { get; set; }
        public static string Mode { get; set; }
        public static Pen Pen { get; set; }
        public static Brush Brush { get; set; }
        public static bool IsImageBorderClosed { get; set; }
        public static SmoothingMode SmoothingMode { get; set; }
        public static void Initialize()
        {
            ImageWidth = 640;
            ImageHeight = 360;
            Mode = "rectangle";
            Pen = new Pen(Color.Black, 1f);
            Brush = new SolidBrush(Color.Transparent);
            IsImageBorderClosed = false;
            SmoothingMode = SmoothingMode.None;
        }

        public static void Reset()
        {
            ImageWidth = 640;
            ImageHeight = 360;
            Mode = "rectangle";
            Pen.Color = Color.Black;
            Pen.Width = 1f;
            Brush = new SolidBrush(Color.Transparent);
            IsImageBorderClosed = false;
            SmoothingMode = SmoothingMode.None;
        }
    }
}
