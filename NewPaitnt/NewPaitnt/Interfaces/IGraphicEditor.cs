using System.Collections.Generic;
using System.Drawing;

namespace NewPaitnt.Interfaces
{
    interface IGraphicEditor
    {
        Bitmap MainImage { get; set; }
        List<Bitmap> History { get; set; }
        ushort Xclick { get; set; }
        ushort Yclick { get; set; }
        ushort Xstart { get; set; }
        ushort Ystart { get; set; }
        ushort Xend { get; set; }
        ushort Yend { get; set; }
        void CalculateCoordinates();
    }
}
