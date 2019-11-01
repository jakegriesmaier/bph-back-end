using System;
using System.Net.Http;
using System.Threading.Tasks;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Model.UnitTests.Tests.User
{
    public class UpdateUserTest
    {
        private UserModel _userModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _userModel = new UserModel(dataAccessLocator);
        }

        [Test]
        public async Task Test_UpdateUser_HappyPath()
        {
            var expected = await Task.FromResult(MockUsers.Trainee());
            var actual = await _userModel.UpdateUser(MockUsers.Trainee());
            Assert.AreEqual(expected.UserId, actual.UserId, "Error updating user UserId");
            Assert.AreEqual(expected.FirstName, actual.FirstName, "Error updating user FirstName");
            Assert.AreEqual(expected.LastName, actual.LastName, "Error updating user LastName");
            Assert.AreEqual(expected.Email, actual.Email, "Error updating user Email");
            Assert.AreEqual(expected.AccountType, actual.AccountType, "Error updating user AccountType");
            Assert.AreEqual(expected.Height, actual.Height, "Error updating user Height");
            Assert.AreEqual(expected.Weight, actual.Weight, "Error updating user Weight");

        }

        [Test]
        public void Test_UpdateUser_NullUserId()
        {
            Assert.ThrowsAsync(Is.TypeOf<HttpRequestException>(), async () => {
                await _userModel.UpdateUser(MockUsers.BadUserId());
            }, "Expected an error to be thrown when trying to make a user with bad password");
        }

        [Test]
        public void Test_UpdateUser_BadEmail()
        {
            Assert.ThrowsAsync(Is.TypeOf<HttpRequestException>(), async () => {
                await _userModel.UpdateUser(MockUsers.NullEmail());
            }, "Expected an error to be thrown when trying to make a user with bad email");
        }
    }
}
