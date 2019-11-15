using System;
using Model.Entities;
using Model.Exceptions;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Model.UnitTests.Tests.Coach
{
    public class UpdateExerciseTest
    {
        private CoachModel _coachModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _coachModel = new CoachModel(dataAccessLocator);
        }

        [Test]
        public void UpdateExercise_HappyPath()
        {
            var exercise = MockExercises.Exercise1();

            Assert.DoesNotThrowAsync(async () => {
                await _coachModel.UpdateExercise(exercise);
            }, "attempted to update a exercise but failed.");
        }

        [Test]
        public void UpdateExercise_NoExerciseId()
        {
            var exercise = new Exercise();

            Assert.ThrowsAsync(Is.TypeOf<InsufficientInformationException>(), async () => {
                await _coachModel.UpdateExercise(exercise);
            }, "Expected an error to be thrown when updating a exercise without a exercise id.");
        }
    }
}
