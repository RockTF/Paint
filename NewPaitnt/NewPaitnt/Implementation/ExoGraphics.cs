using NewPaitnt.Interfaces;
using NewPaitnt.Enum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;

namespace NewPaitnt.Implementation
{
    class ExoGraphics : IGraphics
    {
        public Bitmap bitmap { get; private set; }
        private Graphics _graphics;
        private Color _blackTransparrent = Color.FromArgb(0, 0, 0, 0);

        public ExoGraphics(int width, int height)
        {
            bitmap = new Bitmap(width, height);
            _graphics = Graphics.FromImage(bitmap);
            _graphics.Clear(_blackTransparrent);
        }

        public ExoGraphics(int width, int height, Color color)
        {
            bitmap = new Bitmap(width, height);
            _graphics = Graphics.FromImage(bitmap);
            _graphics.Clear(color);
        }

        public ExoGraphics(Bitmap external)
        {
            bitmap = external;
            _graphics = Graphics.FromImage(bitmap);
        }

        public void Clear()
        {
            _graphics.Clear(_blackTransparrent);
        }

        public void Clear(Color color)
        {
            _graphics.Clear(color);
        }

        public void Clear(Bitmap external)
        {
            _graphics.DrawImage(external, 0, 0);
        }

        public void Draw(IDrawable figure)
        {
            Pen pen = new Pen(HexColorConverter.HexToColor(figure.PenColor), figure.PenWidth);
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.Round;
            pen.LineJoin = LineJoin.Round;
            pen.DashCap = DashCap.Round;
            Brush brush = new SolidBrush(HexColorConverter.HexToColor(figure.BrushColor));
            
            switch (figure.FigureType)
            {
                case EFigure.Dot:
                    _graphics.DrawLine(pen, PointConverter.CustomToSystem(figure.Points[0]), PointConverter.CustomToSystem(figure.Points[1]));
                    break;

            }
        }

        public void Draw(List<IDrawable> figures)
        {
            throw new NotImplementedException();
        }
    }
}
