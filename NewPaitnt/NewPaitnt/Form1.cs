using NewPaitnt.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewPaitnt
{
    public partial class mainPaint : Form, IGraphicEditor
    {
        public Bitmap MainImage { get; set; }
        public List<Bitmap> History { get; set; }
        public ushort Xclick { get; set; }
        public ushort Yclick { get; set; }
        public ushort Xstart { get; set; }
        public ushort Ystart { get; set; }
        public ushort Xend { get; set; }
        public ushort Yend { get; set; }

        public mainPaint()
        {
            InitializeComponent();
        }

        public void CalculateCoordinates()
        {
            throw new NotImplementedException();
        }
    }
}
