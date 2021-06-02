using Moq;
using NewPaitnt.Implementation;
using NewPaitnt.Interfaces;
using NewPaitnt.Vector;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitNewPaint
{
    class DrawingEngenTests
    {
        private DrawingEngine _drawingEngine;
        private MouseHandler _mouseHandler;
        private Settings _settings;
        private IDrawable _drawable;
        private Mock<IStorage> _storage;


        [SetUp]
        public void Setup()
        {
            _drawingEngine = DrawingEngine.Initialize(31,31, Storage.Initialize());
            _mouseHandler = MouseHandler.Initialize();
            _settings = Settings.Initialize();
            _drawable = new Line(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove(), _settings.Pen, _settings.SmoothingMode);
            _storage = new Mock<IStorage>(MockBehavior.Strict);
        }

        [Test]
        public void Test1()
        {

        }
    }
}
