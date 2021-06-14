using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace NewPaitnt.Forms
{
    public partial class Signup : Form
    {
        Validator validator;

        public Signup()
        {
            InitializeComponent();

            validator = new Validator();
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
                MessageBox.Show("Sorry, but the first password does not match the second");
            }
            else 
            {
                this.Hide();
                MainPaint mainPaint = new MainPaint();
                mainPaint.Show();
            }
        }

        private void TextBoxFirstName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBoxFirstName.MaxLength = 30;

            validator.Name = TextBoxFirstName.Text;
            LabelErrorFirstName.Text = validator.InputValidation();
            validator.InputValidation();

        }

        private void TextBoxLastName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBoxLastName.MaxLength = 30;

            validator.Name = TextBoxLastName.Text;
            LabelErrorLastName.Text = validator.InputValidation();
            validator.InputValidation();
        }

        private void TextBoxEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBoxEmail.MaxLength = 30;

            validator.Name = TextBoxEmail.Text;
            LabelErrorEmailName.Text = validator.InputValidationEmail();
            validator.InputValidationEmail();
        }
    }
}
