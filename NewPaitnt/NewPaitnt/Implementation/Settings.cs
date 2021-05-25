using NewPaitnt.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NewPaitnt.Implementation.DrawingEngine;

namespace NewPaitnt.Implementation
{
    public class Settings
    {
        public int ImageWidth { get; set; }
        public int ImageHeight { get; set; }
        public EFigure Mode { get; set; }
        public Pen Pen { get; set; }
        public Brush Brush { get; set; }
        public  bool IsImageBorderClosed { get; set; }
        public SmoothingMode SmoothingMode { get; set; }

        public void Init1ialize()
        {
            ImageWidth = 928;
            ImageHeight = 560;
            Mode = EFigure.Curve;  // "point", "curve", "line", "rectangle", "ellipse", "traingle"
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
        public void Reset()
        {
            ImageWidth = 640;
            ImageHeight = 360;
            Mode = EFigure.Curve; 
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
