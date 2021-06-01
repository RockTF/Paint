using NewPaitnt.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPaitnt.VectorModel
{
    public abstract class Figure: IDrawable 
    {
        public List<Point> Points { get; set; }
        public  Pen  Pen { get; set; }
        public  Brush Brush { get; set; }

     /*   public int Xclick { get; set; }
        public int Yclick { get; set; }
        public int Xmove { get; set; }
        public int Ymove { get; set; }
        public int Xstart { get; set; }
        public int Ystart { get; set; }
        public int Xend { get; set; }
        public int Yend { get; set; }*/

        public string FigureName { get; set; }

        public SmoothingMode SmoothingMode { get; set; }


   /*     public void CalculateCoordinates(int Xcurrent, int Ycurrent)
        {
            Xstart = (Xclick < Xcurrent) ? Xclick : Xcurrent;
            Xend = (Xclick < Xcurrent) ? Xcurrent : Xclick;
            Ystart = (Yclick < Ycurrent) ? Yclick : Ycurrent;
            Yend = (Yclick < Ycurrent) ? Ycurrent : Yclick;
        }
        public Rectangle GetRectangel()
        {
            int width = Math.Abs(Xend - Xstart);
            int height = Math.Abs(Yend - Ystart);
            Rectangle rect = new System.Drawing.Rectangle(Xstart, Ystart, width, height);

            return rect;
        }*/
        public abstract void Draw(ref Graphics graphics);
        public abstract void Refresh(ref Graphics graphics);
        public void Move(Point from, Point to)
        {
            for (int i = 0; i < Points.Count; i++)
            {
                int tempX = Points[i].X + (to.X - from.X);
                int tempY = Points[i].Y + (to.Y - from.Y);
                Points[i] = new Point(tempX, tempY);
            }
        }

       
        public void Selest()
        {
            
        }

        public void Deselect()
        {
           
        }

        
        public void RefreshBrush()
        {
            
        }

        public void ChangePen(Pen pen)
        {
            Pen = (Pen)pen.Clone();
        }

        public abstract void Draw(ref Graphics graphics, Point end);
        
    }
}
