using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPaitnt.Interfaces
{
    interface IStorage
    {
        public void AddFigure(IDrawable figure);
        public IDrawable GetFigure(int position);
        public List<IDrawable> GetAllFigures();
        public string GetFigureName(int position);
        public List<string> GetFiguresNames();
        public void RemoveFigureAt(int position);
        public void Clear();
    }
}
