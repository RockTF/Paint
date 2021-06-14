using NUnit.Framework;
using NewPaitnt.Implementation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitNewPaint
{
    class ColorConverterTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void StringFormatTest()
        {
            string hexColor = HexColorConverter.ColorToHex(Color.Black);
            Assert.AreEqual(hexColor.Length, 9);
            Assert.AreEqual(hexColor[0], '#');
        }
    }
}
