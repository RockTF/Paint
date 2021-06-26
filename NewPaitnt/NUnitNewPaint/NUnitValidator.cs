using NUnit.Framework;
using Validator;

namespace NUnitNewPaint
{
 
    public class NUnitValid
    {
        private IRegistrationValidator _valid;

        [SetUp]
        public void Setup()
        {
            _valid = new ValidatorCondition();
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
        
        public void TestIsValidEmail(string testMail) 
        {
            bool exp = false;
            bool res;
            string message;

            (res, message) = _valid.EmailValidation(testMail);
            Assert.AreEqual(exp, res);
            Assert.AreEqual(true, message.Length > 1);
        }

        [TestCase("john@doe.example.com")]
        [TestCase("john.doe@example.com")]
        [TestCase("john@example.com")]
        [TestCase("john1245@example.com")]
        [TestCase("JOHN1245@example.com")]
        [TestCase("125JOHN1245@example.com")]
        [TestCase("123mail.ru@gmail.com")]

        public void TestTwoIsValidEmail(string testMail)
        {
            bool exp = true;
            bool res;
            string message;

            (res, message) = _valid.EmailValidation(testMail);
            Assert.AreEqual(exp, res);
            Assert.AreEqual(true, message.Length == 0);
        }
        
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("1586")]
        [TestCase("_john")]
        [TestCase("j5oh4n")]
        [TestCase("joh^nD%ou")]
        [TestCase("john1541")]
        [TestCase("john DoeBlackVlastilin")]
        [TestCase("johnDoeBlackVlastilin")]
        public void TestIsValidName(string testName)
        {
            bool exp = false;
            bool res;
            string message;

            (res, message) = _valid.NameValidation(testName);
            Assert.AreEqual(exp, res);
            Assert.AreEqual(true, message.Length > 1);
        }

        [TestCase("john")]
        [TestCase("John")]
        [TestCase("johnDou")]
        [TestCase("JaSoN")]

        public void TestTwoIsValidName(string testName)
        {
            bool exp = true;
            bool res;
            string message;

            (res, message) = _valid.NameValidation(testName);
            Assert.AreEqual(exp, res);
            Assert.AreEqual(true, message.Length == 0);
        } 
        
        [TestCase("j5oh4n")]
        [TestCase("john1541")]
        [TestCase("johnDou")]
        [TestCase("john+Dou")]
        [TestCase("john_Dou")]
        [TestCase("john-Dou")]
        [TestCase("1johnDou2")]

        public void TestIsValidPassword(string testPassword)
        {
            bool exp = true;
            bool res;
            string message;

            (res, message) = _valid.PasswordValidation(testPassword);
            Assert.AreEqual(exp, res);
            Assert.AreEqual(true, message.Length == 0);
        }

        [TestCase(" ")]
        [TestCase("")]
        [TestCase("johnDoebigBlackVlastilinNagibator")]
        [TestCase("1joh Dou2")]
        [TestCase("joh%nD*ou")]
        [TestCase("F#@kF$#k")]
        public void TestTwoIsValidPassword(string testPassword)
        {
            bool exp = false;
            bool res;
            string message;

            (res, message) = _valid.PasswordValidation(testPassword);
            Assert.AreEqual(exp, res);
            Assert.AreEqual(true, message.Length > 1);
        }
    }
}
