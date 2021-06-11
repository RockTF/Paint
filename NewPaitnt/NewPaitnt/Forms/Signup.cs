using System;
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
            this.Hide();
            MainPaint mainPaint = new MainPaint();
            mainPaint.Show();
        }

        private void TextBoxFirstName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBoxFirstName.MaxLength = 30;

            validator.Name = TextBoxFirstName.Text;
            LabelErrorFirstName.Text = validator.ErrorMessage;
            validator.InputValidation();

        }

        private void TextBoxLastName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBoxFirstName.MaxLength = 30;

            validator.Name = TextBoxFirstName.Text;
            LabelErrorFirstName.Text = validator.ErrorMessage;
            validator.InputValidation();
        }
    }
}
