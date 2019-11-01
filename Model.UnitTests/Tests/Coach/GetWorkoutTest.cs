using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Model.UnitTests.Tests.Coach
{
    public class GetWorkoutTest
    {
        private CoachModel _coachModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _coachModel = new CoachModel(dataAccessLocator);
        }

        [Test]
        public async Task Test_GetWorkout_HappyPath()
        {
            var expected = MockWorkouts.Workout1(); 
            var actual = await _coachModel.GetWorkout(expected.WorkoutId);

            Assert.AreEqual(expected.WorkoutId, actual.WorkoutId, "workout id does not match what was expected.");
            Assert.AreEqual(expected.Title, actual.Title, "workout title does not match what was expected.");
            Assert.AreEqual(expected.Status, actual.Status, "workout status does not match what was expected.");
            Assert.AreEqual(expected.Date, actual.Date, "workout date does not match what was expected.");
        }

        [Test]
        public void Test_GetWorkout_NoWorkoutIdSpecified()
        {
            string workoutId = null;

            Assert.ThrowsAsync(Is.TypeOf<HttpRequestException>(), async () => {
                await _coachModel.GetWorkout(workoutId);
            }, "Expected an error to be thrown when trying to get a workout without an id.");
        }

    }
}
