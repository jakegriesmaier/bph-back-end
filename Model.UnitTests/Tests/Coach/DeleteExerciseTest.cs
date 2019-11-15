using System;
using Model.Exceptions;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Model.UnitTests.Tests.Coach
{
    public class DeleteExerciseTest
    {
        private CoachModel _coachModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _coachModel = new CoachModel(dataAccessLocator);
        }

        [Test]
        public void DeleteExercise_HappyPath()
        {
            string exerciseId = "ilikepizza";

            Assert.DoesNotThrowAsync(async () => {
                await _coachModel.DeleteExercise(exerciseId);
            }, "attempted to delete a exercise but failed.");
        }

        [Test]
        public void DeleteExercise_NullExerciseId()
        {

            string exerciseId = null;
            Assert.ThrowsAsync(Is.TypeOf<InsufficientInformationException>(), async () => {
                await _coachModel.DeleteExercise(exerciseId);
            }, "Expected an error to be thrown when deleting a exercise without a exercise id.");
        }
    }
}
