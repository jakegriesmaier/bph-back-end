using System;
using Model.Entities;
using Model.Exceptions;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Model.UnitTests.Tests.Coach
{
    public class UpdateSetTest
    {
        private CoachModel _coachModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _coachModel = new CoachModel(dataAccessLocator);
        }

        [Test]
        public void UpdateSet_HappyPath()
        {
            var set = MockSets.Set1();

            Assert.DoesNotThrowAsync(async () => {
                await _coachModel.UpdateSet(set);
            }, "attempted to update a set but failed.");
        }

        [Test]
        public void UpdateSet_NoSetId()
        {
            var set = new Set();

            Assert.ThrowsAsync(Is.TypeOf<InsufficientInformationException>(), async () => {
                await _coachModel.UpdateSet(set);
            }, "Expected an error to be thrown when updating a set without a set id.");
        }
    }
}
