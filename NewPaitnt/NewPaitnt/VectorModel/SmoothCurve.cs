using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPaitnt.Vector
{
    class SmoothCurve : Figure, IDrawable
    {
        public override List<Point> Points { get; set; }
        public override Pen Pen { get; set; }
        public override Brush Brush { get; set; }
        public Graphics FigureGraphics { get; set; }
        public bool IsLineFinished { get; set; }
        public bool AddNextPoint { get; set; }

        public void CalculateSmoothCurve()
        {

            if (Points.Count == 0)
            {
                Points.Add(new Point(Xclick, Yclick));
            }

            if (AddNextPoint)
            {
                Points.Add(new Point(Xmove, Ymove));
            }
            else
            {
                Points[Points.Count - 1] = new Point(Xmove, Ymove);
            }

            if (IsLineFinished)
            {
                Points.Add(new Point(Xend, Yend));
            }
        }
        public void Draw()
        {
            FigureGraphics.DrawCurve(Pen, Points.ToArray());
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void Refresh()
        {
            throw new NotImplementedException();
        }

        public void Resize()
        {
            throw new NotImplementedException();
        }
    }
}
