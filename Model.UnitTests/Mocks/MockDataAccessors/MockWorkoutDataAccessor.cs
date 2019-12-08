using Model.DataAccess.BaseAccessors;
using Model.DataTypes;
using Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Model.UnitTests.Mocks.MockDataAccessors
{
    public class MockWorkoutDataAccessor : WorkoutDataAccessorBase
    {
        protected override async Task<string> CreateWorkoutCore(Workout workout, string planId)
        {
            var workoutId = MockWorkouts.Workout1().WorkoutId;
            return await Task.FromResult(workoutId);
        }

        protected override async Task<Workout> GetWorkoutCore(string workoutId)
        {
            var workout = MockWorkouts.GetWorkout(workoutId);
            return await Task.FromResult(workout);
        }

        protected override async Task<IEnumerable<Workout>> GetWorkoutsCore(string planId)
        {
            var workouts = new List<Workout> { MockWorkouts.Workout1() };
            return await Task.FromResult(workouts);
        }

        protected override async Task<Workout> UpdateWorkoutCore(Workout workout)
        {
            return await Task.FromResult(workout);
        }

        protected override async Task<Workout> UpdateWorkoutStatusCore(string workoutId, Status status)
        {
            var workout = MockWorkouts.Workout1();
            return await Task.FromResult(workout);
        }
    }
}
