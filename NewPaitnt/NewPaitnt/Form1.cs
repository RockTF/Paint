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
        public mainPaint()
        {
            InitializeComponent();
        }

        private void mainPaint_Load(object sender, EventArgs e)
        {
            Settings.Initialize();
            DrawingEngine.Initialize();
            pictureBoxPaint.Image = DrawingEngine.MainImage;
        }

        private void pictureBoxPaint_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DrawingEngine.MainImageToTemporary();
                DrawingEngine.Xclick = e.X;
                DrawingEngine.Yclick = e.Y;
            }
        }

        private void pictureBoxPaint_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DrawingEngine.CalculateCoordinates(e.X, e.Y);
                DrawingEngine.Draw();
                pictureBoxPaint.Image = DrawingEngine.MainImage;
            }
        }
    }
}
