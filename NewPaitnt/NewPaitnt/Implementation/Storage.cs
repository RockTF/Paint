using NewPaitnt.Interfaces;
using System.Collections.Generic;

namespace NewPaitnt.Implementation
{
    public class Storage
    {
        private static Storage _storage;
        public List<IDrawable> Figures { get; private set; }
        public List<string> FiguresNames { get; private set; }
        private Storage()
        {
            Figures = new List<IDrawable>();
            FiguresNames = new List<string>();
        }
        public static Storage Initialize()
        {
            if (_storage == null)
            {
                _storage = new Storage();
            }
            return _storage;
        }
        public void AddFigure(IDrawable figure)
        {
            Figures.Add(figure);
            FiguresNames.Add(figure.FigureName);
        }
        public void RemoveFigureAt(int position)
        {
            Figures.RemoveAt(position);
            FiguresNames.RemoveAt(position);
        }

        public void Clear()
        {
            Figures.Clear();
            FiguresNames.Clear();
        }
    }
}
