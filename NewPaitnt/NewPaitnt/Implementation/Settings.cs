using NewPaitnt.Enum;

namespace NewPaitnt.Implementation
{
    public class Settings
    {
        private static Settings _settings;
        public int ImageWidth { get; private set; }
        public int ImageHeight { get; private set; }
        public bool AddNextPoint { get; private set; } // оправдано ли здесь
        public bool IisLineFinished { get; private set; } // оправдано ли здесь
        public EMode Mode { get; private set; }
        public string PenColor { get; private set; }
        public float PenWidth { get; private set; }
        public EDashStyle PenDashStyle { get; private set; }
        public string BrushColor { get; private set; }
        public bool IsSmoothed { get; private set; }
        public int numberOfPolygonApexes { get; private set; }
        public int UserId { get; private set; }

        private Settings()
        {
            Reset();
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

        public void SetMode(EMode newMode)
        {
            _settings.Mode = newMode;
        }

        public void SetPenWidth(float newWidth)
        {
            _settings.PenWidth = newWidth;
        }

        public void SetPenColor(string hexColor)
        {
            _settings.PenColor = hexColor;
        }

        public void SetPenDashStyle(EDashStyle dashStyle)
        {
            _settings.PenDashStyle = dashStyle;
        }

        public void SetBrushColor(string hexColor)
        {
            _settings.BrushColor = hexColor;
        }

        public void SetSmooth()
        {
            _settings.IsSmoothed = true;
        }

        public void SetUnsmooth()
        {
            _settings.IsSmoothed = false;
        }

        public void SetNumberOfPolygonApexes(int number)
        {
            numberOfPolygonApexes = number;
        }

        public void SetUserID(int id)
        {
            UserId = id;
        }

        public void Reset()
        {
            ImageWidth = SettingsConstants.DefaultImageWidth;
            ImageHeight = SettingsConstants.DefaultImageHeight;
            Mode = SettingsConstants.DefaultMode;
            PenColor = SettingsConstants.DefaultPenColor;
            PenWidth = SettingsConstants.DefaultPenWidth;
            PenDashStyle = SettingsConstants.DefaultPenDashStyle;
            BrushColor = SettingsConstants.DefaultBrushColor;
            IsSmoothed = SettingsConstants.DefaultSmooth;
            numberOfPolygonApexes = SettingsConstants.DefaultNumberOfPolygonApexes;
            UserId = -1;
        }
    }
}
