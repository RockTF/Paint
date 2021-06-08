using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewPaitnt.Forms
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Welcome welcome = new Welcome();
            welcome.Show();

            this.Close();
        }

        private void BtnSignup_Click(object sender, EventArgs e)
        {
            MainPaint mainPaint = new MainPaint();
            mainPaint.Show();

            this.Close();
        }
    }
}
