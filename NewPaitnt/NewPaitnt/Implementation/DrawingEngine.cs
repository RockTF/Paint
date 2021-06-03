﻿using System.Drawing;
using System.Drawing.Drawing2D;
using NewPaitnt.Interfaces;
using NewPaitnt.Vector;
using NewPaitnt.VectorModel;

namespace NewPaitnt.Implementation
{
    public class DrawingEngine
    {
        //private static DrawingEngine _drawingEngine;
        // Компоненты СинглТоны
        private Settings _settings;
        private MouseHandler _mouseHandler;
        private PenPreview _penPreview;
        private IStorage _storage;
        private Service _service;
              
        // Графика
        public Bitmap Canvas;
        public Bitmap MainImage;
        private Bitmap Background;
        private Bitmap CurrentFigure;
        private Bitmap Foreground;
        private Color BlackTransparrent = Color.FromArgb(0, 0, 0, 0);
        private Graphics MainGraphics;
        private Graphics BackgroundGraphics;
        private Graphics FigureGraphics;
        private Graphics ForegroundGraphics;
        
        // Внутренние приватные переменные
        private int _selectedFigureIndex;

        public DrawingEngine(Settings settings, MouseHandler mouseHandler, PenPreview penPreview, IStorage storage, Service service)
        {
            _settings = settings;
            _mouseHandler = mouseHandler;
            _penPreview = penPreview;
            _storage = storage;
            _service = service;

            NewBitmaps();
            MainGraphics.Clear(Color.White);
            Canvas = (Bitmap)MainImage.Clone();

            _selectedFigureIndex = -1;
        }

        public void ClearCanvas()
        {
            _storage.Clear();
            ClearLayers(Color.White);
            Canvas = (Bitmap)MainImage.Clone();
        }

        public void CreateFigure() //!!! Вынести в шейп фактори Совет от Кати - сделать енам
        {
            switch (_settings.Mode)
            {
                case EFigure.Dot:
                    // Добавляем новую соответствующую фигуру в список
                    _storage.AddFigure(new Dot(_mouseHandler.GetClick(), _settings.Pen, _settings.SmoothingMode));
                    break;
                case EFigure.Line:
                    // Добавляем новую соответствующую фигуру в список
                    _storage.AddFigure(new Line(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove(), _settings.Pen, _settings.SmoothingMode));
                    break;
                case EFigure.Rectangle:
                    // Добавляем новую соответствующую фигуру в список
                    _storage.AddFigure(new VectorModel.Rectangle(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove(), _settings.Pen, _settings.SmoothingMode));
                    break;
                case EFigure.Triangle:
                    // Добавляем новую соответствующую фигуру в список
                    _storage.AddFigure(new VectorModel.Triangle(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove(), _settings.Pen, _settings.SmoothingMode));
                    break;
                case EFigure.Ellipse:
                    // Добавляем новую соответствующую фигуру в список
                    _storage.AddFigure(new Ellipse(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove(), _settings.Pen, _settings.SmoothingMode));
                    break;
                case EFigure.RoundedRectangle:
                    // Добавляем новую соответствующую фигуру в список
                    _storage.AddFigure(new VectorModel.RoundedRectangle(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove(), _settings.Pen, _settings.SmoothingMode));
                    break;
                case EFigure.Curve:
                    // Добавляем новую соответствующую фигуру в список
                    _storage.AddFigure(new Curve(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove(), _settings.Pen, _settings.SmoothingMode));
                    break;
                case EFigure.SmoothCurve:
                    _storage.AddFigure(new SmoothCurve(_mouseHandler.GetClick(), _mouseHandler.GetMove(), _settings.Pen, _settings.SmoothingMode));
                    break;
                case EFigure.Polygon:
                    _storage.AddFigure(new Polygon(_mouseHandler.GetClick(), _mouseHandler.GetMove(), _settings.numberOfPolygonApexes, _settings.Pen, _settings.SmoothingMode));
                    break;
                default:
                    break;
            }
        }

        public void DrawAllFigures()
        {
            // Очищаем основное изображение
            MainGraphics.DrawImage(Canvas, 0, 0);
            // Отрисовываем на нем последовательно все что есть в списке фигур
            foreach (var figure in _storage.GetAllFigures())
            {
                figure.Draw(ref MainGraphics);
            }
        }

        public void SelectFigure()
        {
            if (_selectedFigureIndex == 0)
            {
                ClearLayers();
                DrawSelectedFigure();
                DrawFigureSequence(_selectedFigureIndex + 1, _storage.GetCount());
                DrawLayers();
            }
            else if (_selectedFigureIndex == _storage.GetCount() - 1)
            {
                ClearLayers();
                DrawFigureSequence(0, _selectedFigureIndex);
                DrawSelectedFigure();
                DrawLayers();
            }
            else
            {
                ClearLayers();
                DrawFigureSequence(0, _selectedFigureIndex);
                DrawSelectedFigure();
                for (int i = _selectedFigureIndex + 1; i < _storage.GetCount(); i++)
                DrawFigureSequence(_selectedFigureIndex + 1, _storage.GetCount());
                DrawLayers();
            }
        }

