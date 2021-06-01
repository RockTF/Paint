using NewPaitnt.Implementation;
using NUnit.Framework;

namespace TestStorege
{
    public class Tests
    {
        private Storage _storege;
        [SetUp]
        public void Setup()
        {
            _storege = new Storege();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}