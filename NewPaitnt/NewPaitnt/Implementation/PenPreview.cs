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

        private PenPreview(string penColor, float penWidth, bool isSmoothed, int Width, int Height)
        {
            PenBitmap = new Bitmap(Width, Height);
            _xCenter = Width / 2 - 1;
            _yCenter = Height / 2 - 1;
            _penGraphics = Graphics.FromImage(PenBitmap);
            _penGraphics.SmoothingMode = isSmoothed ? SmoothingMode.AntiAlias : SmoothingMode.None;

            DrawPen(penColor, penWidth, isSmoothed);
        }

        public static PenPreview Initialize(string penColor, float penWidth, bool isSmoothed, int Width, int Height)
        {
            if (_penPreview == null)
            {
                _penPreview = new PenPreview(penColor, penWidth, isSmoothed, Width, Height);
            }
            return _penPreview;
        }

        public void DrawPen(string penColor, float penWidth, bool isSmoothed)
        {
            _penGraphics.Clear(Color.White);
            Pen pen = new Pen(HexColorConverter.HexToColor(penColor), penWidth);
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.Round;
            pen.LineJoin = LineJoin.Round;
            pen.DashCap = DashCap.Round;
            pen.DashPattern = new float[] { 1f, 1f };
            _penGraphics.SmoothingMode = isSmoothed ? SmoothingMode.AntiAlias : SmoothingMode.None;
            _penGraphics.DrawLine(pen, _xCenter, _yCenter, _xCenter + 1, _yCenter + 1);
        }
    }
}
