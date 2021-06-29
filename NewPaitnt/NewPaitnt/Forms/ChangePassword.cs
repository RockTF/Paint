using NewPaitnt.Implementation;
using NewPaitnt.SQLWebRequester;
using System;
using System.Windows.Forms;
using Validator;

namespace NewPaitnt.Forms
{
    public partial class ChangePassword : Form
    {
        IRegistrationValidator validator;
        private Settings _settings;

        public ChangePassword()
        {
            InitializeComponent();
            _settings = Settings.Initialize();
            validator = new ValidatorRegEx();
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

        private void EmailTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            EmailTextBox.MaxLength = 30;

            bool isValid;
            string validationMessage;
            (isValid, validationMessage) = validator.EmailValidation(EmailTextBox.Text);
            LabelErrorEmail.Text = validationMessage;
        }

        private void TextBoxNewPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBoxNewPassword.MaxLength = 30;

            bool isValid;
            string validationMessage;
            (isValid, validationMessage) = validator.PasswordValidation(TextBoxNewPassword.Text);
            LabelErrorPassword.Text = validationMessage;
        }

        private void TextBoxReapeatPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBoxReapeatPassword.MaxLength = 30;

            bool isValid;
            string validationMessage;
            (isValid, validationMessage) = validator.PasswordValidation(TextBoxReapeatPassword.Text);
            LabelErrorRepeatPassword.Text = validationMessage;
            if(TextBoxNewPassword.Text != TextBoxReapeatPassword.Text)
            {
                LabelErrorRepeatPassword.Text = "Password mismatch";
            }
        }

        private void CheckBoxRepeat_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxRepeat.Checked)
            {
                TextBoxReapeatPassword.UseSystemPasswordChar = false;
            }
            else
            {
                TextBoxReapeatPassword.UseSystemPasswordChar = true;
            }
        }

        private void CheckBoxNew_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxNew.Checked)
            {
                TextBoxNewPassword.UseSystemPasswordChar = false;
            }
            else
            {
                TextBoxNewPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
