using System;
using Model.Exceptions;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Model.UnitTests.Tests.Coach
{
    public class GetSetsTest
    {
        private CoachModel _coachModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _coachModel = new CoachModel(dataAccessLocator);
        }

        [Test]
        public void GetSets_HappyPath()
        {
            string exerciseId = "weee";
            Assert.DoesNotThrowAsync(async () => {
                await _coachModel.GetSets(exerciseId);
            }, "attempted to update a set but failed.");
        }

        [Test]
        public void GetSets_NullExerciseId()
        {
            string exerciseId = null;
            Assert.ThrowsAsync(Is.TypeOf<InsufficientInformationException>(), async () => {
                await _coachModel.GetSets(exerciseId);
            }, "Expected an error to be thrown when getting sets from a null exercise id");
        }
    }
}
