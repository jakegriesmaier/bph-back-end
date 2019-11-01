using Model.DataAccess.BaseAccessors;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Model.UnitTests.Mocks.MockDataAccessors
{
    public class MockWorkoutDataAccessor : WorkoutDataAccessorBase
    {
        protected override async Task CreateWorkoutCore(Workout workout, string planId)
        {
            await Task.CompletedTask;
        }

        protected override async Task<Workout> GetWorkoutCore(string workoutId)
        {
            var workout = MockWorkouts.GetWorkout(workoutId);
            return await Task.FromResult(workout);
        }
    }
}
