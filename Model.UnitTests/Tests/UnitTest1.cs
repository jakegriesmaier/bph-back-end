using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            // Create a mock DataAccessLocator so we dont actually have to call the database
            var dataAccessLocator = new MockDataAccessLocator();
            // create the neccessary model
            var userModel = new UserModel(dataAccessLocator);
            //...
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}