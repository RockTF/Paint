using DTO;
using NewPaitnt.Implementation;
using NewPaitnt.SQLWebRequester;
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
        private Storage _storage = Storage.Initialize();
        private Settings _settings = Settings.Initialize();
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
            PictureDTO pictureDTO = _storage.GetPictureDTO((int)_settings.UserId, textBoxFileName.Text, (EPictureTypes)comboBoxPictureType.SelectedIndex);

            SaveLoad saveLoad = new SaveLoad();

            saveLoad.SaveToServer(pictureDTO);

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
