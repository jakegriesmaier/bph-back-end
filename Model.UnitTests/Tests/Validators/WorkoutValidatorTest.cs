using System;
using Model.Entities;
using Model.Models.Validators;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Model.UnitTests.Tests.Validators
{
    public class WorkoutValidatorTest
    {
        Workout filledOutWorkout = MockWorkouts.Workout1();
        Workout emptyWorkout = new Workout();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ValidateCreateWorkout_HappyPath()
        {
            Assert.AreEqual(true, WorkoutValidator.ValidateCreateWorkout(emptyWorkout, "20103"), "Marked a good workout as bad");
        }
        [Test]
        public void ValidateCreateWorkout_NullPlanId()
        {
            Assert.AreEqual(false, WorkoutValidator.ValidateCreateWorkout(filledOutWorkout, null), "Marked a bad workout (no Plan Id) as good");
        }
        [Test]
         public void ValidateCreateWorkout_NonNullWorkoutId()
        {
            Assert.AreEqual(false, WorkoutValidator.ValidateCreateWorkout(filledOutWorkout, "2124"), "Marked a bad workout (Non-null Workout ID) as good");
        }

        [Test]
        public void ValidateGetWorkout_HappyPath()
        {
            Assert.AreEqual(true, WorkoutValidator.ValidateGetWorkout(filledOutWorkout.WorkoutId), "Marked a good ValidateGetWorkout as bad");
        }
        [Test]
        public void ValidateGetWorkout_NullWorkoutId()
        {
            Assert.AreEqual(false, WorkoutValidator.ValidateGetWorkout(null), "Marked a bad workout (no Plan Id) as good");
        }


    }
}
