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
        private List<IDrawable> _buffer;
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
                //_count--;
                _figures.RemoveAt(position); // bag
                _figuresNames.RemoveAt(position);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        //public void TransferToBuffer() //UNDO
        //{
        //    if (_figures.Count != 0)
        //    {
        //        if (_buffer == null)
        //        {
        //            _buffer = new List<IDrawable>();
        //        }
        //        _buffer.Add(_figures[^1]);
        //        _figures.RemoveAt(_count - 1);
        //        _figuresNames.RemoveAt(_count - 1);
        //    }
        //}

        //public void TransferToFigure() //REDO
        //{
        //    if (_figures.Count != 0)
        //    {
        //        _figures.Add(_buffer[^1]);
        //        _count++;
        //        _buffer.RemoveAt(_buffer.Count - 1);
        //    }
        //}

        public void Clear()
        {
            _count = 0;
            _figures.Clear();
            _buffer.Clear();
            _figuresNames.Clear();
        }
    }
}
