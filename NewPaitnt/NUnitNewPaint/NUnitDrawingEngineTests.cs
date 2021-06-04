using Moq;
using NewPaitnt.Implementation;
using NewPaitnt.Interfaces;
using NewPaitnt.Vector;
using NewPaitnt.VectorModel;
using NUnit.Framework;
using System.Collections.Generic;
namespace NUnitNewPaint
{
    public class NUnitDrawingEngineTests
    {
        private Settings _settings;
        private MouseHandler _mouseHandler;
        private PenPreview _penPreview;
        private DrawingEngine _drawingEngine;
        private IDrawable _drawable;
        private Mock<IStorage> _storage;
        private Mock<IMouseHandler> _mousehandler;
        [SetUp]
        public void Setup()
        {
            _settings = Settings.Initialize();
            _mouseHandler = MouseHandler.Initialize();
            _penPreview = PenPreview.Initialize(_settings.Pen, 31, 31);
            _storage = new Mock<IStorage>(MockBehavior.Strict);
            _mousehandler = new Mock<IMouseHandler>(MockBehavior.Strict);
            _drawingEngine = new DrawingEngine(_settings, _mousehandler.Object, _penPreview, _storage.Object);
            _drawable = new Line(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove(), _settings.Pen, _settings.SmoothingMode);
        }
        [Test]
        public void CreateFigureTestStorage()
        {
            _mousehandler.Setup(a => a.GetMove()).Returns(new System.Drawing.Point());
            _mousehandler.Setup(a => a.GetPreviousMove()).Returns(new System.Drawing.Point());
            _storage.Setup(a => a.AddFigure(It.IsAny<IDrawable>()));
            _drawingEngine.CreateFigure();
            _storage.Verify(a => a.AddFigure(It.IsAny<IDrawable>()), Times.Once);
        }
        [Test]
        public void CreateCurveTestStorage()
        {
            _settings.SetMode(EFigure.Curve);
            _mousehandler.Setup(a => a.GetMove()).Returns(new System.Drawing.Point());
            _mousehandler.Setup(a => a.GetPreviousMove()).Returns(new System.Drawing.Point());
            _storage.Setup(a => a.AddFigure(It.IsAny<Curve>()));
            _drawingEngine.CreateFigure();
            _storage.Verify(a => a.AddFigure(It.IsAny<Curve>()), Times.Once);
        }
        [Test]
        public void CreateLineTestStorage()
        {
            _settings.SetMode(EFigure.Line);
            _mousehandler.Setup(a => a.GetMove()).Returns(new System.Drawing.Point());
            _mousehandler.Setup(a => a.GetPreviousMove()).Returns(new System.Drawing.Point());
            _storage.Setup(a => a.AddFigure(It.IsAny<Line>()));
            _drawingEngine.CreateFigure();
            _storage.Verify(a => a.AddFigure(It.IsAny<Line>()), Times.Once);
        }
        [Test]
        public void CreateEllipseTestStorage()
        {
            _settings.SetMode(EFigure.Ellipse);
            _mousehandler.Setup(a => a.GetMove()).Returns(new System.Drawing.Point());
            _mousehandler.Setup(a => a.GetPreviousMove()).Returns(new System.Drawing.Point());
            _storage.Setup(a => a.AddFigure(It.IsAny<Ellipse>()));
            _drawingEngine.CreateFigure();
            _storage.Verify(a => a.AddFigure(It.IsAny<Ellipse>()), Times.Once);
        }
        [Test]
        public void CreatePolygonTestStorage()
        {
            _settings.SetMode(EFigure.Polygon);
            _mousehandler.Setup(a => a.GetMove()).Returns(new System.Drawing.Point());
            _mousehandler.Setup(a => a.GetClick()).Returns(new System.Drawing.Point());
            _storage.Setup(a => a.AddFigure(It.IsAny<Polygon>()));
            _drawingEngine.CreateFigure();
            _storage.Verify(a => a.AddFigure(It.IsAny<Polygon>()), Times.Once);
        }
        [Test]
        public void CreateRoundedRectangleTestStorage()
        {
            _settings.SetMode(EFigure.RoundedRectangle);
            _mousehandler.Setup(a => a.GetMove()).Returns(new System.Drawing.Point());
            _mousehandler.Setup(a => a.GetPreviousMove()).Returns(new System.Drawing.Point());
            _storage.Setup(a => a.AddFigure(It.IsAny<RoundedRectangle>()));
            _drawingEngine.CreateFigure();
            _storage.Verify(a => a.AddFigure(It.IsAny<RoundedRectangle>()), Times.Once);
        }
        [Test]
        public void CreateSmoothCurveTestStorage()
        {
            _settings.SetMode(EFigure.SmoothCurve);
            _mousehandler.Setup(a => a.GetMove()).Returns(new System.Drawing.Point());
            _mousehandler.Setup(a => a.GetClick()).Returns(new System.Drawing.Point());
            _storage.Setup(a => a.AddFigure(It.IsAny<SmoothCurve>()));
            _drawingEngine.CreateFigure();
            _storage.Verify(a => a.AddFigure(It.IsAny<SmoothCurve>()), Times.Once);
        }
        [Test]
        public void CreateSmoothTriangleTestStorage()
        {
            _settings.SetMode(EFigure.Triangle);
            _mousehandler.Setup(a => a.GetMove()).Returns(new System.Drawing.Point());
            _mousehandler.Setup(a => a.GetPreviousMove()).Returns(new System.Drawing.Point());
            _storage.Setup(a => a.AddFigure(It.IsAny<Triangle>()));
            _drawingEngine.CreateFigure();
            _storage.Verify(a => a.AddFigure(It.IsAny<Triangle>()), Times.Once);
        }
        [Test]
        public void CreateDotTestStorage()
        {
            _settings.SetMode(EFigure.Dot);
            _mousehandler.Setup(a => a.GetClick()).Returns(new System.Drawing.Point());
            _storage.Setup(a => a.AddFigure(It.IsAny<Dot>()));
            _drawingEngine.CreateFigure();
            _storage.Verify(a => a.AddFigure(It.IsAny<Dot>()), Times.Once);
        }
        [Test]
        public void CreateRectangleTestStorage()
        {
            _settings.SetMode(EFigure.Rectangle);
            _mousehandler.Setup(a => a.GetMove()).Returns(new System.Drawing.Point());
            _mousehandler.Setup(a => a.GetPreviousMove()).Returns(new System.Drawing.Point());
            _storage.Setup(a => a.AddFigure(It.IsAny<Rectangle>()));
            _drawingEngine.CreateFigure();
            _storage.Verify(a => a.AddFigure(It.IsAny<Rectangle>()), Times.Once);
        }
        [Test]
        public void SelectFigureTestStorage()
        {
            _storage.Setup(a => a.GetCount()).Returns(1);
            _storage.Setup(a => a.GetFigure(0)).Returns(new Line(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove(), _settings.Pen, _settings.SmoothingMode));
            _drawingEngine.SelectFigure();
            _storage.Verify(a => a.GetCount(), Times.Once);
        }
        [Test]
        public void RedrawNewFigureTestStorage1()
        {
            _mousehandler.Setup(a => a.GetMove()).Returns(new System.Drawing.Point());
            _storage.Setup(a => a.GetLastFigure()).Returns(new Line(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove(), _settings.Pen, _settings.SmoothingMode));
            _drawingEngine.RedrawNewFigure();
            _storage.Verify(a => a.GetLastFigure(), Times.Once);
        }
        [Test]
        public void ClearCanvasTestStorage()
        {
            _storage.Setup(a => a.Clear());
            _drawingEngine.ClearCanvas();
            _storage.Verify(a => a.Clear(), Times.Once);
        }
        [Test]
        public void ClearStorageTestStorage()
        {
            _storage.Setup(a => a.Clear());
            _drawingEngine.ClearStorage();
            _storage.Verify(a => a.Clear(), Times.Once);
        }
        [Test]
        public void GetLastFigureTestStorage()
        {
            var t = new List<IDrawable>()
            {
                new Line(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove(), _settings.Pen, _settings.SmoothingMode)
            };
            _storage.Setup(a => a.GetAllFigures()).Returns(t);
            _drawingEngine.DrawAllFigures();
            _storage.Verify(a => a.GetAllFigures(), Times.Once);
        }
        [Test]
        public void DeleteFigureTestStorage()
        {
            _storage.Setup(a => a.RemoveFigureAt(1));
            _drawingEngine.DeleteFigure();
            _storage.Verify(a => a.RemoveFigureAt(1), Times.Never);
        }
        [Test]
        public void GetFigureListTestStorage()
        {
            var t = new List<string>()
            {
               "Line"
            };
            _storage.Setup(a => a.GetFiguresNames()).Returns(t);
            _drawingEngine.GetFigureList();
            _storage.Verify(a => a.GetFiguresNames(), Times.Once);
        }
        [Test]
        public void RedrawFigureTestMouseHandler()
        {
            _mousehandler.Setup(a => a.GetMove()).Returns(new System.Drawing.Point());
            _storage.Setup(a => a.GetLastFigure()).Returns(new Line(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove(), _settings.Pen, _settings.SmoothingMode));
            _drawingEngine.RedrawFigure();
            _mousehandler.Verify(a => a.GetMove(), Times.Once);
        }
        [Test]
        public void MoveFigureTest1MouseHandler()
        {
            _mousehandler.Setup(a => a.GetPreviousMove()).Returns(new System.Drawing.Point());
            _drawingEngine.MoveFigure();
            _mousehandler.Verify(a => a.GetPreviousMove(), Times.Never);
        }
        [Test]
        public void MoveFigureTest2MouseHandler()
        {
            _mousehandler.Setup(a => a.GetMove()).Returns(new System.Drawing.Point());
            _mousehandler.Setup(a => a.GetPreviousMove()).Returns(new System.Drawing.Point());
            _storage.Setup(a => a.AddFigure(It.IsAny<Triangle>()));
            _drawingEngine.CreateFigure();
            _mousehandler.Verify(a => a.GetMove(), Times.Once);
        }
    }
}