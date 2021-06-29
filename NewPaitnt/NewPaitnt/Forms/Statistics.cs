using System;
using System.Windows.Forms;

namespace NewPaitnt.Forms
{
    public partial class Statistics : Form
    {
        public Statistics()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainPaint mainPaint = (MainPaint)Application.OpenForms["MainPaint"];
            if (mainPaint == null)
            {
                mainPaint = new MainPaint();
                mainPaint.Show();
            }
            else
            {
                mainPaint.Activate();
                mainPaint.Show();
            }
        }
    }
}
