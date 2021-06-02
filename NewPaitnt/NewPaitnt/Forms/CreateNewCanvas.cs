using System;
using System.Drawing;
using System.Windows.Forms;
using NewPaitnt.Implementation;

namespace NewPaitnt
{
    public partial class CreateNewCanvas : Form
    {
        DrawingEngine drawingEngine;
        Settings settings;

        public CreateNewCanvas()
        {
            InitializeComponent();
            settings = Settings.Initialize();
            drawingEngine = DrawingEngine.Initialize(settings, MouseHandler.Initialize(), PenPreview.Initialize(settings.Pen, 31, 31), Storage.Initialize(), Service.Initialize());
        }
       

        private void BtnOK_Click(object sender, EventArgs e)
        {
            settings.SetImageWidth((int)NumericUpDownWidth.Value);
            settings.SetImageHeight((int)NumericUpDownHeight.Value);

            drawingEngine.NewImageSize();

            this.Close();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
