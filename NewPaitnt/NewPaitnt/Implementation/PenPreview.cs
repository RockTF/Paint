using System.Drawing;
using System.Drawing.Drawing2D;

namespace NewPaitnt.Implementation
{
    public class PenPreview
    {
        private static PenPreview _penPreview;
        private int _xCenter;
        private int _yCenter;
        public Bitmap PenBitmap { get; private set; }
        private Graphics _penGraphics;
        private PenPreview(Pen pen, int Width, int Height)
        {
            PenBitmap = new Bitmap(Width, Height);
            _xCenter = Width / 2 - 1;
            _yCenter = Height / 2 - 1;
            _penGraphics = Graphics.FromImage(PenBitmap);
            _penGraphics.SmoothingMode = SettingsConstants.DefaultSmoothingMode;
            Refresh(pen, SettingsConstants.DefaultSmoothingMode);
        }
        public static PenPreview Initialize(Pen pen, int Width, int Height)
        {
            if (_penPreview == null)
            {
                _penPreview = new PenPreview(pen, Width, Height);
            }
            return _penPreview;
        }
        public void Refresh(Pen pen, SmoothingMode smoothingMode)
        {
            _penGraphics.Clear(Color.White);
            Pen pointPen = (Pen)pen.Clone();
            pointPen.DashPattern = new float[] { 1f, 1f };
            _penGraphics.SmoothingMode = smoothingMode;
            _penGraphics.DrawLine(pointPen, _xCenter, _yCenter, _xCenter + 1, _yCenter + 1);
        }
    }
}
