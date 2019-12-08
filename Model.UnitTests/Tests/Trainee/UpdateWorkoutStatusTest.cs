using Model.DataTypes;
using Model.Exceptions;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.UnitTests.Tests.Trainee
{
    public class UpdateWorkoutStatusTest
    {
        private TraineeModel _traineeModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _traineeModel = new TraineeModel(dataAccessLocator);
        }

        [Test]
        public void Test_UpdateWorkoutStatus_HappyPath()
        {
            var workouId = MockWorkouts.Workout1().WorkoutId;
            Assert.DoesNotThrowAsync(async () => {
                await _traineeModel.UpdateWorkoutStatus(workouId, Status.Completed);
            }, "Unable to update the workout's status. Error was thrown when not expected.");
        }

        [Test]
        public void Test_UpdateWorkoutStatus_NoExerciseSpecified()
        {
            string workouId = null;
            Assert.ThrowsAsync(Is.TypeOf<InsufficientInformationException>(), async () =>
            {
                await _traineeModel.UpdateWorkoutStatus(workouId, Status.Completed);
            }, "Expected an error to be thrown when updating an workout without a workout id.");
        }

        [Test]
        public void Test_UpdateWorkoutStatus_ExerciseIdEmptyString()
        {
            string workouId = "";
            Assert.ThrowsAsync(Is.TypeOf<InsufficientInformationException>(), async () =>
            {
                await _traineeModel.UpdateWorkoutStatus(workouId, Status.Completed);
            }, "Expected an error to be thrown when updating an workout with an empty string workout id.");
        }
    }
}
