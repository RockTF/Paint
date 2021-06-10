using System;
using System.Windows.Forms;

namespace NewPaitnt.Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Welcome welcome = new Welcome();
            welcome.Show();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainPaint mainPaint = new MainPaint();
            mainPaint.Show();
        }
    }
}
