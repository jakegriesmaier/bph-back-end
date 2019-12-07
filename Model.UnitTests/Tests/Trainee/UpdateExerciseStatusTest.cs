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
    public class UpdateExerciseStatusTest
    {
        private TraineeModel _traineeModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _traineeModel = new TraineeModel(dataAccessLocator);
        }

        [Test]
        public void Test_UpdateExerciseStatus_HappyPath()
        {
            var exerciseId = MockExercises.Exercise1().ExerciseId;
            Assert.DoesNotThrowAsync(async () => {
                await _traineeModel.UpdateExerciseStatus(exerciseId, Status.Completed);
            }, "Unable to update the exercise's status. Error was thrown when not expected.");
        }

        [Test]
        public void Test_UpdateExerciseStatus_NoExerciseSpecified()
        {
            string exerciseId = null;
            Assert.ThrowsAsync(Is.TypeOf<InsufficientInformationException>(), async () =>
            {
                await _traineeModel.UpdateExerciseStatus(exerciseId,Status.Completed);
            }, "Expected an error to be thrown when updating an exercise without an exercise id.");
        }
        
        [Test]
        public void Test_UpdateExerciseStatus_ExerciseIdEmptyString()
        {
            string exerciseId = "";
            Assert.ThrowsAsync(Is.TypeOf<InsufficientInformationException>(), async () =>
            {
                await _traineeModel.UpdateExerciseStatus(exerciseId, Status.Completed);
            }, "Expected an error to be thrown when updating an exercise with an empty string exercise id.");
        }
    }
}
