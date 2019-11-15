using System;
using Model.Entities;
using Model.Exceptions;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Model.UnitTests.Tests.Coach
{
    public class UpdateWorkoutTest
    {
        private CoachModel _coachModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _coachModel = new CoachModel(dataAccessLocator);
        }

        [Test]
        public void UpdateWorkout_HappyPath()
        {
            var workout = MockWorkouts.Workout1();

            Assert.DoesNotThrowAsync(async () => {
                await _coachModel.UpdateWorkout(workout);
            }, "attempted to update a workout but failed.");
        }

        [Test]
        public void UpdateWorkout_NoWorkoutId()
        {
            var workout = new Workout();

            Assert.ThrowsAsync(Is.TypeOf<InsufficientInformationException>(), async () => {
                await _coachModel.UpdateWorkout(workout);
            }, "Expected and error to be thrown when adding a workout but not specifying a plan");
        }
    }
}
