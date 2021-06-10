using System;
using System.Windows.Forms;

namespace NewPaitnt.Forms
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Welcome welcome = new Welcome();
            welcome.Show();
        }

        private void BtnSignup_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainPaint mainPaint = new MainPaint();
            mainPaint.Show();
        }
    }
}
