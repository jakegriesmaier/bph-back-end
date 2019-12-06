using Model.DataAccess.BaseAccessors;
using Model.DataTypes;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Model.UnitTests.Mocks.MockDataAccessors
{
    public class MockExerciseDataAccessor : ExerciseDataAccessorBase
    {
        protected override async Task<string> CreateExerciseCore(Exercise exercise, string workoutId)
        {
            return await Task.FromResult(exercise.ExerciseId);
        }

        protected override async Task<bool> DeleteExerciseCore(string exerciseId)
        {
            return await Task.FromResult(true);
        }

        protected override async Task<Exercise> GetExerciseCore(string exerciseId)
        {
            var exercise = MockExercises.GetExercise(exerciseId);
            return await Task.FromResult(exercise);
        }

        protected override async Task<IEnumerable<Exercise>> GetExercisesCore(string workoutId)
        {
            var exercises = new List<Exercise> { MockExercises.Exercise1() };
            return await Task.FromResult(exercises);
        }

        protected override async Task<Exercise> UpdateExerciseCore(Exercise exercise)
        {
            return await Task.FromResult(exercise);
        }

        protected override Task<Exercise> UpdateExerciseStatusCore(string exerciseId, Status status)
        {
            throw new NotImplementedException();
        }
    }
}
