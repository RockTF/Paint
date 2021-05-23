using System.Drawing;

namespace NewPaitnt.Implementation
{
    public class PenPreview
    {
        private static PenPreview _penPreview;
        private int _xCenter;
        private int _yCenter;
        public Bitmap PenBitmap { get; private set; }
        private Graphics _penGraphics;
        private Settings _settings;
        private PenPreview(Settings settings, int Width, int Height)
        {
            _settings = settings;
            PenBitmap = new Bitmap(Width, Height);
            _xCenter = Width / 2 - 1;
            _yCenter = Height / 2 - 1;
            _penGraphics = Graphics.FromImage(PenBitmap);
            _penGraphics.SmoothingMode = _settings.SmoothingMode;
            Refresh();
        }
        public static PenPreview Initialize(Settings settings, int Width, int Height)
        {
            
            if (_penPreview == null)
            {
                _penPreview = new PenPreview(settings, Width, Height);
            }
            return _penPreview;
        }
        public void Refresh()
        {
            _penGraphics.Clear(Color.White);
            Pen pointPen = (Pen)_settings.Pen.Clone();
            pointPen.DashPattern = new float[] { 1f, 1f };
            _penGraphics.SmoothingMode = _settings.SmoothingMode;
            _penGraphics.DrawLine(pointPen, _xCenter, _yCenter, _xCenter + 1, _yCenter + 1);
        }
    }
}
