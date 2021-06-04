using System.Drawing;


namespace NewPaitnt.Interfaces
{
    public interface IMouseHandler
    {
        void NewMove(Point move);
        void NewClick(Point click);
        Point GetClick();
        Point GetMove();
        Point GetPreviousMove();
        Point GetRightClick();
    }
}
