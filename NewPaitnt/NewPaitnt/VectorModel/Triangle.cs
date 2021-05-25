using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPaitnt.Vector
{
    public class Triangle : Figure, IDrawable
    {
        public override List<Point> Points { get; set; }
        public override Pen Pen { get; set; }
        public override Brush Brush { get; set; }
        public Graphics FigureGraphics { get; set; }

        public void CalculateTriangle()
        {
            Points.Add(new Point(Xend, Yend));
            Points.Add(new Point(Xstart, Yend));
            Points.Add(new Point((Xstart + Xend) / 2, Ystart));
        } 

        public void Draw()
        {
            FigureGraphics.FillPolygon(Brush, Points.ToArray());
            FigureGraphics.DrawPolygon(Pen, Points.ToArray());
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
