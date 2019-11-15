using Model.DataAccess.BaseAccessors;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Model.UnitTests.Mocks.MockDataAccessors
{
    public class MockExerciseDataAccessor : ExerciseDataAccessorBase
    {
        protected override Task<string> CreateExerciseCore(Exercise exercise)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> DeleteExerciseCore(string exerciseId)
        {
            throw new NotImplementedException();
        }

        protected override Task<Exercise> GetExerciseCore(string exerciseId)
        {
            throw new NotImplementedException();
        }

        protected override Task<IEnumerable<Exercise>> GetExercisesCore(string workoutId)
        {
            throw new NotImplementedException();
        }

        protected override Task<Exercise> UpdateExerciseCore(Exercise exercise)
        {
            throw new NotImplementedException();
        }
    }
}
