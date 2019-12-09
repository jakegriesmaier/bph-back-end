using Model.Exceptions;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.UnitTests.Tests.Coach
{
    public class DeleteWorkoutTest
    {
        private CoachModel _coachModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _coachModel = new CoachModel(dataAccessLocator);
        }

        [Test]
        public void Test_DeleteWorkout_HappyPath()
        {
            var workoutId = "workout to delete";

            Assert.DoesNotThrowAsync(async () => {
                await _coachModel.DeleteWorkout(workoutId);
            }, "Threw an exception when trying to delete a workout.");
        }

        [Test]
        public void Test_DeleteWorkout_NoWorkoutId()
        {
            string workoutId = null;
            Assert.ThrowsAsync(Is.TypeOf<InsufficientInformationException>(), async () => {
                await _coachModel.DeleteWorkout(workoutId);
            }, "Expected an error to be thrown when deleting a workout without a workout id.");
        }

        [Test]
        public void Test_DeleteWorkout_WorkoutIdEmptyString()
        {
            string workoutId = "";
            Assert.ThrowsAsync(Is.TypeOf<InsufficientInformationException>(), async () => {
                await _coachModel.DeleteWorkout(workoutId);
            }, "Expected an error to be thrown when deleting a workout without an empty string workout id.");
        }
    }
}
