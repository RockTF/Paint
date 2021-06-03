using NewPaitnt.Implementation;
using NewPaitnt.Interfaces;
using NewPaitnt.Vector;
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
        public void TransferToBuffer()
        {
            var t = new List<IDrawable>()
            {
                new Line(_mouseHandler.GetPreviousMove(), _mouseHandler.GetMove(), _settings.Pen, _settings.SmoothingMode)
            };

            var tt = new List<string>()
            {
               "Line"
            };

            var fieldInfo = typeof(Storage).GetField("_figures", BindingFlags.NonPublic | BindingFlags.Instance);
            fieldInfo.SetValue(_storage, t);

            var fieldInfo1 = typeof(Storage).GetField("_figuresNames", BindingFlags.NonPublic | BindingFlags.Instance);
            fieldInfo1.SetValue(_storage, tt);

            var fielbuffer = typeof(Storage).GetField("_buffer", BindingFlags.NonPublic | BindingFlags.Instance);

            _storage.TransferToBuffer();

            List<IDrawable> actualData = (List<IDrawable>)fielbuffer.GetValue(_storage);
            List<IDrawable> fildInfoFigure = (List<IDrawable>)fieldInfo.GetValue(_storage);
            List<string> fildInfoFigureName = (List<string>)fieldInfo1.GetValue(_storage);

            Assert.AreEqual(actualData.Count,1);
            Assert.AreEqual(fildInfoFigure.Count, 0);
            Assert.AreEqual(fildInfoFigureName.Count, 0);
        
        }
        [TestCase(1, 1)]
        public void RemoveFigureAt(int position, int exp)
        {
            _storage.RemoveFigureAt(position);
            //Assert.AreEqual(exp, result);
        }
    }
}