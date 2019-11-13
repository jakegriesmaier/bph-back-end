using System;
using System.Net.Http;
using System.Threading.Tasks;
using Model.Exceptions;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Model.UnitTests.Tests.User
{
    public class UpdatePasswordTest
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
            public void Test_UpdatePassword_HappyPath()
            {
                Assert.DoesNotThrowAsync(async () => {
                    await _userModel.UpdatePassword("GoodPass123$", "GoodPass1323$");
                }, "Threw an exception while updating password");
            }
            [Test]
            public void Test_UpdatePassword_BadPassword()
            {
                Assert.ThrowsAsync(Is.TypeOf<InvalidParameterFormatException>(), async () => {
                    await _userModel.UpdatePassword("GoodPass123$", "badpass");
                }, "Threw an exception while updating password");
            }
            

        }
    }
}
