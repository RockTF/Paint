using NewPaitnt.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPaitnt.Implementation
{
    class Settings : ISettings
    {
        public ushort ImageWidth { get; set; }
        public ushort ImageHeight { get; set; }
        public string Mode { get; set; }
        public Color PenColor { get; set; }
        public float PenWidth { get; set; }
        public Pen Pen { get; set; }
        public Color BrushColor { get; set; }
        public Brush Brush { get; set; }
        public bool IsImageBorderClosed { get; set; }
        public SmoothingMode SmoothingMode { get; set; }
        public void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
