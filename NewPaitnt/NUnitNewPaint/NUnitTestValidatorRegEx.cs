using NUnit.Framework;
using Validator;

namespace NUnitNewPaint
{

    public class NUnitTestValidatorRegEx
    {
        private IRegistrationValidator _valid;

        [SetUp]
        public void Setup()
        {
            _valid = new ValidatorRegEx();
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
        [TestCase("JOHN1245@example.com")]
        [TestCase("125JOHN1245@example.com")]

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
        [TestCase("john")]
        [TestCase("johnDou")]
        [TestCase("JaSoN")]

        public void TestIsValidName(string testName)
        {
            bool exp = false;
            bool res;
            string message;

            (res, message) = _valid.NameValidation(testName);
            Assert.AreEqual(exp, res);
            Assert.AreEqual(true, message.Length > 1);
        }

        
        [TestCase("John")]
        [TestCase("Alex")]
        [TestCase("Ibrahim")]

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
        [TestCase("1joh Dou2")]

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
