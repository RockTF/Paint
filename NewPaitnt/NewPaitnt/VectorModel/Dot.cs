using NewPaitnt.Interfaces;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace NewPaitnt.VectorModel
{
    public class Dot : IDrawable
    {
        public string FigureName { get; private set; }
        public List<Point> Points { get; set; }
        public Pen Pen { get; set; }
        public Brush Brush { get; set; }
        public SmoothingMode SmoothingMode { get; set; }

        private static int _count = 0;

        public Dot(Point click, Pen pen, SmoothingMode smoothingMode)
        {
            Points = new List<Point>(2);
            Points.Add(click);
            Points.Add(new Point(click.X + 1, click.Y + 1));
            Pen = (Pen)pen.Clone();
            Pen.DashPattern = new float[] { 1f, 1f };
            Brush = new SolidBrush(Color.FromArgb(0, 0, 0, 0));

            FigureName = "Dot" + _count++.ToString();

            SmoothingMode = smoothingMode;
        }

        public void Draw(ref Graphics graphics)
        {
            graphics.SmoothingMode = SmoothingMode;
            graphics.DrawLine(Pen, Points[0], Points[1]);
        }

        public void Move(Point from, Point to)
        {
            for (int i = 0; i < Points.Count; i++)
            {
                int tempX = Points[i].X + (to.X - from.X);
                int tempY = Points[i].Y + (to.Y - from.Y);
                Points[i] = new Point(tempX, tempY);
            }
        }

        public void ChangePen(Pen pen)
        {
            Pen = (Pen)pen.Clone();
            Pen.DashPattern = new float[] { 1f, 1f };
        }

        public void Draw(ref Graphics graphics, Point end)
        {
           
        }

        public void AddNextPoint(Point click)
        {
            throw new System.NotImplementedException();
        }
    }
}
