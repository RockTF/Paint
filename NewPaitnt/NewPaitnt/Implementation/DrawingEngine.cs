using System.Drawing;
using System.Drawing.Drawing2D;
using NewPaitnt.Interfaces;
using NewPaitnt.Vector;
using NewPaitnt.VectorModel;

namespace NewPaitnt.Implementation
{
    public class DrawingEngine
    {
        private Settings _settings;
        private MouseHandler _mouseHandler;
        private PenPreview _penPreview;
        private IStorage _storage;              
        
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
  
        private int _selectedFigureIndex;

        public DrawingEngine(Settings settings, MouseHandler mouseHandler, PenPreview penPreview, IStorage storage)
        {
            _settings = settings;
            _mouseHandler = mouseHandler;
            _penPreview = penPreview;
            _storage = storage;

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
                    _storage.AddFigure(new Dot(_mouseHandler.GetClick(), _settings.Pen, _settings.SmoothingMode));
                    break;
                case EFigure.Line:
                    _storage.AddFigure(new Line(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove(), _settings.Pen, _settings.SmoothingMode));
                    break;
                case EFigure.Rectangle:
                    // Добавляем новую соответствующую фигуру в список
                    _storage.AddFigure(new VectorModel.Rectangle(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove(), _settings.Pen, _settings.Brush, _settings.SmoothingMode));
                    break;
                case EFigure.Triangle:
                    // Добавляем новую соответствующую фигуру в список
                    _storage.AddFigure(new VectorModel.Triangle(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove(), _settings.Pen, _settings.Brush, _settings.SmoothingMode));
                    break;
                case EFigure.Ellipse:
                    // Добавляем новую соответствующую фигуру в список
                    _storage.AddFigure(new VectorModel.Ellipse(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove(), _settings.Pen, _settings.Brush, _settings.SmoothingMode));
                    break;
                case EFigure.RoundedRectangle:
                    // Добавляем новую соответствующую фигуру в список
                    _storage.AddFigure(new VectorModel.RoundedRectangle(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove(), _settings.Pen, _settings.Brush, _settings.SmoothingMode));
                    break;
                case EFigure.Curve:
                    _storage.AddFigure(new Curve(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove(), _settings.Pen, _settings.SmoothingMode));
                    break;
                case EFigure.SmoothCurve:
                    _storage.AddFigure(new SmoothCurve(_mouseHandler.GetClick(), _mouseHandler.GetMove(), _settings.Pen, _settings.SmoothingMode));
                    break;
                case EFigure.Polygon:
                    _storage.AddFigure(new Polygon(_mouseHandler.GetClick(), _mouseHandler.GetMove(), _settings.numberOfPolygonApexes, _settings.Pen, _settings.Brush, _settings.SmoothingMode));
                    break;
                default:
                    break;
            }
        }

        public void DrawAllFigures()
        {
            MainGraphics.DrawImage(Canvas, 0, 0);
            foreach (var figure in _storage.GetAllFigures())
            {
                figure.Draw(ref MainGraphics);
            }
        }

        public void SelectFigure()
        {
            var count = -_storage.GetCount();
            if (_selectedFigureIndex == 0)
            {
                ClearLayers();
                DrawSelectedFigure();
                DrawFigureSequence(_selectedFigureIndex + 1, count);
                DrawLayers();
            }
            else if (_selectedFigureIndex == count - 1)
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
                for (int i = _selectedFigureIndex + 1; i < count; i++)
                {
                    DrawFigureSequence(_selectedFigureIndex + 1, count);
                }
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

        public void SetSelectedFigure(int figureIndex)
        {
            _selectedFigureIndex = figureIndex;
        }

        public void ClearLayers()
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

        public void ClearLayers(Color color)
        {
            MainGraphics.Clear(color);
            BackgroundGraphics.Clear(BlackTransparrent);
            FigureGraphics.Clear(BlackTransparrent);
            ForegroundGraphics.Clear(BlackTransparrent);
        }

        public void DrawLayers()
        {
            MainGraphics.DrawImage(Background, 0, 0);
            MainGraphics.DrawImage(CurrentFigure, 0, 0);
            MainGraphics.DrawImage(Foreground, 0, 0);
        }

        public void DrawSelectedFigure()
        {
            if (_selectedFigureIndex >= 0)
            {
                _storage.GetFigure(_selectedFigureIndex).Draw(ref FigureGraphics);
            }
        }

        public void DrawFigureSequence(int startIndex, int endIndex)
        {
            for (int i = startIndex; i < endIndex; i++)
            {
                _storage.GetFigure(i)?.Draw(ref ForegroundGraphics);
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
        public void Deserialize(IStorage storage)
        {

        }
        public void ChangePenColor(Color color)
        {
            _storage.GetFigure(_selectedFigureIndex).Pen.Color = color;
        }
        public void ChangeDashStyle(DashStyle dashStyle)
        {
            _storage.GetFigure(_selectedFigureIndex).Pen.DashStyle = dashStyle;
        }
        public void ChangePenWidth(float width)
        {
            _storage.GetFigure(_selectedFigureIndex).Pen.Width = width;
        }
        public void ChangeAntiAliasing(SmoothingMode smoothingMode)
        {
            _storage.GetFigure(_selectedFigureIndex).SmoothingMode = smoothingMode;
        }
        public void ChangeBrush(Color color)
        {
            _storage.GetFigure(_selectedFigureIndex).Brush = new SolidBrush(color);
        }
    }
}