using NewPaitnt.Implementation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewPaitnt
{
    public partial class mainPaint
    {
        Settings settings;
        MouseHandeler mouseHandeler;
        DrawingEngine drawingEngine;
        PenPreview penPreview;
        private void mainPaint_Load(object sender, EventArgs e)
        {
            settings = Settings.Initialize();
            mouseHandeler = MouseHandeler.Initialize();
            drawingEngine = DrawingEngine.Initialize();
            penPreview = PenPreview.Initialize(pictureBoxPen.Width, pictureBoxPen.Height);

            pictureBoxPen.Image = penPreview.PenBitmap;
            pictureBoxPaint.Image = drawingEngine.MainImage;

            currentProcess = Process.GetCurrentProcess();
            currentProcess.Refresh();
            memoryLabel.Text = "Memory usage: " + ((float)currentProcess.PrivateMemorySize64 / 1024f / 1024f).ToString("F1") + " MB";

            IsBtnFillClicked = false;

            //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //DoubleBuffered = true;

            //// Set the value of the double-buffering style bits to true.
            //this.SetStyle(ControlStyles.DoubleBuffer |
            //   ControlStyles.UserPaint |
            //   ControlStyles.AllPaintingInWmPaint,
            //   true);
            //this.UpdateStyles();
        }
    }
}
