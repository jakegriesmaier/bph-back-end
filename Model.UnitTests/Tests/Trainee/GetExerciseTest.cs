using System;
using Model.Exceptions;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Model.UnitTests.Tests.Trainee
{
    public class GetExerciseTest
    {
        private TraineeModel _traineeModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _traineeModel = new TraineeModel(dataAccessLocator);
        }

        [Test]
        public void GetExercise_HappyPath()
        {
            string exerciseId = "weee";
            Assert.DoesNotThrowAsync(async () => {
                await _traineeModel.GetExercise(exerciseId);
            }, "attempted to get an exercise but failed.");
        }

        [Test]
        public void GetExercise_NullExerciseId()
        {
            string exerciseId = null;
            Assert.ThrowsAsync(Is.TypeOf<InsufficientInformationException>(), async () => {
                await _traineeModel.GetExercise(exerciseId);
            }, "Expected an error to be thrown when getting exercise from a null exercise id");
        }
    }
}
