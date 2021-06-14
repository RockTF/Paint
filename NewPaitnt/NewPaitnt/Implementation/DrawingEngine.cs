using System.Drawing;
using NewPaitnt.Enum;
using NewPaitnt.Interfaces;
using NewPaitnt.VectorModel;

namespace NewPaitnt.Implementation
{
    public class DrawingEngine
    {
        private Settings _settings;
        private IMouseHandler _mouseHandler;
        private IStorage _storage;              
        
        //public Bitmap Canvas;
        //public Bitmap MainImage;
        //private Bitmap Background;
        //private Bitmap CurrentFigure;
        //private Bitmap Foreground;
        private Color BlackTransparrent = Color.FromArgb(0, 0, 0, 0);
        private ExoGraphics CanvasGraphics;
        private ExoGraphics MainGraphics;
        private ExoGraphics BackgroundGraphics;
        private ExoGraphics FigureGraphics;
        private ExoGraphics ForegroundGraphics;
  
        private int _selectedFigureIndex; 

        public DrawingEngine(Settings settings, IMouseHandler mouseHandler, IStorage storage)
        {
            _settings = settings;
            _mouseHandler = mouseHandler;
            _storage = storage;

            NewBitmaps();
            MainGraphics.Clear(Color.White);
            CanvasGraphics.Clear(MainGraphics.Bitmap);

            _selectedFigureIndex = -1;
        }

        public void ClearCanvas()
        {
            _storage.Clear();
            ClearLayers(Color.White);
            CanvasGraphics.Clear(MainGraphics.Bitmap);
            _selectedFigureIndex = -1;
        }

        public void CreateFigure()
        {
            switch (_settings.Mode)
            {
                case EMode.Dot:
                    _storage.AddFigure(new Dot(_mouseHandler.GetClick(), _settings));
                    break;
                case EMode.Line:
                    _storage.AddFigure(new Line(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove(), _settings));
                    break;
                case EMode.Rectangle:
                    _storage.AddFigure(new VectorModel.Rectangle(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove(), _settings));
                    break;
                case EMode.Triangle:
                    _storage.AddFigure(new Triangle(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove(), _settings));
                    break;
                case EMode.Ellipse:
                    _storage.AddFigure(new Ellipse(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove(), _settings));
                    break;
                case EMode.RoundedRectangle:
                    _storage.AddFigure(new RoundedRectangle(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove(), _settings));
                    break;
                case EMode.Curve:
                    _storage.AddFigure(new Curve(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove(), _settings));
                    break;
                case EMode.SmoothCurve:
                    _storage.AddFigure(new SmoothCurve(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove(), _settings));
                    break;
                case EMode.Polygon:
                    _storage.AddFigure(new Polygon(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove(), _settings));
                    break;
                default:
                    break;
            }
        }

        public void DrawAllFigures()
        {
            MainGraphics.Clear(CanvasGraphics.Bitmap);
            MainGraphics.Draw(_storage.GetAllFigures());
        }

        public void SelectFigure()
        {
            var count = _storage.GetCount();

            if (_selectedFigureIndex == 0)
            {
                ClearLayers();
                DrawSelectedFigure();
                DrawFigureSequence(ref ForegroundGraphics, _selectedFigureIndex + 1, count);
                DrawLayers();
            }
            else if (_selectedFigureIndex == count - 1)
            {
                ClearLayers();
                DrawFigureSequence(ref BackgroundGraphics, 0, _selectedFigureIndex);
                DrawSelectedFigure();
                DrawLayers();
            }
            else
            {
                ClearLayers();
                DrawFigureSequence(ref BackgroundGraphics, 0, _selectedFigureIndex);
                DrawSelectedFigure();
                DrawFigureSequence(ref ForegroundGraphics, _selectedFigureIndex + 1, count);
                DrawLayers();
            }
        }

        public void MoveFigure()
        {
            if (_selectedFigureIndex >= 0)
            {
                MainGraphics.Clear(CanvasGraphics.Bitmap);
                FigureGraphics.Clear();
                _storage.GetFigure(_selectedFigureIndex).Move(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove());
                FigureGraphics.Draw(_storage.GetFigure(_selectedFigureIndex));
                DrawLayers();
            }
        }

