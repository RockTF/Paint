using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using NewPaitnt.Vector;
using NewPaitnt.VectorModel;

namespace NewPaitnt.Implementation
{
    public class DrawingEngine
    {
        private static DrawingEngine _drawingEngine;
        // Остальные компоненты СинглТоны
        private Settings _settings;
        private Storage _storage;
        private PenPreview _penPreview;
        private Service _service;
        // Отслеживание мыши
        private Point _click;
        private Point _previousMove;
        private Point _move;
        private Point _rightClick;
        // Графика
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


        private DrawingEngine(int penBoxWidth, int penBoxHeight)
        {
            _settings = Settings.Initialize();
            _storage = Storage.Initialize();
            _penPreview = PenPreview.Initialize(_settings.Pen, penBoxWidth, penBoxHeight);
            _service = Service.Initialize();

            _click = new Point(0, 0);
            _previousMove = new Point(0, 0);
            _move = new Point(0, 0);
            _rightClick = new Point(0, 0);

            MainImage = new Bitmap(_settings.ImageWidth, _settings.ImageHeight);
            Background = new Bitmap(_settings.ImageWidth, _settings.ImageHeight);
            CurrentFigure = new Bitmap(_settings.ImageWidth, _settings.ImageHeight);
            Foreground = new Bitmap(_settings.ImageWidth, _settings.ImageHeight);
            MainGraphics = Graphics.FromImage(MainImage);
            BackgroundGraphics = Graphics.FromImage(Background);
            FigureGraphics = Graphics.FromImage(CurrentFigure);
            ForegroundGraphics = Graphics.FromImage(Foreground);
            MainGraphics.Clear(Color.White);

            _selectedFigureIndex = -1;
        }

        public static DrawingEngine Initialize(int penBoxWidth, int penBoxHeight)
        {
            if (_drawingEngine == null)
            {
                _drawingEngine = new DrawingEngine(penBoxWidth, penBoxHeight);
            }
            return _drawingEngine;
        }

        public void ClearCanvas()
        {
            // Чистим список фигур и графику
            _storage.Clear();
            MainGraphics.Clear(Color.White);
            BackgroundGraphics.Clear(BlackTransparrent);
            FigureGraphics.Clear(BlackTransparrent);
            ForegroundGraphics.Clear(BlackTransparrent);
        }

        public void CreateFigure() //!!! Вынести в шейп фактори 
        {
            switch (_settings.Mode)
            {
                case EFigure.Dot:
                    // Добавляем новую соответствующую фигуру в список
                    _storage.AddFigure(new Dot(_click, _settings.Pen, _settings.SmoothingMode));
                    break;
                case EFigure.Line:
                    // Добавляем новую соответствующую фигуру в список
                    _storage.AddFigure(new Line(_previousMove, _move, _settings.Pen, _settings.SmoothingMode));
                    break;
                          case EFigure.Rectangle:
                    // Добавляем новую соответствующую фигуру в список
                    _storage.AddFigure(new VectorModel.Rectangle(_previousMove, _move, _settings.Pen, _settings.SmoothingMode));
                    break;
                case EFigure.Triangle:
                    // Добавляем новую соответствующую фигуру в список
                    _storage.AddFigure(new VectorModel.Triangle(_previousMove, _move, _settings.Pen, _settings.SmoothingMode));
                    break;
                case EFigure.Ellipse:
                    // Добавляем новую соответствующую фигуру в список
                    _storage.AddFigure(new VectorModel.Ellipse(_previousMove, _move, _settings.Pen, _settings.SmoothingMode));
                    break;
                case EFigure.RoundedRectangle:
                    // Добавляем новую соответствующую фигуру в список
                    _storage.AddFigure(new VectorModel.RoundedRectangle(_previousMove, _move, _settings.Pen, _settings.SmoothingMode));
                    break;
                case EFigure.Curve:
                    // Добавляем новую соответствующую фигуру в список
                    _storage.AddFigure(new Curve (_previousMove, _move, _settings.Pen, _settings.SmoothingMode));
                    break;

                default:
                    break;
            }
        }


        public void DrawAllFigures()
        {
            // Очищаем основное изображение
            MainGraphics.Clear(Color.White);
            // Отрисовываем на нем последовательно все что есть в списке фигур
            foreach (var figure in _storage.Figures)
            {
                figure.Draw(ref MainGraphics);
            }
        }

