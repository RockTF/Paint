using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPaitnt.Interfaces
{
    interface IMovable
    {
        abstract void Draw(ref Graphics graphics);
        abstract void Draw(ref Graphics graphics, Point end);

        void Move(Point from, Point to);
    }
}
