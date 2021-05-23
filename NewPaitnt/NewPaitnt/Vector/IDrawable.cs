using System.Drawing;

namespace NewPaitnt.Vector
{
    interface IDrawable
    {
        abstract void Draw(ref Graphics graphics);
        void Move(Point from, Point to);
        void Selest();
        void Deselect();
        void RefreshPen();
    }
}
