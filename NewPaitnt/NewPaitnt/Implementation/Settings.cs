using System.Drawing;
using System.Drawing.Drawing2D;

namespace NewPaitnt.Implementation
{
    public class Settings
    {
        private static Settings _settings;
        public int ImageWidth { get; private set; }
        public int ImageHeight { get; private set; }
        public EFigure Mode { get; private set; }
        public Pen Pen { get; private set; }
        public Brush Brush { get; private set; }
        public SmoothingMode SmoothingMode { get; private set; }
        private Settings()
        {
            ImageWidth = SettingsConstants.DefaultImageWidth;
            ImageHeight = SettingsConstants.DefaultImageHeight;
            Mode = SettingsConstants.DefaultMode;
            Pen = new Pen(Color.Black, 1f);
            Pen.StartCap = LineCap.Round;
            Pen.EndCap = LineCap.Round;
            Pen.LineJoin = LineJoin.Round;
            Pen.DashCap = DashCap.Round;
            Brush = new SolidBrush(Color.Transparent);
            SmoothingMode = SettingsConstants.DefaultSmoothingMode;
        }
        public static Settings Initialize()
        {
            if (_settings == null)
            {
                _settings = new Settings();
            }
            return _settings;
        }
        // Все свойства сетим через методы чтобы не поменять случайно
        public void SetImageWidth(int newWidth)
        {
            _settings.ImageWidth = newWidth;
        }

        public void SetImageHeight(int newHeight)
        {
            _settings.ImageHeight = newHeight;
        }

        public void SetMode(EFigure newMode)
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
            ImageWidth = SettingsConstants.DefaultImageWidth;
            ImageHeight = SettingsConstants.DefaultImageHeight;
            Mode = SettingsConstants.DefaultMode;
            Pen = new Pen(Color.Black, 1f);
            Pen.StartCap = LineCap.Round;
            Pen.EndCap = LineCap.Round;
            Pen.LineJoin = LineJoin.Round;
            Pen.DashCap = DashCap.Round;
            Brush = new SolidBrush(Color.Transparent);
            SmoothingMode = SettingsConstants.DefaultSmoothingMode;
        }
    }
}
