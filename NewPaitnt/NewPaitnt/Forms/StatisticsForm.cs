using DTO;
using NewPaitnt.Implementation;
using NewPaitnt.SQLWebRequester;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NewPaitnt.Forms
{
    public partial class StatisticsForm : Form
    {
        private Settings _settings = Settings.Initialize();
        public StatisticsForm()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, EventArgs e)
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

        private void Statistics_Load(object sender, EventArgs e)
        {
            Statistic statistic = new Statistic();
            IEnumerable<PersonModel> stats = statistic.Get((int)_settings.UserId);
            dataGridView.DataSource = stats;
        }
    }
}
