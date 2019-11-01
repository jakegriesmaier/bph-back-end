using Model.Entities;
using Model.Models;
using Model.Models.Validators;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Tests
{

    public class UserChangeValidatorTest
    {
        User goodUser = MockUsers.Coach();
        User noEmailUser = MockUsers.BadEmail();
        User noUserIdUser = MockUsers.BadUserId();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void userHappyPath()
        {
            Assert.AreEqual(true, UserChangeValidator.ValidateUpdateUser(goodUser), "Marked a good user as bad");
        }
        [Test]
        public void userBadEmail()
        {
            Assert.AreEqual(false, UserChangeValidator.ValidateUpdateUser(noEmailUser), "Marked a bad user (no email) as good");
        }
        [Test]
        public void userBadUserId()
        {
            Assert.AreEqual(false, UserChangeValidator.ValidateUpdateUser(noUserIdUser), "Marked a bad user (no user id) as good");
        }
    
    }
}