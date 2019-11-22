using System;
using Model.Exceptions;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Model.UnitTests.Tests.Trainee
{
    public class GetExercisesTest
    {
        private TraineeModel _traineeModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _traineeModel = new TraineeModel(dataAccessLocator);
        }

        [Test]
        public void GetExercises_HappyPath()
        {
            string workoutId = "weee";
            Assert.DoesNotThrowAsync(async () => {
                await _traineeModel.GetExercises(workoutId);
            }, "attempted to update a exercise but failed.");
        }

        [Test]
        public void GetExercises_NullWorkoutId()
        {
            string workoutId = null;
            Assert.ThrowsAsync(Is.TypeOf<InsufficientInformationException>(), async () => {
                await _traineeModel.GetExercises(workoutId);
            }, "Expected an error to be thrown when getting exercises from a null workout id");
        }
    }
}
