using NUnit.Framework;

namespace Test
{
    public class Tests
    {
        private Storage _storege;
        [SetUp]
        public void Setup()
        {
            _storege = new Storage();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}