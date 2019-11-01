using System;
using System.Threading.Tasks;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Model.UnitTests.Tests.User
{
    public class GetCurrentUser
    {

        private UserModel _userModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _userModel = new UserModel(dataAccessLocator);
        }

        [Test]
        public async Task Test_GetCurrentUser_HappyPath()
        {
            var expected = await Task.FromResult(MockUsers.Coach());
            var actual = await _userModel.GetCurrentUser();
            Assert.AreEqual(expected.UserId, actual.UserId, "Error grabbing current user (UserId)");
            Assert.AreEqual(expected.FirstName, actual.FirstName, "Error grabbing current user (FirstName)");
            Assert.AreEqual(expected.LastName, actual.LastName, "Error grabbing current user (LastName)");
            Assert.AreEqual(expected.Email, actual.Email, "Error grabbing current user (Email)");
            Assert.AreEqual(expected.AccountType, actual.AccountType, "Error grabbing current user (AccountType)");
            Assert.AreEqual(expected.Height, actual.Height, "Error grabbing current user (Height)");
            Assert.AreEqual(expected.Weight, actual.Weight, "Error grabbing current user (Weight)");

        }
    }
}
