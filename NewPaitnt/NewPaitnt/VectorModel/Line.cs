﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPaitnt.Vector
{
    public class Line : Figure, IDrawable
    {
        public override List<Point> Points { get ; set ; }
        public override Pen Pen { get; set ; }
        public override Brush Brush { get; set; }
        public Graphics FigureGraphics { get; set; }

        public void CalculateLine()
        {
            Points.Add(new Point(Xclick, Yclick));
            Points.Add(new Point(Xmove, Ymove));
        } 

        public void Draw()
        {
            FigureGraphics.DrawLines(Pen, Points.ToArray());
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void Refresh()
        {
            throw new NotImplementedException();
        }

        public void Resize()
        {
            throw new NotImplementedException();
        }
    }
}