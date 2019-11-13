using Model.Entities;
using Model.Exceptions;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Model.UnitTests.Tests.Coach
{
    public class CreateWorkoutTest
    {
        private CoachModel _coachModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _coachModel = new CoachModel(dataAccessLocator);
        }

        [Test]
        public void Test_CreateWorkout_HappyPath()
        {
            var planId = MockPlans.Plan1().PlanId;
            var workout = new Workout();

            Assert.DoesNotThrowAsync(async() => {
                await _coachModel.CreateWorkout(workout, planId);
            }, "atempted to create a workout but failed.");
        }

        [Test]
        public void Test_CreateWorkout_WorkoutIdSpecidied()
        {
            var workout = MockWorkouts.Workout1();
            string planId = MockPlans.Plan1().PlanId;

            Assert.ThrowsAsync(Is.TypeOf<InvalidParametersException>(), async () => {
                await _coachModel.CreateWorkout(workout, planId);
            }, "Expected and error to be thrown when adding a workout that has an id");
        }

        [Test]
        public void Test_CreateWorkout_NoPlanIdSpecified()
        {
            var workout = new Workout();
            string planId = null;

            Assert.ThrowsAsync(Is.TypeOf<InvalidParametersException>(), async () => {
                await _coachModel.CreateWorkout(workout, planId);
            },"Expected and error to be thrown when adding a workout but not specifiting a plan");
        }
    }
}
