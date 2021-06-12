using NewPaitnt.Interfaces;
using NewPaitnt.Enum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace NewPaitnt.Implementation
{
    class ExoGraphics : IGraphics
    {
        public Bitmap Bitmap { get; private set; }
        private Graphics _graphics;
        private Color _blackTransparrent = Color.FromArgb(0, 0, 0, 0);

        public ExoGraphics(int width, int height)
        {
            Bitmap = new Bitmap(width, height);
            _graphics = Graphics.FromImage(Bitmap);
            _graphics.Clear(_blackTransparrent);
        }

        public ExoGraphics(int width, int height, Color color)
        {
            Bitmap = new Bitmap(width, height);
            _graphics = Graphics.FromImage(Bitmap);
            _graphics.Clear(color);
        }

        public ExoGraphics(Bitmap external)
        {
            Bitmap = external;
            _graphics = Graphics.FromImage(Bitmap);
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
            Pen pen = CreatePen(figure);
            Brush brush = new SolidBrush(HexColorConverter.HexToColor(figure.BrushColor));
            int x;
            int y;
            int width;
            int height;

            if (figure.IsSmoothed)
            {
                _graphics.SmoothingMode = SmoothingMode.AntiAlias;
            }
            else
            {
                _graphics.SmoothingMode = SmoothingMode.None;
            }

            switch (figure.FigureType)
            {
                case EFigure.Dot:
                    pen.DashPattern = new float[] { 1f, 1f };
                    _graphics.DrawLine(pen, PointConverter.CustomToSystem(figure.Points[0]), PointConverter.CustomToSystem(figure.Points[1]));
                    break;
                case EFigure.Line:
                    _graphics.DrawLine(pen, PointConverter.CustomToSystem(figure.Points[0]), PointConverter.CustomToSystem(figure.Points[1]));
                    break;
                case EFigure.Rectangle:
                    (x, y, width, height) = CalculateRectangle(figure);
                    _graphics.FillRectangle(brush, x, y, width, height);
                    _graphics.DrawRectangle(pen, x, y, width, height);
                    break;
                case EFigure.Ellipse:
                    (x, y, width, height) = CalculateRectangle(figure);
                    _graphics.FillEllipse(brush, x, y, width, height);
                    _graphics.DrawEllipse(pen, x, y, width, height);
                    break;
                case EFigure.RoundedRectangle:
                    (x, y, width, height) = CalculateRectangle(figure);
                    RectangleF rectangle = new RectangleF(x, y, width, height);
                    GraphicsPath path = GetRoundedRect(rectangle, 14f);
                    _graphics.FillPath(brush, path);
                    _graphics.DrawPath(pen, path);
                    break;
                case EFigure.Triangle:
                    List<Point> TrianglePoint = new List<Point>(3);
                    TrianglePoint.Add(new Point(figure.Points[1].X, figure.Points[1].Y));
                    TrianglePoint.Add(new Point(figure.Points[0].X, figure.Points[1].Y));
                    TrianglePoint.Add(new Point((figure.Points[0].X + figure.Points[1].X) / 2, figure.Points[0].Y));
                    _graphics.FillPolygon(brush, TrianglePoint.ToArray());
                    _graphics.DrawPolygon(pen, TrianglePoint.ToArray());
                    break;
                case EFigure.Curve:
                    _graphics.DrawLines(pen, PointConverter.CustomToSystem(figure.Points));
                    break;
                case EFigure.SmoothCurve:
                    _graphics.DrawCurve(pen, PointConverter.CustomToSystem(figure.Points));
                    break;
                case EFigure.Polygon:
                    _graphics.FillPolygon(brush, PointConverter.CustomToSystem(figure.Points));
                    _graphics.DrawPolygon(pen, PointConverter.CustomToSystem(figure.Points));
                    break;

                default:
                    break;
            }
        }

        public void Draw(List<IDrawable> figures)
        {
            foreach(IDrawable figure in figures)
            {
                Draw(figure);
            }
        }

        private Pen CreatePen(IDrawable figure)
        {
            Pen pen = new Pen(HexColorConverter.HexToColor(figure.PenColor), figure.PenWidth);
            switch (figure.PenDashStyle)
            {
                case EDashStyle.Solid:
                    pen.DashStyle = DashStyle.Solid;
                    break;
                case EDashStyle.Dash:
                    pen.DashStyle = DashStyle.Dash;
                    break;
                case EDashStyle.DashDot:
                    pen.DashStyle = DashStyle.DashDot;
                    break;
                default:
                    break;
            }
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.Round;
            pen.LineJoin = LineJoin.Round;
            pen.DashCap = DashCap.Round;
            return pen;
        }

        private (int x, int y, int width, int height) CalculateRectangle(IDrawable figure)
        {
            int x = (figure.Points[0].X < figure.Points[1].X) ? figure.Points[0].X : figure.Points[1].X;
            int Xend = (figure.Points[0].X < figure.Points[1].X) ? figure.Points[1].X : figure.Points[0].X;
            int y = (figure.Points[0].Y < figure.Points[1].Y) ? figure.Points[0].Y : figure.Points[1].Y;
            int Yend = (figure.Points[0].Y < figure.Points[1].Y) ? figure.Points[1].Y : figure.Points[0].Y;
            int width = Xend - x;
            int height = Yend - y;
            return (x, y, width, height);
        }

        private GraphicsPath GetRoundedRect(RectangleF baseRect, float radius)
        {
            if (radius <= 0.0F)
            {
                GraphicsPath mPath = new GraphicsPath();
                mPath.AddRectangle(baseRect);
                mPath.CloseFigure();
                return mPath;
            }
            if (radius >= (Math.Min(baseRect.Width, baseRect.Height)) / 2.0)
                return GetCapsule(baseRect);

            float diameter = radius * 2.0F;
            SizeF sizeF = new SizeF(diameter, diameter);
            RectangleF arc = new RectangleF(baseRect.Location, sizeF);
            GraphicsPath path = new GraphicsPath();

            path.AddArc(arc, 180, 90);

            arc.X = baseRect.Right - diameter;
            path.AddArc(arc, 270, 90);

            arc.Y = baseRect.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            arc.X = baseRect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        private GraphicsPath GetCapsule(RectangleF baseRect)
        {
            float diameter;
            RectangleF arc;
            GraphicsPath path = new GraphicsPath();
            try
            {
                if (baseRect.Width > baseRect.Height)
                {
                    diameter = baseRect.Height;
                    SizeF sizeF = new SizeF(diameter, diameter);
                    arc = new RectangleF(baseRect.Location, sizeF);
                    path.AddArc(arc, 90, 180);
                    arc.X = baseRect.Right - diameter;
                    path.AddArc(arc, 270, 180);
                }
                else if (baseRect.Width < baseRect.Height)
                {
                    diameter = baseRect.Width;
                    SizeF sizeF = new SizeF(diameter, diameter);
                    arc = new RectangleF(baseRect.Location, sizeF);
                    path.AddArc(arc, 180, 180);
                    arc.Y = baseRect.Bottom - diameter;
                    path.AddArc(arc, 0, 180);
                }
                else
                {
                    path.AddEllipse(baseRect);
                }
            }
            catch (Exception ex)
            {
                path.AddEllipse(baseRect);
            }
            finally
            {
                path.CloseFigure();
            }
            return path;
        }
    }
}
