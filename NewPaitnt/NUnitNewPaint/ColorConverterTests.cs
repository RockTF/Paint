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
        public void BlackColorToHex()
        {
            string expectedHexColor = "#FF000000";
            string hexColor = HexColorConverter.ColorToHex(Color.Black);
            Assert.AreEqual(expectedHexColor, hexColor);
            Assert.AreEqual(hexColor.Length, 9);
            Assert.AreEqual(hexColor[0], '#');
        }

        [Test]
        public void BlueVioletColorToHex()
        {
            string expectedHexColor = "#FF8A2BE2";
            string hexColor = HexColorConverter.ColorToHex(Color.BlueViolet);
            Assert.AreEqual(expectedHexColor, hexColor);
            Assert.AreEqual(hexColor.Length, 9);
            Assert.AreEqual(hexColor[0], '#');
        }

        [Test]
        public void BlackHex8ToColor()
        {
            Color expectedColor = Color.FromArgb(255, 0, 0 , 0);
            Color color = HexColorConverter.HexToColor("#FF000000");
            Assert.AreEqual(expectedColor, color);
        }

        [Test]
        public void BlackHex6ToColor()
        {
            Color expectedColor = Color.FromArgb(255, 0, 0, 0);
            Color color = HexColorConverter.HexToColor("#000000");
            Assert.AreEqual(expectedColor, color);
        }

        [Test]
        public void BlueVioletHex8ToColor()
        {
            Color expectedColor = Color.FromArgb(255, 138, 43, 226);
            Color color = HexColorConverter.HexToColor("#FF8A2BE2");
            Assert.AreEqual(expectedColor, color);
        }

        [Test]
        public void BlueVioletHex6ToColor()
        {
            Color expectedColor = Color.FromArgb(255, 138, 43, 226);
            Color color = HexColorConverter.HexToColor("#8A2BE2");
            Assert.AreEqual(expectedColor, color);
        }

        [Test]
        public void InvalidHex8ToColor()
        {
            try
            {
                Color color = HexColorConverter.HexToColor("#FF8G2BE2");
                Assert.Fail();
            }
            catch (ArgumentException) { }
        }

        [Test]
        public void InvalidHex6ToColor()
        {
            try
            {
                Color color = HexColorConverter.HexToColor("#8A2HE2");
                Assert.Fail();
            }
            catch (ArgumentException) { }
        }
    }
}
