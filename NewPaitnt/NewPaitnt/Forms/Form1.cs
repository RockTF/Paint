using NewPaitnt.Implementation;
using NewPaitnt.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewPaitnt
{
    public partial class mainPaint : Form
    {
        Process currentProcess;
        bool IsBtnFillClicked;
        public mainPaint()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "JPG(*.JPG)|*.jpg";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (pictureBoxPaint != null)
                {
                    pictureBoxPaint.Image.Save(saveFileDialog1.FileName);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            drawingEngine.ClearCanvas();
            pictureBoxPaint.Image = drawingEngine.MainImage;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //drawingEngine.Undo();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            settings.SetPenWidth(trackBar1.Value);
            penPreview.Refresh();
            pictureBoxPen.Image = penPreview.PenBitmap;
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                settings.SetPenColor(colorDialog1.Color);
                btnColor.BackColor = colorDialog1.Color;
                penPreview.Refresh();
                pictureBoxPen.Image = penPreview.PenBitmap;
            }
        }

        private void btnColor_Click_1(object sender, EventArgs e)
        {
            if (IsBtnFillClicked)
            {

                settings.SetBrushColor(((Button)sender).BackColor);
                btnColor.BackColor = ((Button)sender).BackColor;
                IsBtnFillClicked = false;
            }
            else
            {
                settings.SetPenColor(((Button)sender).BackColor);
                penPreview.Refresh();
                pictureBoxPen.Image = penPreview.PenBitmap;
            }

        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            settings.SetMode(DrawingEngine.Buttons.point); // возможно ENUM нужно вынести отдельно, так как нельзя вызвать его у обьекта
        }

        private void btnEllipse_Click(object sender, EventArgs e)
        {
            settings.SetMode(DrawingEngine.Buttons.ellipse);
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            IsBtnFillClicked = true;
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            settings.SetMode(DrawingEngine.Buttons.point);
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            //DrawingEngine.Undo();
            //pictureBoxPaint.Image = DrawingEngine.MainImage;
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            //DrawingEngine.Redo();
            //pictureBoxPaint.Image = DrawingEngine.MainImage;
        }

        private void btnCurve_Click(object sender, EventArgs e)
        {
            settings.SetMode(DrawingEngine.Buttons.curve);
        }

        private void comboBoxContour_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxContour.SelectedIndex)
            {
                case 0:
                    settings.SetPenDashStyle(DashStyle.Solid);
                    break;
                case 1:
                    settings.SetPenDashStyle(DashStyle.Dash);
                    break;
                case 2:
                    settings.SetPenDashStyle(DashStyle.DashDot);
                    break;
                default:
                    break;
            }
        }

        private void checkBoxAntiAliasing_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAntiAliasing.Checked)
            {
                settings.SetSmoothingMode(SmoothingMode.AntiAlias);
            }
            else
            {
                settings.SetSmoothingMode(SmoothingMode.None);
            }
            penPreview.Refresh();
            pictureBoxPen.Image = penPreview.PenBitmap;
        }

        private void btnTriangle_Click(object sender, EventArgs e)
        {
            settings.SetMode(DrawingEngine.Buttons.triangle);
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            settings.SetMode(DrawingEngine.Buttons.line);
        }

        private void SmoothCorve(object sender, EventArgs e)
        {
            settings.SetMode(DrawingEngine.Buttons.smoothCorv);
        }
    }
}