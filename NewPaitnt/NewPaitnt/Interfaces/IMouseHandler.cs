using NewPaitnt.VectorModel;
using System.Drawing;

namespace NewPaitnt.Interfaces
{
    public interface IMouseHandler
    {
        void NewMove(Point move);
        void NewClick(Point click);
        Point2D GetClick();
        Point2D GetMove();
        Point2D GetPreviousMove();
        Point2D GetRightClick();
    }
}
