using Microsoft.AppCenter.Storage;
using Moq;
using NewPaitnt.Interfaces;
using NUnit.Framework;

namespace NUnitNewPaint
{
    public class Tests
    {
        private IDrawable _drawable;
        private ISettings _settings;
        private Mock<IStorage> _storage;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}