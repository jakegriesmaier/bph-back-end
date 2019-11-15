using Model.DataAccess.BaseAccessors;
using Model.Entities;
using Persistence.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataAccessors
{
    public class ExerciseDataAccessor : ExerciseDataAccessorBase
    {

        private BphContext _context;

        public ExerciseDataAccessor(BphContext context)
        {
            _context = context;
        }

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
