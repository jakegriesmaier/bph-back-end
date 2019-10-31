using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataAccess.BaseAccessors
{
    public abstract class WorkoutDataAccessorBase
    {
        public async Task CreateWorkout(Workout workout, string planId)
        {
            await CreateWorkoutCore(workout, planId);
        }

        public async Task<Workout> GetWorkout(string workoutId)
        {
            return await GetWorkoutCore(workoutId);
        }

        #region necessary implementations
        protected abstract Task CreateWorkoutCore(Workout workout, string planId);
        protected abstract Task<Workout> GetWorkoutCore(string workoutId);
        #endregion
    }
}
