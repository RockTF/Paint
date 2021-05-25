using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPaitnt.Vector
{
    public class Curve : Figure, IDrawable
    {
        public override List<Point> Points { get; set; }
        public override Pen Pen { get; set; }
        public override Brush Brush { get; set; }
        public Graphics FigureGraphics { get; set; }

        public void CalculateCurve() // Найден баг - если рисовать очень активно, в какой то момент перестает рисовать,
                                     // а при отпускании кнопки мыши все оставшееся отрисовывается
        {
            if (Points.Count == 0)
            {
                // Добавляем кординаты клика (сохраненные на mouseDown) если список пустой
                Points.Add(new Point(Xclick, Yclick));
            }
            // На каджом перемещении мыши добавляем точку движения в список
            Points.Add(new Point(Xmove, Ymove));
            // Отрисовывем кривую по всем точкам в списке, список приводим к массиву
        }

        public void Draw()
        {
            FigureGraphics.DrawCurve(Pen, Points.ToArray());
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
