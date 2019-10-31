using Model.DataAccess.BaseAccessors;
using Model.Entities;
using Persistence.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataAccessors
{
    public class WorkoutDataAccessor : WorkoutDataAccessorBase
    {

        private BphContext _context;

        public WorkoutDataAccessor(BphContext context)
        {
            _context = context;
        }

        protected override Task CreateWorkoutCore(Workout workout, string planId)
        {
            throw new NotImplementedException();
        }

        protected override Task<Workout> GetWorkoutCore(string workoutId)
        {
            throw new NotImplementedException();
        }
    }
}
