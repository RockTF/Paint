﻿using NewPaitnt.Implementation;
using NewPaitnt.SQLWebRequester;
using System;
using System.Windows.Forms;
using Validator;

namespace NewPaitnt.Forms
{
    public partial class Login : Form
    {
        IRegistrationValidator validator;
        private Settings _settings;

        public Login()
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

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Authorization authorization = new Authorization();
            int? UserId = authorization.Authorize(TextBoxEmail.Text, TextBoxPassword.Text);
            if (UserId != null)
            {
                _settings.SetUserID(UserId);
                this.Hide();
                MainPaint mainPaint = new MainPaint();
                mainPaint.Show();
            }
        }

        private void BtnForgot_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangePassword changePassword = new ChangePassword();
            changePassword.Show();
            this.Close();
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

        private void CheckBoxPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxPassword.Checked)
            {
                TextBoxPassword.UseSystemPasswordChar = false;
            }
            else
            {
                TextBoxPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
