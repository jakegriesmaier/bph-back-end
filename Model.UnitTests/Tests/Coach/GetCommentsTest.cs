using System;
using Model.Exceptions;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Model.UnitTests.Tests.Coach
{
    public class GetCommentsTest
    {
        private CoachModel _coachModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _coachModel = new CoachModel(dataAccessLocator);
        }

        [Test]
        public void GetComments_HappyPath()
        {
            string ownerId = "weee";
            Assert.DoesNotThrowAsync(async () => {
                await _coachModel.GetComments(ownerId);
            }, "attempted to get comments but failed.");
        }

        [Test]
        public void GetComments_NullOwnerId()
        {
            string ownerId = null;
            Assert.ThrowsAsync(Is.TypeOf<InsufficientInformationException>(), async () => {
                await _coachModel.GetComments(ownerId);
            }, "Expected an error to be thrown when getting comments with a null owner Id.");
        }
    }
}
