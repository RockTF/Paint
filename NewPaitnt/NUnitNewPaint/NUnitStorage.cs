using NewPaitnt.Implementation;
using NewPaitnt.Interfaces;
using NewPaitnt.VectorModel;
using NUnit.Framework;
using System.Collections.Generic;
using System.Reflection;
namespace NUnitNewPaint
{
    public class NUnitStorage
    {
        private Storage _storage;
        private MouseHandler _mouseHandler;
        private Settings _settings;
        [SetUp]
        public void Setup()
        {
            _storage = Storage.Initialize();
            _mouseHandler = MouseHandler.Initialize();
            _settings = Settings.Initialize();
        }
        [Test]
        public void TransferToBufferTest()
        {
            var listFigure = new List<IDrawable>()
            {
                new Line(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove(), _settings)
            };
            var listNames = new List<string>()
            {
               "Line"
            };

            var fieldInfo = typeof(Storage).GetField("_figures", BindingFlags.NonPublic | BindingFlags.Instance);
            fieldInfo.SetValue(_storage, listFigure);
            var fieldInfo1 = typeof(Storage).GetField("_figuresNames", BindingFlags.NonPublic | BindingFlags.Instance);
            fieldInfo1.SetValue(_storage, listNames);
            var fielbuffer = typeof(Storage).GetField("_buffer", BindingFlags.NonPublic | BindingFlags.Instance);

            _storage.TransferToBuffer();

            List<IDrawable> actualData = (List<IDrawable>)fielbuffer.GetValue(_storage);
            List<IDrawable> fieldInfoFigure = (List<IDrawable>)fieldInfo.GetValue(_storage);
            List<string> fildInfoFigureName = (List<string>)fieldInfo1.GetValue(_storage);

            Assert.AreEqual(actualData.Count, 1);
            Assert.AreEqual(fieldInfoFigure.Count, 0);
            Assert.AreEqual(fildInfoFigureName.Count, 0);
        }
        [Test]
        public void TransferToFigurTest()
        {
            var listBuffer = new List<IDrawable>()
            {
                new Line(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove(), _settings)
            };
            var listNames = new List<string>()
            {
               "Line"
            };

            var fieldInfo = typeof(Storage).GetField("_buffer", BindingFlags.NonPublic | BindingFlags.Instance);
            fieldInfo.SetValue(_storage, listBuffer);

            var fieldInfoName = typeof(Storage).GetField("_figuresNames", BindingFlags.NonPublic | BindingFlags.Instance);
            fieldInfoName.SetValue(_storage, listNames);

            var fielbuffer = typeof(Storage).GetField("_figures", BindingFlags.NonPublic | BindingFlags.Instance);

            _storage.TransferToFigure();

            List<IDrawable> actualData = (List<IDrawable>)fielbuffer.GetValue(_storage);
            List<IDrawable> fieldInfoFigure = (List<IDrawable>)fieldInfo.GetValue(_storage);
            List<string> fildInfoFigureName = (List<string>)fieldInfoName.GetValue(_storage);

            Assert.AreEqual(actualData.Count, 1);
            Assert.AreEqual(fieldInfoFigure.Count, 0);
            Assert.AreEqual(fildInfoFigureName.Count, 2);
        }
        [Test]
        public void Clear()
        {
            var listFigure = new List<IDrawable>()
            {
                new Line(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove(), _settings)
            };
            var listNames = new List<string>()
            {
               "Line"
            };
            var fieldInfo = typeof(Storage).GetField("_figures", BindingFlags.NonPublic | BindingFlags.Instance);
            fieldInfo.SetValue(_storage, listFigure);
            var fieldInfo1 = typeof(Storage).GetField("_figuresNames", BindingFlags.NonPublic | BindingFlags.Instance);
            fieldInfo1.SetValue(_storage, listNames);
            var fielbuffer = typeof(Storage).GetField("_buffer", BindingFlags.NonPublic | BindingFlags.Instance);
            _storage.Clear();
            List<IDrawable> actualData = (List<IDrawable>)fielbuffer.GetValue(_storage);
            List<IDrawable> fieldInfoFigure = (List<IDrawable>)fieldInfo.GetValue(_storage);
            List<string> fildInfoFigureName = (List<string>)fieldInfo1.GetValue(_storage);
            Assert.AreEqual(actualData.Count, 0);
            Assert.AreEqual(fieldInfoFigure.Count, 0);
            Assert.AreEqual(fildInfoFigureName.Count, 0);
        }
        [Test]
        public void RemoveFigureTest()
        {
            Line line = new Line(new Point2D(0, 0), new Point2D(1, 1), _settings);
            int initialCount = 5;
            _storage.Clear();
            for (int i = 0; i < initialCount; i++)
            {
                _storage.AddFigure(line);
            }
            _storage.RemoveFigureAt(3);
            Assert.AreEqual(initialCount - 1, _storage.GetCount());
        }
        [Test]
        public void GetCount()
        {
            var listFigure = new List<IDrawable>()
            {
                new Line(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove(), _settings)
            };
            var fieldInfo = typeof(Storage).GetField("_figures", BindingFlags.NonPublic | BindingFlags.Instance);
            fieldInfo.SetValue(_storage, listFigure);
            List<IDrawable> fieldInfoFigure = (List<IDrawable>)fieldInfo.GetValue(_storage);
            Assert.AreEqual(fieldInfoFigure.Count, 1);
        }
    }
}