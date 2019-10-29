using Model.Models;
using Model.Models.Validators;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Tests
{
    public class CredentialsValidatorTest
    {
        private string noUpper = "spaghetti1";
        private string noLower = "SPAGHETTI1";
        private string shortPass = "1234567";
        private string noNums = "spaghetti";
        private string goodPass = "Spaghetti1";
       
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void passwordHappyPath()
        {
            Assert.True(CredentialsValidator.ValidatePassword(goodPass));
        }
        [Test]
        public void passwordNoUppercase()
        {
            Assert.False(CredentialsValidator.ValidatePassword(noUpper));
        }
        [Test]
        public void passwordNoLowercase()
        {
            Assert.False(CredentialsValidator.ValidatePassword(noLower));
        }

        [Test]
        public void passwordHasLength()
        {
            Assert.False(CredentialsValidator.ValidatePassword(shortPass));
        }
        [Test]
        public void passwordNoNumbers()
        {
            Assert.False(CredentialsValidator.ValidatePassword(noNums));
        }
    }
}