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

        [Test]
        public void CreateCurveTest1()
        {
            //var figure = new Curve(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove(), _settings.Pen, _settings.SmoothingMode);
            _settings.SetMode(EFigure.Curve);
            _storage.Setup(a => a.AddFigure(It.IsAny<Curve>()));
            _drawingEngine.CreateFigure();
            _storage.Verify(a => a.AddFigure(It.IsAny<Curve>()), Times.Once);
        }

        [Test]
        public void CreateFigureTest1()
        {
            _storage.Setup(a => a.AddFigure(It.IsAny<IDrawable>()));
            _drawingEngine.CreateFigure();
            _storage.Verify(a => a.AddFigure(It.IsAny<IDrawable>()), Times.Once);
        }
    }
}