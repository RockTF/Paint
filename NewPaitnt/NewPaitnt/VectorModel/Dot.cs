using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPaitnt.Vector
{
    public class Dot : Figure, IDrawable
    {
        public override List<Point> Points { get; set; }
        public override Pen Pen { get; set; }
        public override Brush Brush { get; set; }
        public Graphics FigureGraphics { get; set; }

        public void CalculateDot()
        {
            Points.Add(new Point(Xclick, Yclick));
            Points.Add(new Point(Xclick + 1, Yclick + 1));
        } 

        public void Draw()
        {
            FigureGraphics.DrawLine(Pen, Points[0], Points[1]);
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
