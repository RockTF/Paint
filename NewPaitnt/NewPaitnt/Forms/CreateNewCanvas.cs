using System;
using System.Windows.Forms;
using NewPaitnt.Implementation;

namespace NewPaitnt
{
    public partial class CreateNewCanvas : Form
    {
        DrawingEngine drawingEngine;

        public CreateNewCanvas()
        {
            InitializeComponent();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            int width = (int)NumericUpDownWidth.Value;
            int height = (int)NumericUpDownHeight.Value;

            //MainPaint main = this.Owner as MainPaint;
            //if (main != null)
            //{
            //    var newsize = main.PictureBoxPaint.Image;
                drawingEngine.MainImage = new Bitmap(width, height);
            this.Close();
            //}

    }

        private void CreateNewCanvas_Load(object sender, EventArgs e)
        {
            drawingEngine = DrawingEngine.Initialize(31, 31); // баг исправить
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
