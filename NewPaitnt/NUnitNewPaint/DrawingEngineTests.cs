using Moq;
using NewPaitnt.Implementation;
using NewPaitnt.Interfaces;
using NewPaitnt.Vector;
using NewPaitnt.VectorModel;
using NUnit.Framework;

namespace NUnitNewPaint
{
    public class DrawingEngineTests
    {
        private Settings _settings;
        private MouseHandler _mouseHandler;
        private PenPreview _penPreview;
        private Mock<IStorage> _storage;
        private Service _service;

        private DrawingEngine _drawingEngine;

        private IDrawable _drawable;
        

        [SetUp]
        public void Setup()
        {
            _settings = Settings.Initialize();
            _mouseHandler = MouseHandler.Initialize();
            _penPreview = PenPreview.Initialize(_settings.Pen, 31, 31);
            _storage = new Mock<IStorage>(MockBehavior.Strict);
            _service = Service.Initialize();

            _drawingEngine = DrawingEngine.Initialize(_settings, _mouseHandler, _penPreview, _storage.Object, _service);

            _drawable = new Line(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove(), _settings.Pen, _settings.SmoothingMode);
        }

        //[Test]
        //public void CreateCurveTest()
        //{
        //    //var figure = new Curve(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove(), _settings.Pen, _settings.SmoothingMode);
        //    _settings.SetMode(EFigure.Curve);
        //    _storage.Setup(a => a.AddFigure(It.IsAny<Curve>()));
        //    _drawingEngine.CreateFigure();
        //    _storage.Verify(a => a.AddFigure(It.IsAny<Curve>()), Times.Once);
        //}

        //[Test]
        //public void CreateLineTest()
        //{
        //    _settings.SetMode(EFigure.Line);
        //    _storage.Setup(a => a.AddFigure(It.IsAny<Line>()));
        //    _drawingEngine.CreateFigure();
        //    _storage.Verify(a => a.AddFigure(It.IsAny<Line>()), Times.Once);
        //}

        //[Test]
        //public void CreateEllipseTest()
        //{
        //    _settings.SetMode(EFigure.Ellipse);
        //    _storage.Setup(a => a.AddFigure(It.IsAny<Ellipse>()));
        //    _drawingEngine.CreateFigure();
        //    _storage.Verify(a => a.AddFigure(It.IsAny<Ellipse>()), Times.Once);
        //}

        //[Test]
        //public void CreatePolygonTest()
        //{
        //    _settings.SetMode(EFigure.Polygon);
        //    _storage.Setup(a => a.AddFigure(It.IsAny<Polygon>()));
        //    _drawingEngine.CreateFigure();
        //    _storage.Verify(a => a.AddFigure(It.IsAny<Polygon>()), Times.Once);
        //}

        //[Test]
        //public void CreateRoundedRectangleTest()
        //{
        //    _settings.SetMode(EFigure.Ellipse);
        //    _storage.Setup(a => a.AddFigure(It.IsAny<RoundedRectangle>()));
        //    _drawingEngine.CreateFigure();
        //    _storage.Verify(a => a.AddFigure(It.IsAny<RoundedRectangle>()), Times.Once);
        //}

        //[Test]
        //public void CreateSmoothCurveTest()
        //{
        //    _settings.SetMode(EFigure.SmoothCurve);
        //    _storage.Setup(a => a.AddFigure(It.IsAny<SmoothCurve>()));
        //    _drawingEngine.CreateFigure();
        //    _storage.Verify(a => a.AddFigure(It.IsAny<SmoothCurve>()), Times.Once);
        //}

        //[Test]
        //public void CreateSmoothTriangleTest()
        //{
        //    _settings.SetMode(EFigure.Triangle);
        //    _storage.Setup(a => a.AddFigure(It.IsAny<Triangle>()));
        //    _drawingEngine.CreateFigure();
        //    _storage.Verify(a => a.AddFigure(It.IsAny<Triangle>()), Times.Once);
        //}

        //[Test]
        //public void CreateDotTest()
        //{
        //    _settings.SetMode(EFigure.Dot);
        //    _storage.Setup(a => a.AddFigure(It.IsAny<Dot>()));
        //    _drawingEngine.CreateFigure();
        //    _storage.Verify(a => a.AddFigure(It.IsAny<Dot>()), Times.Once);
        //}

        //[Test]
        //public void CreateRectangleTest()
        //{
        //    _settings.SetMode(EFigure.Rectangle);
        //    _storage.Setup(a => a.AddFigure(It.IsAny<Rectangle>()));
        //    _drawingEngine.CreateFigure();
        //    _storage.Verify(a => a.AddFigure(It.IsAny<Rectangle>()), Times.Once);
        //}

        //[Test]
        //public void CreateFigureTest1()
        //{
        //    _storage.Setup(a => a.AddFigure(It.IsAny<IDrawable>()));
        //    _drawingEngine.CreateFigure();
        //    _storage.Verify(a => a.AddFigure(It.IsAny<IDrawable>()), Times.Once);
        //}

       
    }
}