using Model.Models;
using Model.Models.Validators;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Tests
{
    
    public class CredentialsValidatorTest
    {
        private string noUpper = "spaghetti1$";
        private string noLower = "SPAGHETTI1$";
        private string shortPass = "1Ab$567";
        private string noNums = "spaghetTI$";
        private string noSymbols = "Spaghetti1";
        private string goodPass = "Spaghetti1$";

        private string goodEmail = "jakeschaum@gmail.com";
        private string badEmail = "jake@jake@jake";
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void emailHappyPath()
        {
            Assert.AreEqual(true, CredentialsValidator.ValidateEmail(goodEmail), "Marked a good email as bad");
        }
        [Test]
        public void emailBad()
        {
            Assert.AreEqual(false, CredentialsValidator.ValidateEmail(badEmail), "Marked a bad email as good");
        }
        [Test]
        public void passwordHappyPath()
        {
            Assert.AreEqual(true, CredentialsValidator.ValidatePassword(goodPass), "Marked a good password as bad");
        }
        [Test]
        public void passwordNoSymbols()
        {
            Assert.AreEqual(false, CredentialsValidator.ValidatePassword(noSymbols), "Marked a password without symbols as good");
        }
        [Test]
        public void passwordNoUppercase()
        {
            Assert.AreEqual(false, CredentialsValidator.ValidatePassword(noUpper), "Marked a password without uppercase as good");
        }
        [Test]
        public void passwordNoLowercase()
        {
            Assert.AreEqual(false, CredentialsValidator.ValidatePassword(noLower), "Marked a password without lowercase as good");
        }

        [Test]
        public void passwordHasLength()
        {
            Assert.AreEqual(false, CredentialsValidator.ValidatePassword(shortPass), "Marked a short password as good");
        }
        [Test]
        public void passwordNoNumbers()
        {
            Assert.AreEqual(false, CredentialsValidator.ValidatePassword(noNums), "Marked a password without numbers as good");
        }
    }
}