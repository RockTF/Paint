using NewPaitnt.Implementation;
using NewPaitnt.SQLWebRequester;
using System;
using System.Windows.Forms;

namespace NewPaitnt.Forms
{
    public partial class ChangePassword : Form
    {
        private Settings _settings;

        public ChangePassword()
        {
            InitializeComponent();
            _settings = Settings.Initialize();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void BtnChange_Click(object sender, EventArgs e)
        {
            Authorization authorization = new Authorization();
            int? UserId = authorization.Update(EmailTextBox.Text, TextBoxNewPassword.Text);
            if (UserId != null)
            {
                _settings.SetUserID(UserId);
                this.Hide();
                MainPaint mainPaint = new MainPaint();
                mainPaint.Show();
            }
        }
    }
}
