using Microsoft.EntityFrameworkCore;
using Model.DataAccess.BaseAccessors;
using Model.Entities;
using Persistence.EntityFramework;
using Persistence.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
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

        protected override async Task<string> CreateWorkoutCore(Workout workout, string planId)
        {
            try
            {
                var plan = await _context.Plans.FindAsync(planId);
                if (plan == null)
                {
                    throw new HttpRequestException("The plan does not exist");
                }
                var workoutDao = Mapper.map(workout);
                workoutDao.PlanId = plan.PlanId;
                if (workoutDao.Date == DateTime.MinValue) workoutDao.Date = DateTime.Now;
                _context.Workouts.Add(workoutDao);
                await _context.SaveChangesAsync();
                return workoutDao.Id;
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
                workout.Exercises = _context.Exercises.Where(e => e.WorkoutId == workout.Id).ToList();
                workout.Comments = _context.Comments.Where(e => e.OwnerId == workout.Id).ToList();
                return Mapper.map(workout);
            }
            catch
            {
                throw;
            }
        }

        protected override async Task<IEnumerable<Workout>> GetWorkoutsCore(string planId)
        {
            try
            {
                var workouts = await _context.Workouts.Where(w => w.PlanId == planId).ToListAsync();
                workouts.ForEach(w => w.Exercises = _context.Exercises.Where(e => e.WorkoutId == w.Id).ToList());
                workouts.ForEach(w => w.Comments = _context.Comments.Where(e => e.OwnerId == w.Id).ToList());
                return workouts.Select(w => Mapper.map(w)).ToList();
            }
            catch
            {
                throw;
            }
        }

        protected override async Task<Workout> UpdateWorkoutCore(Workout workout)
        {
            try
            {
                var workoutDao = Mapper.map(workout);
                _context.Entry(workoutDao).State = EntityState.Modified;
                _context.Entry(workoutDao).Property(w => w.PlanId).IsModified = false;
                await _context.SaveChangesAsync();
                workoutDao.Exercises = _context.Exercises.Where(e => e.WorkoutId == workoutDao.Id).ToList();
                workoutDao.Comments = _context.Comments.Where(e => e.OwnerId == workoutDao.Id).ToList();
                return Mapper.map(workoutDao);
            }
            catch
            {
                throw;
            }
        }
    }
}
