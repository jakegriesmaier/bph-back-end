using Model.DataTypes;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataAccess.BaseAccessors
{
    public abstract class WorkoutDataAccessorBase
    {
        public async Task<string> CreateWorkout(Workout workout, string planId)
        {
            return await CreateWorkoutCore(workout, planId);
        }

        public async Task<Workout> GetWorkout(string workoutId)
        {
            return await GetWorkoutCore(workoutId);
        }

        public async Task<Workout> UpdateWorkout(Workout workout)
        {
            return await UpdateWorkoutCore(workout);
        }

        public async Task<IEnumerable<Workout>> GetWorkouts(string planId)
        {
            return await GetWorkoutsCore(planId);
        }

        public async Task<Workout> UpdateWorkoutStatus(string workoutId, Status status)
        {
            return await UpdateWorkoutStatusCore(workoutId, status);
        }


        #region necessary implementations
        protected abstract Task<string> CreateWorkoutCore(Workout workout, string planId);
        protected abstract Task<Workout> GetWorkoutCore(string workoutId);
        protected abstract Task<Workout> UpdateWorkoutCore(Workout workout);
        protected abstract Task<IEnumerable<Workout>> GetWorkoutsCore(string planId);
        protected abstract Task<Workout> UpdateWorkoutStatusCore(string workoutId, Status status);
        #endregion
    }
}
