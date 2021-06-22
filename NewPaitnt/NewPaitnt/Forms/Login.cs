﻿using NewPaitnt.Interfaces;
using System;
using System.Windows.Forms;

namespace NewPaitnt.Forms
{
    public partial class Login : Form
    {
        IRegistrationValidator validator;

        public Login()
        {
            InitializeComponent();

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
            this.Hide();
            MainPaint mainPaint = new MainPaint();
            mainPaint.Show();
        }

        private void BtnForgot_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangePassword changePassword = new ChangePassword();
            changePassword.Show();
        }

        private void TextBoxEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBoxEmail.MaxLength = 30;

            bool isValid;
            string validationMessage;
            (isValid, validationMessage) = validator.NameValidation(TextBoxEmail.Text);
            LabelErrorEmailName.Text = validationMessage;
        }

        private void TextBoxPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBoxPassword.MaxLength = 30;

            bool isValid;
            string validationMessage;
            (isValid, validationMessage) = validator.PasswordValidation(TextBoxEmail.Text);
            LabelErrorPassword.Text = validationMessage;
        }
    }
}
