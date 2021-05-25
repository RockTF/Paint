using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPaitnt.Vector
{
    public class Rectangle : Figure, IDrawable
    {
        public override List<Point> Points { get; set; }
        public override Pen Pen { get; set; }
        public override Brush Brush { get; set; }
        public Graphics FigureGraphics { get; set; }

        public void CalculateRectangle()
        {
            Points.Add(new Point(Xstart, Ystart));
            Points.Add(new Point(Xend - Xstart, Yend - Ystart));
        }
        public void Draw()
        {
            FigureGraphics.FillRectangle(Brush, Xstart, Ystart, Xend - Xstart, Yend - Ystart);
            FigureGraphics.DrawRectangle(Pen, Xstart, Ystart, Xend - Xstart, Yend - Ystart);
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
