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
    public partial class OpenPicture : Form
    {
        PictureListDTO pictureListDTO;

        Settings _settings = Settings.Initialize();
        Storage _storage = Storage.Initialize();
        public OpenPicture()
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
            if (ListBoxPicture.SelectedIndex == -1)
            {
                MessageBox.Show("Please, select picture!");
            }
            else
            {
                SaveLoad saveLoad = new SaveLoad();
                int pictureID = pictureListDTO.PictureIds[ListBoxPicture.SelectedIndex];
                PictureToClientDTO picture = saveLoad.LoadFromServer(pictureID);

                if (picture.PictureType == EPictureTypes.json)
                {
                    _storage.SetJson(picture.Picture);
                }
                else
                {
                    _storage.SetPictureToLoad(picture.Picture);
                }
                
            }
            
            
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

        private void OpenPicture_Load(object sender, EventArgs e)
        {
            SaveLoad saveLoad = new SaveLoad();
            pictureListDTO = saveLoad.LoadPictureListForUser((int)_settings.UserId);
            ListBoxPicture.Items.Clear();
            ListBoxPicture.Items.AddRange(pictureListDTO.PictureNames.ToArray());
        }
    }
}
