using System;
using NewPaitnt.Interfaces;
using System.Collections.Generic;

namespace NewPaitnt.Implementation
{
    public class Storage : IStorage
    {
        private static Storage _storage;
        

        private int _count;
        private List<IDrawable> _figures;
        private List<IDrawable> _history;
        private List<string> _figuresNames;

        private Storage()
        {
            _count = 0;
            _figures = new List<IDrawable>();
            _figuresNames = new List<string>();

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
            _count++;
            _figures.Add(figure);
            _figuresNames.Add(figure.FigureName);
        }
        public IDrawable GetFigure(int position)
        {
            if (position >= 0 && position < _figures.Count)
            {
                return _figures[position];
            }
            else
            {
               throw new IndexOutOfRangeException(); 
            }
        }
        public IDrawable GetLastFigure()
        {
            return _figures[_count - 1];
        }
        public List<IDrawable> GetAllFigures()
        {
            return _figures;
        }
        public string GetFigureName(int position)
        {
            if (position >= 0 && position < _figures.Count)
            {
                return _figuresNames[position];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        public List<string> GetFiguresNames()
        {
            return _figuresNames;
        }
        public int GetCount()
        {
            return _count;
        }
        public void RemoveFigureAt(int position)
        {
            if (position >= 0 && position <= _figures.Count)
            {
                _count--;
                _figures.RemoveAt(position);
                _figuresNames.RemoveAt(position);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        public void Clear()
        {
            _count = 0;
            _figures.Clear();
            _figuresNames.Clear();
        }
    }
}
