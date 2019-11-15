using System;
using Model.Exceptions;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Model.UnitTests.Tests.Coach
{
    public class GetExerciseTest
    {
        private CoachModel _coachModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _coachModel = new CoachModel(dataAccessLocator);
        }

        [Test]
        public void GetExercise_HappyPath()
        {
            string exerciseId = "weee";
            Assert.DoesNotThrowAsync(async () => {
                await _coachModel.GetExercise(exerciseId);
            }, "attempted to get an exercise but failed.");
        }

        [Test]
        public void GetExercise_NullExerciseId()
        {
            string exerciseId = null;
            Assert.ThrowsAsync(Is.TypeOf<InsufficientInformationException>(), async () => {
                await _coachModel.GetExercise(exerciseId);
            }, "Expected an error to be thrown when getting exercise from a null exercise id");
        }
    }
}
