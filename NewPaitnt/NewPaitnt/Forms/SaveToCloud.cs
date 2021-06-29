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
    public partial class SaveToCloud : Form
    {
        public SaveToCloud()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainPaint mainPaint = (MainPaint)Application.OpenForms["MainPaint"];
            if (mainPaint == null)
            {
                mainPaint = new MainPaint();
                mainPaint.Show();
            }
            else
            {
                mainPaint.Activate();
                mainPaint.Show();
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainPaint mainPaint = (MainPaint)Application.OpenForms["MainPaint"];
            if (mainPaint == null)
            {
                mainPaint = new MainPaint();
                mainPaint.Show();
            }
            else
            {
                mainPaint.Activate();
                mainPaint.Show();
            }
        }
    }
}
