using System.Drawing;


namespace NewPaitnt.Interfaces
{
    public interface IMovable
    {
        abstract void Draw(ref Graphics graphics);
        abstract void Draw(ref Graphics graphics, Point end);

        void Move(Point from, Point to);
    }
}
