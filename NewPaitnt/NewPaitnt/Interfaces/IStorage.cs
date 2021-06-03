using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPaitnt.Interfaces
{
    public interface IStorage
    {
         void AddFigure(IDrawable figure);
         IDrawable GetFigure(int position);
         IDrawable GetLastFigure();
         List<IDrawable> GetAllFigures();
         string GetFigureName(int position);
         List<string> GetFiguresNames();
         void RemoveFigureAt(int position);
         int GetCount();
         //void TransferToBuffer();
         //void TransferToFigure();
         void Clear();
    }
}
