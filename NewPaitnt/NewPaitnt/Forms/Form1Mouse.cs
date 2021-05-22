using NewPaitnt.Implementation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewPaitnt
{
    public partial class mainPaint
    {
        private void pictureBoxPaint_MouseDown(object sender, MouseEventArgs e)
        {
            mouseHandeler.MouseDown(sender, e);
            pictureBoxPaint.Invalidate();
        }
        private void pictureBoxPaint_MouseMove(object sender, MouseEventArgs e)
        {
            mouseHandeler.MouseMove(sender, e);
            pictureBoxPaint.Invalidate();
        }
        private void pictureBoxPaint_MouseUp(object sender, MouseEventArgs e)
        {
            currentProcess.Refresh();
            memoryLabel.Text = "Memory usage: " + ((float)currentProcess.PrivateMemorySize64 / 1024f / 1024f).ToString("F1") + " MB";
            mouseHandeler.MouseUp(sender, e);
            pictureBoxPaint.Invalidate();
        }
    }
}
