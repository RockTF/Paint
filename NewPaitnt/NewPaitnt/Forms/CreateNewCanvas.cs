using System;
using System.Windows.Forms;
using NewPaitnt.Implementation;

namespace NewPaitnt
{
    public partial class CreateNewCanvas : Form
    {
        DrawingEngine drawingEngine;
        Settings settings;
        MainPaint parrent;

        public CreateNewCanvas(MainPaint paintUnicorn, DrawingEngine mainDrawingEngine)
        {
            InitializeComponent();
            settings = Settings.Initialize();
            drawingEngine = mainDrawingEngine;
            parrent = paintUnicorn;
        }
       

        private void BtnOK_Click(object sender, EventArgs e)
        {
            settings.SetImageWidth((int)NumericUpDownWidth.Value);
            settings.SetImageHeight((int)NumericUpDownHeight.Value);

            drawingEngine.NewImageSize();
            parrent.RefreshPictureBox();
            // обновить и листбокс тоже
            this.Close();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