        public void DeleteFigure()
        {
            if (_selectedFigureIndex >= 0)
            {
                MainGraphics.Clear(CanvasGraphics.Bitmap);
                FigureGraphics.Clear();
                _storage.RemoveFigureAt(_selectedFigureIndex);                
                DrawAllFigures();
            }
        }

        public void DrawMainOnBackground()
        {
            BackgroundGraphics.Clear(MainGraphics.Bitmap);
        }

        private void DrawBackgroundOnMain()
        {
            MainGraphics.Clear(BackgroundGraphics.Bitmap);
        }

        public void CleanBackground()
        {
            BackgroundGraphics.Clear();
        }

        private void CleanFigure()
        {
            FigureGraphics.Clear();
        }

        private void DrawFigureOnMain()
        {
            MainGraphics.Clear(FigureGraphics.Bitmap);
        }

        public string[] GetFigureList() 
        {
            return _storage.GetFiguresNames().ToArray();
        }

        public void RedrawFigure()
        {
            _storage.GetLastFigure().UpdatePoint(_mouseHandler.GetMove());
            FigureGraphics.Draw(_storage.GetLastFigure());
        }

        private void DrawFigure()
        {
            FigureGraphics.Draw(_storage.GetLastFigure());
        }

        public void SetSelectedFigure(int figureIndex)
        {
            _selectedFigureIndex = figureIndex;
        }

        private void ClearLayers()
        {
            MainGraphics.Clear(CanvasGraphics.Bitmap);
            BackgroundGraphics.Clear();
            FigureGraphics.Clear();
            ForegroundGraphics.Clear();
        }

        public void ClearAllExceptMainImage()
        {
            ClearLayers();
            DrawAllFigures();
        }

        private void ClearLayers(Color color)
        {
            MainGraphics.Clear(color);
            BackgroundGraphics.Clear();
            FigureGraphics.Clear();
            ForegroundGraphics.Clear();
        }

        private void DrawLayers()
        {
            MainGraphics.Clear(BackgroundGraphics.Bitmap);
            MainGraphics.Clear(FigureGraphics.Bitmap);
            MainGraphics.Clear(ForegroundGraphics.Bitmap);
        }

        private void DrawSelectedFigure()
        {
            if (_selectedFigureIndex >= 0)
            {
                FigureGraphics.Draw(_storage.GetFigure(_selectedFigureIndex));
            }
        }

        private void DrawFigureSequence(ref ExoGraphics graphics, int startIndex, int endIndex)
        {
            for (int i = startIndex; i < endIndex; i++)
            {
                graphics.Draw(_storage.GetFigure(i));
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
            CanvasGraphics.Clear(MainGraphics.Bitmap);
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

        public void Undo()
        {
            _storage.TransferToBuffer();
            DrawAllFigures();
        }

        public void Redo()
        {
            _storage.TransferToFigure();
            DrawAllFigures();
        }

        public void AddPointToCurve()
        {
            (_storage.GetLastFigure() as Figure).AddNextPoint(_mouseHandler.GetClick());
        }

        private void NewBitmaps()
        {
            CanvasGraphics = new ExoGraphics(_settings.ImageWidth, _settings.ImageHeight);
            MainGraphics = new ExoGraphics(_settings.ImageWidth, _settings.ImageHeight);
            BackgroundGraphics = new ExoGraphics(_settings.ImageWidth, _settings.ImageHeight);
            FigureGraphics = new ExoGraphics(_settings.ImageWidth, _settings.ImageHeight);
            ForegroundGraphics = new ExoGraphics(_settings.ImageWidth, _settings.ImageHeight);
        }

        public void UpdateFigure()
        {
            _storage.GetFigure(_selectedFigureIndex).Update(_settings);
        }

        public Bitmap GetMainImage()
        {
            return MainGraphics.Bitmap;
        }

        public void SetCanvasImage(Bitmap bitmap)
        {
            CanvasGraphics.Clear(bitmap);
        }
    }
}