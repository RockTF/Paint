using System.Drawing;
using System.Drawing.Drawing2D;

namespace NewPaitnt.Interfaces
{
    public interface IPenPreview
    {
        void Refresh(Pen pen, SmoothingMode smoothingMode);
    }
}
