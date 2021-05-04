using NewPaitnt.Implementation;
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
    public partial class mainPaint : Form
    {
        public static Bitmap MainImage { get; set; }
        public static List<Bitmap> History { get; set; }
        public static ushort Xclick { get; set; }
        public static ushort Yclick { get; set; }
        public static ushort Xstart { get; set; }
        public static ushort Ystart { get; set; }
        public static ushort Xend { get; set; }
        public static ushort Yend { get; set; }

        public mainPaint()
        {
            InitializeComponent();
        }

        public void CalculateCoordinates()
        {
            throw new NotImplementedException();
        }

        private void mainPaint_Load(object sender, EventArgs e)
        {
            Settings.Initialize();
            MainImage = new Bitmap(Settings.ImageWidth, Settings.ImageHeight);
            DrawingEngine.MainGraphics = Graphics.FromImage(MainImage);
            DrawingEngine.MainGraphics.Clear(Color.White);
            pictureBoxPaint.Image = MainImage;
        }
    }
}
