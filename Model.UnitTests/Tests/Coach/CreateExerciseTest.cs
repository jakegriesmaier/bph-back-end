using System;
using Model.Entities;
using Model.Exceptions;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Model.UnitTests.Tests.Coach
{
    public class CreateExerciseTest
    {
        private CoachModel _coachModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _coachModel = new CoachModel(dataAccessLocator);
        }

        [Test]
        public void Test_CreateExercise_HappyPath()
        {
            var workoutId = MockWorkouts.Workout1().WorkoutId;
            var exercise = new Exercise();

            Assert.DoesNotThrowAsync(async () => {
                await _coachModel.CreateExercise(exercise, workoutId);
            }, "atempted to create a exercise but failed.");
        }

        [Test]
        public void Test_CreateExercise_ExerciseIdSpecified()
        {
            var exercise = MockExercises.Exercise1();
            string workoutId = MockWorkouts.Workout1().WorkoutId;

            Assert.ThrowsAsync(Is.TypeOf<InvalidParametersException>(), async () => {
                await _coachModel.CreateExercise(exercise, workoutId);
            }, "Expected and error to be thrown when adding a exercise that has an id");
        }

        [Test]
        public void Test_CreateExercise_NoWorkoutIdSpecified()
        {
            var exercise = new Exercise();
            string workoutId = null;

            Assert.ThrowsAsync(Is.TypeOf<InvalidParametersException>(), async () => {
                await _coachModel.CreateExercise(exercise, workoutId);
            }, "Expected and error to be thrown when adding a exercise but not specifiting a workout");
        }
    }
}
