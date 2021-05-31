using NewPaitnt.Implementation;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using Button = System.Windows.Forms.Button;

namespace NewPaitnt
{
    public partial class MainPaint : Form
    {
        Process currentProcess;
        Settings settings;
        bool IsBtnFillClicked;
        DrawingEngine drawingEngine;
        private bool _isFigureCreated;

        public MainPaint()
        {
            InitializeComponent();
           
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        private void MainPaint_Load(object sender, EventArgs e)
        {
            drawingEngine = DrawingEngine.Initialize(PictureBoxThickness.Width, PictureBoxThickness.Height);

            PictureBoxThickness.Image = drawingEngine.GetPenImage();
            PictureBoxPaint.Image = drawingEngine.MainImage;

            currentProcess = Process.GetCurrentProcess();
            currentProcess.Refresh();
            memoryLabel.Text = "Memory usage: " + ((float)currentProcess.PrivateMemorySize64 / 1024f / 1024f).ToString("F1") + " MB";

            IsBtnFillClicked = false;

            _isFigureCreated =false;
            // Антон ещё меняет
            //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //DoubleBuffered = true;

            // Set the value of the double-buffering style bits to true.
            this.SetStyle(ControlStyles.DoubleBuffer |
               ControlStyles.UserPaint |
               ControlStyles.AllPaintingInWmPaint,
               true);
            this.UpdateStyles();

            settings = Settings.Initialize();
        }

        private void PictureBoxPaint_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                drawingEngine.DrawMainOnBackground();
                drawingEngine.NewClick(e.Location);

                if(drawingEngine.GetMode() == EFigure.Dot)
                {
                    _isFigureCreated = true;

                    drawingEngine.CreateFigure();
                    drawingEngine.DrawBackgroundOnMain();
                    drawingEngine.CleanFigure();
                    drawingEngine.DrawFigure();
                    drawingEngine.DrawFigureOnMain();
                }
                else if(drawingEngine.GetMode() == EFigure.Move)
                {
                    drawingEngine.SelectFigure();
                }
               
                PictureBoxPaint.Image = drawingEngine.MainImage;
                
            }
        }

