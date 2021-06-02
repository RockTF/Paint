using Moq;
using NewPaitnt.Implementation;
using NewPaitnt.Interfaces;
using NewPaitnt.Vector;
using NewPaitnt.VectorModel;
using NUnit.Framework;


namespace NUnitNewPaint
{
    public class Tests
    {
        private DrawingEngine _drawingEngine;
        private MouseHandler _mouseHandler;
        private Settings _settings;

        private IDrawable _drawable;
        private Mock<IStorage> _storage;


        [SetUp]
        public void Setup()
        {
           
            _mouseHandler = MouseHandler.Initialize();
            _settings = Settings.Initialize();

            _drawable = new Line(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove(), _settings.Pen, _settings.SmoothingMode);
            _storage = new Mock<IStorage>(MockBehavior.Strict);

           _drawingEngine = DrawingEngine.Initialize(31, 31, _storage.Object);
        }

        [Test]
        public void CreateFigureTest1() 
        {
            //var figure = new Line(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove(), _settings.Pen, _settings.SmoothingMode);
            var figure = new Curve(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove(), _settings.Pen, _settings.SmoothingMode);
        //    _settings.Mode = EFigure.
            _storage.Setup(a => a.AddFigure(It.IsAny<Curve>()));
           // _drawingEngine.CreateFigure();
            _storage.Verify(a => a.AddFigure(It.IsAny<Curve>()), Times.Once);

        }
    }
}