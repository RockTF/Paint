using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPaitnt.Vector
{
    public interface IFigure
    {
        List<Point> points { get; set; }
        Pen pen { get; set; }
        Brush brush { get; set; }

        void Refresh();
        void Move();
        void Sckale();
        void Rotate();
    }
}
