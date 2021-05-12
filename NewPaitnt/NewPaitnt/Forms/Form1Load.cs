﻿using NewPaitnt.Implementation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPaitnt
{
    public partial class mainPaint
    {
        private void mainPaint_Load(object sender, EventArgs e)
        {
            Settings.Init1ialize();
            DrawingEngine.Initialize();
            PenPreview.Initialize(pictureBoxPen.Width, pictureBoxPen.Height);
            pictureBoxPen.Image = PenPreview.PenBitmap;
            pictureBoxPaint.Image = DrawingEngine.MainImage;

            currentProcess = Process.GetCurrentProcess();
            currentProcess.Refresh();
            memoryLabel.Text = "Memory usage: " + ((float)currentProcess.PrivateMemorySize64 / 1024f / 1024f).ToString("F1") + " MB";

            IsBtnFillClicked = false;
        }
    }
}
