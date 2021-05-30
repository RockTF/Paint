using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;

namespace NewPaitnt.VectorModel
{
    public class RoundedRectangle:Figure
    {
        private static int _count = 0;
        public RoundedRectangle(Point start, Point end, Pen pen, SmoothingMode smoothingMode)
        {
            Points = new List<Point>(2);

            Points.Add(start);
            Points.Add(end);

            Pen = (Pen)pen.Clone();
            SmoothingMode = smoothingMode;

            FigureName = "RoundedRectangle" + _count++.ToString();
        }

        public override void Draw(ref Graphics graphics)
        {
            int Xstart = (Points[0].X < Points[1].X) ? Points[0].X : Points[1].X;
            int Xend = (Points[0].X < Points[1].X) ? Points[1].X : Points[0].X;
            int Ystart = (Points[0].Y < Points[1].Y) ? Points[0].Y : Points[1].Y;
            int Yend = (Points[0].Y < Points[1].Y) ? Points[1].Y : Points[0].Y;

            RectangleF rectangle = new RectangleF(Xstart, Ystart, Xend - Xstart, Yend - Ystart);
            GraphicsPath path = this.GetRoundedRect(rectangle, radius: 14);

            graphics.SmoothingMode = SmoothingMode;
            graphics.DrawPath(Pen, path);
            
        }

        private GraphicsPath GetRoundedRect(RectangleF baseRect,
           float radius)
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

        public override void Draw(ref Graphics graphics, Point end)
        {
            Points[1] = end;

            int Xstart = (Points[0].X < Points[1].X) ? Points[0].X : Points[1].X;
            int Xend = (Points[0].X < Points[1].X) ? Points[1].X : Points[0].X;
            int Ystart = (Points[0].Y < Points[1].Y) ? Points[0].Y : Points[1].Y;
            int Yend = (Points[0].Y < Points[1].Y) ? Points[1].Y : Points[0].Y;

            RectangleF rectangle = new RectangleF(Xstart, Ystart, Xend - Xstart, Yend - Ystart);
            GraphicsPath path = this.GetRoundedRect(rectangle, radius: 14);

            graphics.SmoothingMode = SmoothingMode;
            graphics.DrawPath(Pen, path);
        }

        public override void Refresh(ref Graphics graphics)
        {
            throw new NotImplementedException();
        }
    }
}
