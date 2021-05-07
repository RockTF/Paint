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
        public static int ImageWidth { get; set; }
        public static int ImageHeight { get; set; }
        public static string Mode { get; set; }
        public static Pen Pen { get; set; }
        public static Brush Brush { get; set; }
        public static bool IsImageBorderClosed { get; set; }
        public static SmoothingMode SmoothingMode { get; set; }

        public static void Init1ialize()
        {
            ImageWidth = 928;
            ImageHeight = 560;
            Mode = "rectangle"; // "point", "curve", "line", "rectangle", "ellipse", "traingle"
            Pen = new Pen(Color.Black, 1f);
            Pen.StartCap = LineCap.Round;
            Pen.EndCap = LineCap.Round;
            // Соединение линий под углом (излом)
            Pen.LineJoin = LineJoin.Round;
            // Кончик линии на штрихе
            Pen.DashCap = DashCap.Round;
            Brush = new SolidBrush(Color.Transparent);
            IsImageBorderClosed = false;
            SmoothingMode = SmoothingMode.None;
        }
        // Предстоит реализовать сброс настроек
        public static void Reset()
        {
            ImageWidth = 640;
            ImageHeight = 360;
            Mode = "smoothCorv";
            Pen.Color = Color.Black;
            Pen.Width = 1f;
            Pen.StartCap = LineCap.Round;
            Pen.EndCap = LineCap.Round;
            Pen.LineJoin = LineJoin.Round;
            Pen.DashCap = DashCap.Round;
            Brush = new SolidBrush(Color.Transparent);
            IsImageBorderClosed = false;
            SmoothingMode = SmoothingMode.None;
        }
    }
}
