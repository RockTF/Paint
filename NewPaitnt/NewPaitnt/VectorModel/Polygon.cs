using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPaitnt.Vector
{
    public class Polygon : Figure, IDrawable
    {
        public override List<Point> Points { get; set; }
        public override Pen Pen { get; set; }
        public override Brush Brush { get; set; }
        public Graphics FigureGraphics { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Draw()
        {
            throw new NotImplementedException();
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