        private void PictureBoxPaint_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && drawingEngine.GetMode() != EFigure.Dot && drawingEngine.GetMode() != EFigure.Move)
            {
                drawingEngine.NewMove(e.Location);

                //if (drawingEngine.GetMode() != EFigure.Dot)
                //{
                //    drawingEngine.CreateFigure();
                //    _isFigureCreated = true;
                //}

                if (!_isFigureCreated)
                {
                    _isFigureCreated = true;

                    drawingEngine.CreateFigure();
                    drawingEngine.DrawBackgroundOnMain();
                    drawingEngine.CleanFigure();
                    drawingEngine.DrawFigure();
                    drawingEngine.DrawFigureOnMain();

                }
                else
                {
                    drawingEngine.DrawBackgroundOnMain();
                    drawingEngine.CleanFigure();
                    drawingEngine.RedrawFigure();
                    drawingEngine.DrawFigureOnMain();
                }

                PictureBoxPaint.Image = drawingEngine.MainImage;
            }
            else if (e.Button == MouseButtons.Left && drawingEngine.GetMode() == EFigure.Move)
            {
                drawingEngine.NewMove(e.Location);

                drawingEngine.MoveFigure();

                PictureBoxPaint.Image = drawingEngine.MainImage;
            }
        }

        private void PictureBoxPaint_MouseUp(object sender, MouseEventArgs e)
        {
            _isFigureCreated = false;
            drawingEngine.CleanBackground();
            //currentProcess.Refresh();
            //memoryLabel.Text = "Memory usage: " + ((float)currentProcess.PrivateMemorySize64 / 1024f / 1024f).ToString("F1") + " MB";
            //mouseHandeler.MouseUp(sender, e);
            //pictureBoxPaint.Image = drawingEngine.MainImage;
            FiguresListBox.Items.Clear();
            FiguresListBox.Items.AddRange(drawingEngine.GetFigureList());

        }


        // кнопок и методов нет - оставила для Наташи

        private void MenuSave_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "JPG Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|PNG Image|*.png";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (PictureBoxPaint != null)
                {
                    PictureBoxPaint.Image.Save(saveFileDialog.FileName);
                }
            }
        }
        private void MenuOpen_Click(object sender, EventArgs e) // очищвется при рисовании нужно добавлять в лист????
        {
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "JPG Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|PNG Image|*.png";

            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
               PictureBoxPaint.Image = Image.FromFile(openFileDialog.FileName); 
                

            }
        }

        private void MenuClear_Click(object sender, EventArgs e) //очищать лист при вызове метода
        {
            drawingEngine.ClearCanvas();
            PictureBoxPaint.Image = drawingEngine.MainImage;
        }


        private void TrackBarThickness_Scroll(object sender, EventArgs e)
        {
            drawingEngine.SetPenWidth(TrackBarThickness.Value);
            PictureBoxThickness.Image = drawingEngine.GetPenImage();
        }

        // кнопки цвет больше нет, метод надо менять 
        //private void BtnColor_Click(object sender, EventArgs e)
        //{
        //    if (colorDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        Settings.Pen.Color = colorDialog1.Color;
        //        btnColor.BackColor = colorDialog1.Color;
        //        PenPreview.Refresh();
        //        pictureBoxPen.Image = PenPreview.PenBitmap;
        //    }
        //}

        

        private void BtnRectangle_Click(object sender, EventArgs e)
        {
            drawingEngine.SetMode(EFigure.Rectangle);
        }

        private void BtnEllipse_Click(object sender, EventArgs e)
        {
            drawingEngine.SetMode(EFigure.Ellipse);
        }

        private void BtnFill_Click(object sender, EventArgs e)
        {
            IsBtnFillClicked = true;
        }

        private void BtnPoint_Click(object sender, EventArgs e)
        {
            drawingEngine.SetMode(EFigure.Dot);
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            //DrawingEngine.Undo();
            //PictureBoxPaint.Image = DrawingEngine.MainImage;
        }

        private void BtnRedo_Click(object sender, EventArgs e)
        {
            //DrawingEngine.Redo();
            //PictureBoxPaint.Image = DrawingEngine.MainImage;
        }

        private void BtnCurve_Click(object sender, EventArgs e)
        {
            drawingEngine.SetMode(EFigure.Curve); 
        }

        private void BtnTriangle_Click(object sender, EventArgs e)
        {
            drawingEngine.SetMode(EFigure.Triangle);
        }

        private void BtnLine_Click(object sender, EventArgs e)
        {
            drawingEngine.SetMode(EFigure.Line);
        }

        private void SmoothCorve(object sender, EventArgs e)
        {
            //Mode = EFigure.SmoothCorv;
        }

        private void CheckBoxAntiAliasing_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxAntiAliasing.Checked)
            {
               drawingEngine.SetSmoothingMode(SmoothingMode.AntiAlias);
            }
            else
            {
                drawingEngine.SetSmoothingMode(SmoothingMode.None);
            }
            PictureBoxThickness.Image = drawingEngine.GetPenImage();
        }

        private void ComboBoxContour_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ComboBoxContour.SelectedIndex)
            {
                case 0:
                    settings.Pen.DashStyle = DashStyle.Solid;
                    break;
                case 1:
                    settings.Pen.DashStyle = DashStyle.Dash;
                    break;
                case 2:
                    settings.Pen.DashStyle = DashStyle.DashDot;
                    break;
                default:
                    break;
            }
        }

        private void PictureBoxPaint_Click(object sender, EventArgs e)
        {

        }

        //private void UpdateShapeListComboBox()
        //{
        //    this.cb_shapeList.DataSource = null;
        //    this.cb_shapeList.DataSource = this.shapesList;
        //    this.cb_shapeList.SelectedIndex = this.shapesList.Count - 1;
        //}

        //private void BufferToCanvas()
        //{
        //    this.DrawShapesToBuffer();
        //    this.bgGraph.Render(this.canvas.CreateGraphics());
        //}

        private void button1_Click(object sender, EventArgs e)
        {

            //MyFill currentFill = null;
            //if (e.Button == System.Windows.Forms.MouseButtons.Left)
            //{
            //    currentFill = new MyFill(e.Location, this.colorChoicer.BColor);
            //}
            //this.shapesList.Add(currentFill);

            //this.UpdateShapeListComboBox();

            //this.BufferToCanvas();

            //if (this.cb_shapeList.SelectedIndex == -1 || this.shapesList.Count == 0)
            //{
            //    return;
            //}


        }

        private void BtnSguare_Click(object sender, EventArgs e)
        {
            drawingEngine.SetMode(EFigure.RoundedRectangle);
        }

        private void Color_btn(object sender, EventArgs e)
        {

            drawingEngine.SetPenColor(((Button)sender).BackColor);
            PictureBoxColorFillFigure.BackColor = ((Button)sender).BackColor;

        }

        private void PictureBoxColors_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                drawingEngine.SetPenColor (colorDialog1.Color);
                PictureBoxColorFillFigure.BackColor = colorDialog1.Color;
             
           }
        }
        private void MenuCreate_Click(object sender, EventArgs e) //очищать лист при вызове метода
        {
            CreateNewCanvas createNewCanvas = (CreateNewCanvas)Application.OpenForms["CreateNewCanvas"];
            if (createNewCanvas == null)
            {
                createNewCanvas = new CreateNewCanvas();
                createNewCanvas.Show();
            }
            else
            {
                createNewCanvas.Activate();
            }
        }

        private void FiguresListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            drawingEngine.SetSelectedFigure((sender as ListBox).SelectedIndex);
        }

        private void BtnMove_Click(object sender, EventArgs e)
        {
            drawingEngine.SetMode(EFigure.Move);
        }
    }
}