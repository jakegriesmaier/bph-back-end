using System.Net.Http;
using System.Threading.Tasks;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Model.UnitTests.Tests.User
{
    public class CreateUserTest
    {
        private UserModel _userModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _userModel = new UserModel(dataAccessLocator);
        }

        [Test]
        public void Test_CreateUser_HappyPath()
        {
            Assert.DoesNotThrowAsync(async () =>
            {
                await _userModel.CreateUser("peanutbutter@jelly.time", "Spaghetti1!");
            }, "Error thrown while logging in user.");
        }

        [Test]
        public void Test_CreateUser_BadPassword()
        {
            Assert.ThrowsAsync(Is.TypeOf<HttpRequestException>(), async () => {
                await _userModel.CreateUser("peanutbutter@jelly.time", "Spaghetti");
            }, "Expected an error to be thrown when trying to make a user with bad password");
        }

        [Test]
        public void Test_CreateUser_BadEmail()
        {
            Assert.ThrowsAsync(Is.TypeOf<HttpRequestException>(), async () => {
                await _userModel.CreateUser("peanutbutter@jelly@ohcrap", "Spaghetti1!");
            }, "Expected an error to be thrown when trying to make a user with bad email");
        }
    }
}
