using System.Collections.Generic;


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
         void TransferToBuffer();
         void TransferToFigure();
         void Clear();
        string GetJson();
        void SetJson(string jsonText);
    }
}
