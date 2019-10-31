using Microsoft.EntityFrameworkCore;
using Model.DataAccess.BaseAccessors;
using Model.Entities;
using Persistence.EntityFramework;
using Persistence.Mappers;
using System;
using System.Collections.Generic;
using System.Net.Http;
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

        protected override async Task CreateWorkoutCore(Workout workout, string planId)
        {
            try
            {
                var plan = await _context.Plans.FindAsync(planId);
                if (plan == null)
                {
                    throw new HttpRequestException("The plan does not exist");
                }
                var workoutDao = Mapper.map(workout);
                plan.Workouts.Add(workoutDao);
                _context.Entry(plan).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return;
            }
            catch
            {
                throw;
            }
        }

        protected override async Task<Workout> GetWorkoutCore(string workoutId)
        {
            try
            {
                var workout = await _context.Workouts.FindAsync(workoutId);
                return Mapper.map(workout);
            }
            catch
            {
                throw;
            }
        }
    }
}
