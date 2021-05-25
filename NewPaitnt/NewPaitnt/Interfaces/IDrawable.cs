using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPaitnt.Vector
{
   public interface IDrawable
   {
        Graphics FigureGraphics { get; set; }

        void Draw();
        void Refresh();
        void Move();
        void Resize();

   }
}
