using Model.Entities;
using Model.Models;
using Model.Models.Validators;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Tests
{

    public class UserValidatorTest
    {
        User goodUser = MockUsers.Coach();
        User noEmailUser = MockUsers.NullEmail();
        User noUserIdUser = MockUsers.BadUserId();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ValidateUpdateUser_HappyPath()
        {
            Assert.AreEqual(true, UserValidator.ValidateUpdateUser(goodUser), "Marked a good user as bad");
        }
        [Test]
        public void ValidateUpdateUser_NoEmail()
        {
            Assert.AreEqual(false, UserValidator.ValidateUpdateUser(noEmailUser), "Marked a bad user (no email) as good");
        }
        [Test]
        public void ValidateUpdateUser_NoId()
        {
            Assert.AreEqual(false, UserValidator.ValidateUpdateUser(noUserIdUser), "Marked a bad user (no user id) as good");
        }
        [Test]
        public void ValidateGetUser_HappyPath()
        {
            Assert.AreEqual(true, UserValidator.ValidateGetUser("Pizza"), "Marked a good call to ValidateGetUser as bad");

        }
        [Test]
        public void ValidateGetUser_NullId()
        {
            Assert.AreEqual(false, UserValidator.ValidateGetUser(null), "Didn't catch passing a null user id to validate get user");
        }
    
    }
}