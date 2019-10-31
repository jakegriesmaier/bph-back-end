using System;
using NUnit.Framework;

namespace Model.UnitTests
{
    public class UserControllerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LoginUserTest()
        {
            Assert.AreEqual(true, CredentialsValidator.ValidateEmail(goodEmail), "Marked a good email as bad");
        }
    }
}
