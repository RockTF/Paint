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
            this.Hide();
            Login login = (Login)Application.OpenForms["Login"];
            if (login == null)
            {
                login = new Login();
                login.Show();
            }
            else
            {
                login.Activate();
                login.Show();
            }
        }

        private void BtnSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            Signup signup = (Signup)Application.OpenForms["Signup"];
            if (signup == null)
            {
                signup = new Signup();
                signup.Show();
            }
            else
            {
                signup.Activate();
                signup.Show();
            }
        }
    }
}
