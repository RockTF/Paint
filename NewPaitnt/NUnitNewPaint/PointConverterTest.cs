using NewPaitnt.VectorModel;
using NUnit.Framework;
using System.Collections.Generic;
using System.Drawing;

namespace NUnitNewPaint
{
    class PointConverterTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SystemPointToCustom()
        {
            Point system = new Point(0, 0);
            Point2D custom = new Point2D(0, 0);
            Assert.AreEqual(custom, NewPaitnt.Implementation.PointConverter.SystemToCustom(system));
        }

        [Test]
        public void CustomPointToSystem()
        {
            Point system = new Point(0, 0);
            Point2D custom = new Point2D(0, 0);
            Assert.AreEqual(system, NewPaitnt.Implementation.PointConverter.CustomToSystem(custom));
        }

        [Test]
        public void CustomPointListToSystemArray()
        {
            List<Point2D> customList = new List<Point2D>
            {
                new Point2D(0, 0),
                new Point2D(1, 1),
                new Point2D(2, 2)
            };
            Point[] systemArray = new Point[]
            {
                new Point(0, 0),
                new Point(1, 1),
                new Point(2, 2)
            };
            Assert.AreEqual(systemArray, NewPaitnt.Implementation.PointConverter.CustomToSystem(customList));
        }
    }
}