using System.Collections.Generic;
using System.Drawing;

namespace NewPaitnt.Interfaces
{
    interface IGraphics
    {
        Bitmap Bitmap { get; }
        void Clear();
        void Clear(Color color);
        void Clear(Bitmap bitmap);
        void Draw(IDrawable figure);
        void Draw(List<IDrawable> figures);
    }
}
