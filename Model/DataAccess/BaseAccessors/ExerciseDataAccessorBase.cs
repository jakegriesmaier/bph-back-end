using Model.DataTypes;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataAccess.BaseAccessors
{
    public abstract class ExerciseDataAccessorBase
    {

        public async Task<string> CreateExercise(Exercise exercise, string workoutId)
        {
            return await CreateExerciseCore(exercise,workoutId);
        }

        public async Task<Exercise> GetExercise(string exerciseId)
        {
            return await GetExerciseCore(exerciseId);
        }

        public async Task<Exercise> UpdateExercise(Exercise exercise)
        {
            return await UpdateExerciseCore(exercise);
        }

        public async Task<bool> DeleteExercise(string exerciseId)
        {
            return await DeleteExerciseCore(exerciseId);
        }

        public async Task<IEnumerable<Exercise>> GetExercises(string workoutId)
        {
            return await GetExercisesCore(workoutId);
        }

        public async Task<Exercise> UpdateExerciseStatus(string exerciseId, Status status)
        {
            return await UpdateExerciseStatusCore(exerciseId, status);
        }

        #region necessary implementations
        protected abstract Task<string> CreateExerciseCore(Exercise exercise, string workoutId);
        protected abstract Task<Exercise> GetExerciseCore(string exerciseId);
        protected abstract Task<Exercise> UpdateExerciseCore(Exercise exercise);
        protected abstract Task<bool> DeleteExerciseCore(string exerciseId);
        protected abstract Task<IEnumerable<Exercise>> GetExercisesCore(string workoutId);
        protected abstract Task<Exercise> UpdateExerciseStatusCore(string exerciseId, Status status);
        #endregion
    }
}
