using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPaitnt.Vector
{
    public abstract class Figure
    {
        public abstract List<Point> Points { get; set; }
        public abstract Pen Pen { get; set; }
        public abstract Brush Brush { get; set; }

        public int Xclick { get; set; }
        public int Yclick { get; set; }
        public int Xmove { get; set; }
        public int Ymove { get; set; }
        public int Xstart { get; set; }
        public int Ystart { get; set; }
        public int Xend { get; set; }
        public int Yend { get; set; }


        public void CalculateCoordinates(int Xcurrent, int Ycurrent)
        {
            Xstart = (Xclick < Xcurrent) ? Xclick : Xcurrent;
            Xend = (Xclick < Xcurrent) ? Xcurrent : Xclick;
            Ystart = (Yclick < Ycurrent) ? Yclick : Ycurrent;
            Yend = (Yclick < Ycurrent) ? Ycurrent : Yclick;
        }

    }
}
