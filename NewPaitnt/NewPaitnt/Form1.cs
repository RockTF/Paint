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
        public static int Xclick { get; set; }
        public static int Yclick { get; set; }
        public static int Xstart { get; set; }
        public static int Ystart { get; set; }
        public static int Xend { get; set; }
        public static int Yend { get; set; }

        public mainPaint()
        {
            InitializeComponent();
        }

        public void CalculateCoordinates(int Xcurrent, int Ycurrent)
        {
            Xstart = (Xclick < Xcurrent) ? Xclick : Xcurrent;
            Xend = (Xclick < Xcurrent) ? Xcurrent : Xclick;
            Ystart = (Yclick < Ycurrent) ? Yclick : Ycurrent;
            Yend = (Yclick < Ycurrent) ? Ycurrent : Yclick;
        }

        private void mainPaint_Load(object sender, EventArgs e)
        {
            Settings.Initialize();
            MainImage = new Bitmap(Settings.ImageWidth, Settings.ImageHeight);
            DrawingEngine.ClearTransparent = new Bitmap(Settings.ImageWidth, Settings.ImageHeight);
            DrawingEngine.MainGraphics = Graphics.FromImage(MainImage);
            DrawingEngine.MainGraphics.Clear(Color.White);
            pictureBoxPaint.Image = MainImage;
        }

        private void pictureBoxPaint_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DrawingEngine.TempImage = (Bitmap)MainImage.Clone();
                Xclick = e.X;
                Yclick = e.Y;
            }
        }

        private void pictureBoxPaint_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CalculateCoordinates(e.X, e.Y);
                DrawingEngine.Draw();
                pictureBoxPaint.Image = MainImage;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
}
