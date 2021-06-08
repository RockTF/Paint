using System;
using System.Windows.Forms;

namespace NewPaitnt.Forms
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();

            this.Close();
        }

        private void BtnSignUp_Click(object sender, EventArgs e)
        {
            Signup signup = new Signup();
            signup.Show();

            this.Close();
        }
    }
}