        public void MoveFigure()
        {
            if (_selectedFigureIndex >= 0)
            {
                MainGraphics.DrawImage(Canvas, 0, 0);
                FigureGraphics.Clear(BlackTransparrent);
                _storage.GetFigure(_selectedFigureIndex).Move(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove());
                _storage.GetFigure(_selectedFigureIndex).Draw(ref FigureGraphics);
                DrawLayers();
            }
        }
        public void DeleteFigure()
        {
            if (_selectedFigureIndex >= 0)
            {
                MainGraphics.DrawImage(Canvas, 0, 0);
                FigureGraphics.Clear(BlackTransparrent);
                _storage.RemoveFigureAt(_selectedFigureIndex);                
                DrawAllFigures();
            }
        }

        public void DrawMainOnBackground()
        {
            BackgroundGraphics.DrawImage(MainImage, 0, 0);
        }

        public void DrawBackgroundOnMain()
        {
            MainGraphics.DrawImage(Background, 0, 0);
        }

        public void CleanBackground()
        {
            BackgroundGraphics.Clear(BlackTransparrent);
        }

        public void CleanFigure()
        {
            FigureGraphics.Clear(BlackTransparrent);
        }

        public void DrawFigureOnMain()
        {
            MainGraphics.DrawImage(CurrentFigure, 0, 0);
        }

        public string[] GetFigureList() 
        {
            return _storage.GetFiguresNames().ToArray();
        }

        // Метод для перерисовки выделенной фигуры при каком либо изменении ее свойств
        public void RedrawFigure()
        {
            _storage.GetLastFigure().Draw(ref FigureGraphics, _mouseHandler.GetMove());
        }

        public void DrawFigure()
        {
            _storage.GetLastFigure().Draw(ref FigureGraphics);
        }


        public Bitmap GetPenImage()
        {
            _penPreview.Refresh(_settings.Pen, _settings.SmoothingMode);
            return _penPreview.PenBitmap;
        }

        public EFigure GetMode()
        {
            return _settings.Mode;
        }

        public void SetSelectedFigure(int figureIndex)
        {
            _selectedFigureIndex = figureIndex;
        }

        private void ClearLayers()
        {
            MainGraphics.DrawImage(Canvas, 0, 0);
            BackgroundGraphics.Clear(BlackTransparrent);
            FigureGraphics.Clear(BlackTransparrent);
            ForegroundGraphics.Clear(BlackTransparrent);
        }

        public void ClearAllExceptMainImage()
        {
            MainGraphics.DrawImage(Canvas, 0, 0);
            BackgroundGraphics.Clear(BlackTransparrent);
            FigureGraphics.Clear(BlackTransparrent);
            ForegroundGraphics.Clear(BlackTransparrent);
            DrawAllFigures();
        }

        private void ClearLayers(Color color)
        {
            MainGraphics.Clear(color);
            BackgroundGraphics.Clear(BlackTransparrent);
            FigureGraphics.Clear(BlackTransparrent);
            ForegroundGraphics.Clear(BlackTransparrent);
        }

        private void DrawLayers()
        {
            MainGraphics.DrawImage(Background, 0, 0);
            MainGraphics.DrawImage(CurrentFigure, 0, 0);
            MainGraphics.DrawImage(Foreground, 0, 0);
        }

        private void DrawSelectedFigure()
        {
            if (_selectedFigureIndex >= 0)
            {
                _storage.GetFigure(_selectedFigureIndex).Draw(ref FigureGraphics);
            }
        }

        private void DrawFigureSequence(int startIndex, int endIndex)
        {
            for (int i = startIndex; i < endIndex; i++)
            {
                _storage.GetFigure(i).Draw(ref ForegroundGraphics);
            }
        }

        public void ClearStorage()
        {
            _storage.Clear();
        }
        public void NewImageSize()
        {
            NewBitmaps();
            MainGraphics.Clear(Color.White);
            Canvas = (Bitmap)MainImage.Clone();
            ClearCanvas();
        }
        public void DrawNewFigure()
        {
            CreateFigure();
            DrawBackgroundOnMain();
            CleanFigure();
            DrawFigure();
            DrawFigureOnMain();
        }
        public void RedrawNewFigure()
        {
            DrawBackgroundOnMain();
            CleanFigure();
            RedrawFigure();
            DrawFigureOnMain();
        }

        public void AddPointToCurve(Point click)
        {
            _storage.GetLastFigure().AddNextPoint(click);
        }

        public void NewBitmaps()
        {
            Canvas = new Bitmap(_settings.ImageWidth, _settings.ImageHeight);
            MainImage = new Bitmap(_settings.ImageWidth, _settings.ImageHeight);
            Background = new Bitmap(_settings.ImageWidth, _settings.ImageHeight);
            CurrentFigure = new Bitmap(_settings.ImageWidth, _settings.ImageHeight);
            Foreground = new Bitmap(_settings.ImageWidth, _settings.ImageHeight);

            MainGraphics = Graphics.FromImage(MainImage);
            BackgroundGraphics = Graphics.FromImage(Background);
            FigureGraphics = Graphics.FromImage(CurrentFigure);
            ForegroundGraphics = Graphics.FromImage(Foreground);
        }

    }
}