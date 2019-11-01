using System;
using System.Threading.Tasks;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Model.UnitTests.Tests.User
{
    public class LogoutUserTest
    {

        private UserModel _userModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _userModel = new UserModel(dataAccessLocator);
        }

        [Test]
        public void Test_LogoutUser_HappyPath()
        {
            Assert.DoesNotThrowAsync(async () =>
            {
                await _userModel.LogoutUser();
            }, "Error thrown while logging in user.");

        }

    }
}

