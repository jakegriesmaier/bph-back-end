using System;
using Model.Entities;
using Model.Exceptions;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Model.UnitTests.Tests.Coach
{
    public class CreateSetTest
    {
        private CoachModel _coachModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _coachModel = new CoachModel(dataAccessLocator);
        }

        [Test]
        public void Test_CreateSet_HappyPath()
        {
            var exerciseId = MockExercises.Exercise1().ExerciseId;
            var set = new Set();

            Assert.DoesNotThrowAsync(async () => {
                await _coachModel.CreateSet(set, exerciseId);
            }, "atempted to create a set but failed.");
        }

        [Test]
        public void Test_CreateSet_SetIdSpecified()
        {
            var set = MockSets.Set1();
            string exerciseId = MockExercises.Exercise1().ExerciseId;

            Assert.ThrowsAsync(Is.TypeOf<InvalidParametersException>(), async () => {
                await _coachModel.CreateSet(set, exerciseId);
            }, "Expected and error to be thrown when adding a set that has an id");
        }

        [Test]
        public void Test_CreateSet_NoExerciseIdSpecified()
        {
            var set = new Set();
            string exerciseId = null;

            Assert.ThrowsAsync(Is.TypeOf<InvalidParametersException>(), async () => {
                await _coachModel.CreateSet(set, exerciseId);
            }, "Expected and error to be thrown when adding a set but not specifying a exercise");
        }
    }
}
