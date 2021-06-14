using System;
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
            drawingEngine = new DrawingEngine(settings, MouseHandler.Initialize(), Storage.Initialize());
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
