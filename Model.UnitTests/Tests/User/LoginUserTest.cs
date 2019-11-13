using System;
using System.Net.Http;
using System.Threading.Tasks;
using Model.Exceptions;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Model.UnitTests.Tests.User
{
    public class LoginUserTest
    {
        private UserModel _userModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _userModel = new UserModel(dataAccessLocator);
        }

        [Test]
        public void Test_LoginUser_HappyPath()
        {
            Assert.DoesNotThrowAsync(async () =>
            {
                await _userModel.LoginUser("peanutbutter@jelly.time", "Spaghetti1!");
            }, "Error thrown while logging in user.");
        }

        [Test]
        public void Test_LoginUser_BadPassword()
        {
            Assert.ThrowsAsync(Is.TypeOf<InvalidParameterFormatException>(), async () =>
            {
                await _userModel.LoginUser("peanutbutter@jelly.time", "Spaghetti");
            }, "Expected an error to be thrown when trying to log in a user with bad password");
        }

        [Test]
        public void Test_LoginUser_BadEmail()
        {
            Assert.ThrowsAsync(Is.TypeOf<InvalidParameterFormatException>(), async () =>
            {
                await _userModel.LoginUser("peanutbutter@jelly@ohcrap", "Spaghetti1!");
            }, "Expected an error to be thrown when trying to log in user with bad email");
        }
    }
}
