using System.Drawing;
using System.Drawing.Drawing2D;
using static NewPaitnt.Implementation.DrawingEngine;

namespace NewPaitnt.Implementation
{
    public class Settings
    {
        private static Settings _settings;
        public int ImageWidth { get; private set; }
        public int ImageHeight { get; private set; }
        public Buttons Mode { get; private set; }
        public Pen Pen { get; private set; }
        public Brush Brush { get; private set; }
        public SmoothingMode SmoothingMode { get; private set; }
        private Settings()
        {
            ImageWidth = 928;
            ImageHeight = 560;
            Mode = Buttons.point;
            Pen = new Pen(Color.Black, 1f);
            Pen.StartCap = LineCap.Round;
            Pen.EndCap = LineCap.Round;
            Pen.LineJoin = LineJoin.Round;
            Pen.DashCap = DashCap.Round;
            Brush = new SolidBrush(Color.Transparent);
            SmoothingMode = SmoothingMode.None;
        }
        public static Settings Initialize()
        {
            if (_settings == null)
            {
                _settings = new Settings();
            }
            return _settings;
        }
        public void SetImageWidth(int newWidth)
        {
            _settings.ImageWidth = newWidth;
        }
        public void SetImageHeight(int newHeight)
        {
            _settings.ImageHeight = newHeight;
        }
        public void SetMode(Buttons newMode)
        {
            _settings.Mode = newMode;
        }
        public void SetPenWidth(float newWidth)
        {
            _settings.Pen.Width = newWidth;
        }
        public void SetPenColor(Color color)
        {
            _settings.Pen.Color = color;
        }
        public void SetPenDashStyle(DashStyle newStyle)
        {
            _settings.Pen.DashStyle = newStyle;
        }
        public void SetBrushColor(Color newColor)
        {
            _settings.Brush = new SolidBrush(newColor);
        }
        public void SetSmoothingMode(SmoothingMode newMode)
        {
            _settings.SmoothingMode = newMode;
        }
        public void Reset()
        {
            ImageWidth = 928;
            ImageHeight = 560;
            Mode = Buttons.point;
            Pen = new Pen(Color.Black, 1f);
            Pen.StartCap = LineCap.Round;
            Pen.EndCap = LineCap.Round;
            Pen.LineJoin = LineJoin.Round;
            Pen.DashCap = DashCap.Round;
            Brush = new SolidBrush(Color.Transparent);
            SmoothingMode = SmoothingMode.None;
        }
    }
}
