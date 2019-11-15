using System;
using Model.Exceptions;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Model.UnitTests.Tests.Coach
{
    public class DeleteSetTest
    {
        private CoachModel _coachModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _coachModel = new CoachModel(dataAccessLocator);
        }

        [Test]
        public void DeleteSet_HappyPath()
        {
            string setId = "ilikepizza";

            Assert.DoesNotThrowAsync(async () => {
                await _coachModel.DeleteSet(setId);
            }, "attempted to delete a set but failed.");
        }

        [Test]
        public void DeleteSet_NullSetId()
        {

            string setId = null;
            Assert.ThrowsAsync(Is.TypeOf<InsufficientInformationException>(), async () => {
                await _coachModel.DeleteSet(setId);
            }, "Expected an error to be thrown when deleting a set without a set id.");
        }
    }
}