        // Расписан ниже самый распространенный случай
        public void SelectFigure()
        {
            if (_selectedFigureIndex == 0)
            {
                MainGraphics.Clear(Color.White);

                BackgroundGraphics.Clear(BlackTransparrent);

                FigureGraphics.Clear(BlackTransparrent);
                _storage.Figures[_selectedFigureIndex].Draw(ref FigureGraphics);

                ForegroundGraphics.Clear(BlackTransparrent);
                for (int i = _selectedFigureIndex + 1; i < _storage.Figures.Count; i++)
                {
                    _storage.Figures[i].Draw(ref ForegroundGraphics);
                }

                MainGraphics.DrawImage(Background, 0, 0);
                MainGraphics.DrawImage(CurrentFigure, 0, 0);
                MainGraphics.DrawImage(Foreground, 0, 0);
            }
            else if (_selectedFigureIndex == _storage.Figures.Count - 1)
            {
                MainGraphics.Clear(Color.White);

                BackgroundGraphics.Clear(BlackTransparrent);
                for (int i = 0; i < _selectedFigureIndex; i++)
                {
                    _storage.Figures[i].Draw(ref BackgroundGraphics);
                }

                FigureGraphics.Clear(BlackTransparrent);
                _storage.Figures[_selectedFigureIndex].Draw(ref FigureGraphics);

                ForegroundGraphics.Clear(BlackTransparrent);

                MainGraphics.DrawImage(Background, 0, 0);
                MainGraphics.DrawImage(CurrentFigure, 0, 0);
                MainGraphics.DrawImage(Foreground, 0, 0);
            }
            else
            {
                // Очищаем основное изображение
                MainGraphics.Clear(Color.White);
                // Отрисовиваем все фигуры ниже выделенной на отдельном прозрачном изображении
                BackgroundGraphics.Clear(BlackTransparrent);
                for (int i = 0; i < _selectedFigureIndex; i++)
                {
                    _storage.Figures[i].Draw(ref BackgroundGraphics);
                }
                // Отрисовываем текущую фигуру на отдельном прозрачном изображении
                FigureGraphics.Clear(BlackTransparrent);
                _storage.Figures[_selectedFigureIndex].Draw(ref FigureGraphics);
                // Отрисовываем все фигуры выше выделенной на отдельном прозрачном изображении
                ForegroundGraphics.Clear(BlackTransparrent);
                for (int i = _selectedFigureIndex + 1; i < _storage.Figures.Count; i++)
                {
                    _storage.Figures[i].Draw(ref ForegroundGraphics);
                }
                // Совмещаем все три созданных изображения на основном
                MainGraphics.DrawImage(Background, 0, 0);
                MainGraphics.DrawImage(CurrentFigure, 0, 0);
                MainGraphics.DrawImage(Foreground, 0, 0);
            }
        }

        public void MoveFigure()
        {
            MainGraphics.Clear(Color.White);
            FigureGraphics.Clear(BlackTransparrent);
            _storage.Figures[_selectedFigureIndex].Move(_previousMove, _move);
            _storage.Figures[_selectedFigureIndex].Draw(ref FigureGraphics);

            MainGraphics.DrawImage(Background, 0, 0);
            MainGraphics.DrawImage(CurrentFigure, 0, 0);
            MainGraphics.DrawImage(Foreground, 0, 0);
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
            return _storage.FiguresNames.ToArray();
        }

        // Метод для перерисовки выделенной фигуры при каком либо изменении ее свойств
        public void RedrawFigure()
        {
            _storage.Figures[_storage.Figures.Count -1].Draw(ref FigureGraphics, _move);

        }

        public void DrawFigure()
        {
            _storage.Figures[_storage.Figures.Count - 1].Draw(ref FigureGraphics);

        }

        public void NewClick(Point click)
        {
            _click = click;
            _previousMove = click;
            _move = click;
        }
        public void NewMove(Point move)
        {
            _previousMove = _move;
            _move = move;
        }
        public void NewRightClick(Point rightClick)
        {
            _rightClick = rightClick;
        }
        public Bitmap GetPenImage()
        {
            _penPreview.Refresh(_settings.Pen, _settings.SmoothingMode);
            return _penPreview.PenBitmap;
        }
        public void SetPenWidth(float newWidth)
        {
            _settings.SetPenWidth(newWidth);
            _penPreview.Refresh(_settings.Pen, _settings.SmoothingMode);
        }
        public void SetPenColor(Color color)
        {
            _settings.SetPenColor(color);
            _penPreview.Refresh(_settings.Pen, _settings.SmoothingMode);
        }
        public void SetMode(EFigure newMode)
        {
            _settings.SetMode(newMode);
        }
        public void SetSmoothingMode(SmoothingMode newMode)
        {
            _settings.SetSmoothingMode(newMode);
            MainGraphics.SmoothingMode = _settings.SmoothingMode;
            // Нужно будет доработать
        }
        public EFigure GetMode()
        {
            return _settings.Mode;
        }

        public void SetSelectedFigure(int figureIndex)
        {
            _selectedFigureIndex = figureIndex;
        }
    }
}