using System;
using Model.Exceptions;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Model.UnitTests.Tests.Trainee
{
    public class GetCommentsTest
    {
        private TraineeModel _traineeModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _traineeModel = new TraineeModel(dataAccessLocator);
        }

        [Test]
        public void GetComments_HappyPath()
        {
            string ownerId = "weee";
            Assert.DoesNotThrowAsync(async () => {
                await _traineeModel.GetComments(ownerId);
            }, "attempted to get comments but failed.");
        }

        [Test]
        public void GetComments_NullOwnerId()
        {
            string ownerId = null;
            Assert.ThrowsAsync(Is.TypeOf<InsufficientInformationException>(), async () => {
                await _traineeModel.GetComments(ownerId);
            }, "Expected an error to be thrown when getting comments with a null owner Id.");
        }
    }
}
