using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPaitnt.Interfaces
{
    public interface ISettings
    {
        ushort ImageWidth { get; set; }
        ushort ImageHeight { get; set; }
        string Mode { get; set; }
        Color PenColor { get; set; }
        float PenWidth { get; set; }
        Pen Pen { get; }
        Color BrushColor { get; set; }
        Brush Brush { get; }
        bool IsImageBorderClosed { get; set; }
        SmoothingMode SmoothingMode { get; set; }
        void Reset();
    }
}
