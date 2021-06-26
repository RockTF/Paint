using NewPaitnt.Implementation;
using NewPaitnt.SQLWebRequester;
using System;
using System.Windows.Forms;
using Validator;

namespace NewPaitnt.Forms
{
    public partial class Signup : Form
    {
        IRegistrationValidator validator;
        private Settings _settings;

        public Signup()
        {
            InitializeComponent();
            _settings = Settings.Initialize();
            validator = new ValidatorRegEx();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Welcome welcome = new Welcome();
            welcome.Show();
        }

        private void BtnSignup_Click(object sender, EventArgs e)
        {
            if (TextBoxPassword.Text != TextBoxReapeatPassword.Text)
            {
                MessageBox.Show("Sorry, but the passwords does not match");
            }
            else 
            {
                Registration registration = new Registration();
                int? UserId = registration.Register(TextBoxFirstName.Text, TextBoxLastName.Text, TextBoxEmail.Text, TextBoxPassword.Text);

                if (UserId != null)
                {
                    _settings.SetUserID(UserId);
                    this.Hide();
                    MainPaint mainPaint = new MainPaint();
                    mainPaint.Show();
                }
            }
        }

        private void TextBoxFirstName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBoxFirstName.MaxLength = 30;

            bool isValid;
            string validationMessage;
            (isValid, validationMessage) = validator.NameValidation(TextBoxFirstName.Text);
            LabelErrorFirstName.Text = validationMessage;
        }

        private void TextBoxLastName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBoxLastName.MaxLength = 30;

            bool isValid;
            string validationMessage;
            (isValid, validationMessage) = validator.NameValidation(TextBoxLastName.Text);
            LabelErrorLastName.Text = validationMessage;
        }

        private void TextBoxEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBoxEmail.MaxLength = 30;

            bool isValid;
            string validationMessage;
            (isValid, validationMessage) = validator.EmailValidation(TextBoxEmail.Text);
            LabelErrorEmailName.Text = validationMessage;
        }

        private void TextBoxPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBoxPassword.MaxLength = 30;

            bool isValid;
            string validationMessage;
            (isValid, validationMessage) = validator.PasswordValidation(TextBoxPassword.Text);
            LabelErrorPassword.Text = validationMessage;
        }
    }
}
