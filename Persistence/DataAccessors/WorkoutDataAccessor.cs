using Microsoft.EntityFrameworkCore;
using Model.DataAccess.BaseAccessors;
using Model.DataTypes;
using Model.Entities;
using Persistence.DataExceptions;
using Persistence.DataAccessObjects;
using Persistence.EntityFramework;
using Persistence.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    throw new ParentDoesNotExistException("","");
                }
                var workoutDao = Mapper.map(workout);
                workoutDao.PlanId = plan.PlanId;
                if (workoutDao.Date == DateTime.MinValue) workoutDao.Date = DateTime.Now;
                _context.Workouts.Add(workoutDao);
                await _context.SaveChangesAsync();
                return workoutDao.Id;
            }
            catch (Exception e)
            {
                throw ExceptionHandler.HandleException(e, "");
            }
        }

        protected override async Task<bool> DeleteWorkoutCore(string workoutId)
        {
            try
            {
                var workout = await _context.Workouts.FindAsync(workoutId);

                // get all of the exercises in the plan
                var exercises = _context.Exercises.Where(ex => ex.WorkoutId == workout.Id).ToList();

                // get all of the sets in the plan
                var sets = new List<SetDAO>();
                exercises.ForEach(ex => {
                    sets.AddRange(_context.Sets.Where(s => s.ExerciseId == ex.Id));
                });

                // get all of the comments in the plan
                var comments = new List<CommentDAO>();
                comments.AddRange(_context.Comments.Where(c => c.OwnerId == workout.Id));
                exercises.ForEach(ex => comments.AddRange(_context.Comments.Where(c => c.OwnerId == ex.Id)));
                sets.ForEach(s => comments.AddRange(_context.Comments.Where(c => c.OwnerId == s.Id)));

                //delete all of the objects associated with the plan
                _context.Comments.RemoveRange(comments);
                _context.Sets.RemoveRange(sets);
                _context.Exercises.RemoveRange(exercises);
                _context.Workouts.Remove(workout);

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw ExceptionHandler.HandleException(e, "");
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
            catch (Exception e)
            {
                throw ExceptionHandler.HandleException(e, "");
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
            catch (Exception e)
            {
                throw ExceptionHandler.HandleException(e, "");
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
            catch (Exception e)
            {
                throw ExceptionHandler.HandleException(e, "");
            }
        }

        protected override async Task<Workout> UpdateWorkoutStatusCore(string workoutId, Status status)
        {
            try
            {
                var workout = await _context.Workouts.FindAsync(workoutId);
                workout.Status = status;
                _context.Entry(workout).Property(w => w.Status).IsModified = true;
                await _context.SaveChangesAsync();
                await CheckPlanUpdateStatus(workout.PlanId, status);
                workout.Exercises = _context.Exercises.Where(e => e.WorkoutId == workout.Id).ToList();
                workout.Comments = _context.Comments.Where(e => e.OwnerId == workout.Id).ToList();
                return Mapper.map(workout);
            }
            catch (Exception e)
            {
                throw ExceptionHandler.HandleException(e, "");
            }
        }

        private async Task CheckPlanUpdateStatus(string planId, Status status)
        {
            try
            {
                var plan = await _context.Plans.FindAsync(planId);
                if (plan == null)
                {
                    throw new ParentDoesNotExistException("","");
                }
                var workouts = _context.Workouts.Where(wo => wo.PlanId == planId).ToList();
                if (!workouts.Any(wo => wo.Status != status))
                {
                    // all of the workouts in the plan are the same status
                    plan.Status = status;
                    _context.Entry(plan).Property(p => p.Status).IsModified = true;
                    await _context.SaveChangesAsync();
                    return;
                }
            }
            catch (Exception e)
            {
                throw ExceptionHandler.HandleException(e, "");
            }
        }
    }
}
