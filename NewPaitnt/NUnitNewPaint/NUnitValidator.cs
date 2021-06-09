using NewPaitnt;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitNewPaint
{
 
    public class NUnitValid
    {
        private Valid _valid;

        [SetUp]
        public void Setup()
        {
            _valid = new Valid();
        }

        [TestCase("john - doe")]
        [TestCase("john-doe@com")]
        [TestCase("john-doe@example.c")]
        [TestCase("john@1")]
        [TestCase("john@-doe.com")]
        [TestCase("")]       
        [TestCase(" ")]       
        [TestCase("john..doe@eaxmple.com")]
        [TestCase(".john@example.com")]
        [TestCase("john.@example.com")]
        [TestCase("joh @example.com")]
        [TestCase("john@example.c m")]
        public void TestIsValidEmail(string testMaeil) 
        {
            char[] test = testMaeil.ToCharArray();
            bool exp = false;

            bool res = _valid.IsValidEmail(test);
            Assert.AreEqual(exp, res); 
        }

        [TestCase("john@doe.example.com")]
        [TestCase("john.doe@example.com")]
        [TestCase("john@example.com")]
        [TestCase("john1245@example.com")]
        [TestCase("JOHN1245@example.com")]
        [TestCase("125JOHN1245@example.com")]
        public void TestTwoIsValidEmail(string testMaeil)
        {
            char[] test = testMaeil.ToCharArray();
            bool exp = true;

            bool res = _valid.IsValidEmail(test);
            Assert.AreEqual(exp, res);
        }

        [TestCase("john")]
        [TestCase("John")]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("1586")]
        [TestCase("_john")]
        [TestCase("john DoeBlackVlastilin")]
        [TestCase("johnDoeBlackVlastilin")]
        public void TestIsValidName(string testMaeil)
        {
            char[] test = testMaeil.ToCharArray();
            bool exp = false;

            bool res = _valid.IsValidName(test);
            Assert.AreEqual(exp, res);
        }

        [TestCase("j5oh4n")]
        [TestCase("john1541")]
        [TestCase("johnDou")]
        public void TestTwoIsValidName(string testMaeil)
        {
            char[] test = testMaeil.ToCharArray();
            bool exp = true;

            bool res = _valid.IsValidName(test);
            Assert.AreEqual(exp, res);
        } 
        
        [TestCase("j5oh4n")]
        [TestCase("john1541")]
        [TestCase("johnDou")]
        [TestCase("john+Dou")]
        [TestCase("john_Dou")]
        [TestCase("john-Dou")]
        [TestCase("1johnDou2")]
        [TestCase("1joh Dou2")]
        public void TestIsValidPassword(string testMaeil)
        {
            char[] test = testMaeil.ToCharArray();
            bool exp = true;

            bool res = _valid.IsValidPassword(test);
            Assert.AreEqual(exp, res);
        }
        [TestCase(" ")]
        [TestCase("")]
        [TestCase("john DoeBlackVlastilin")]       
        public void TestTwoIsValidPassword(string testMaeil)
        {
            char[] test = testMaeil.ToCharArray();
            bool exp = false;

            bool res = _valid.IsValidPassword(test);
            Assert.AreEqual(exp, res);
        }


    }
}
