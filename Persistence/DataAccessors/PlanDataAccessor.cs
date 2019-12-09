using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Model.DataAccess.BaseAccessors;
using Model.DataTypes;
using Model.Entities;
using Persistence.DataAccessObjects;
using Persistence.DataExceptions;
using Persistence.EntityFramework;
using Persistence.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.DataAccessors
{
    public class PlanDataAccessor : PlanDataAccessorBase
    {

        private BphContext _context;
        private UserManager<ApplicationUser> _userManager;

        public PlanDataAccessor(BphContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        protected override async Task<string> CreatePlanCore(Plan plan)
        {
            var planDao = Mapper.map(plan);
            try
            {
                _context.Plans.Add(planDao);
                var result = await _context.SaveChangesAsync();
                return planDao.PlanId;
            }
            catch (Exception e)
            {
                throw ExceptionHandler.HandleException(e, "");
            }
        }

        protected override async Task<bool> DeletePlanCore(string planId)
        {
            try
            {
                var plan = await _context.Plans.FindAsync(planId);

                // get all of the workouts in the plan
                var workouts = _context.Workouts.Where(w => w.PlanId == planId).ToList();

                // get all of the exercises in the plan
                var exercises = new List<ExerciseDAO>();
                workouts.ForEach(w => {
                    exercises.AddRange(_context.Exercises.Where(ex => ex.WorkoutId == w.Id));
                });

                // get all of the sets in the plan
                var sets = new List<SetDAO>();
                exercises.ForEach(ex => {
                    sets.AddRange(_context.Sets.Where(s => s.ExerciseId == ex.Id));
                });

                // get all of the comments in the plan
                var comments = new List<CommentDAO>();
                workouts.ForEach(wo => comments.AddRange(_context.Comments.Where(c => c.OwnerId == wo.Id)));
                exercises.ForEach(ex => comments.AddRange(_context.Comments.Where(c => c.OwnerId == ex.Id)));
                sets.ForEach(s => comments.AddRange(_context.Comments.Where(c => c.OwnerId == s.Id)));

                //delete all of the objects associated with the plan
                _context.Comments.RemoveRange(comments);
                _context.Sets.RemoveRange(sets);
                _context.Exercises.RemoveRange(exercises);
                _context.Workouts.RemoveRange(workouts);
                _context.Plans.Remove(plan);
                              
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw ExceptionHandler.HandleException(e, "");
            }
        }

        protected override async Task<Plan> GetPlanCore(string planId)
        {
            try
            {
                var plan = await _context.Plans.FindAsync(planId);
                var workouts = _context.Workouts.Where(w => w.PlanId == planId).ToList();
                plan.Workouts = workouts;
                return Mapper.map(plan);
            }
            catch (Exception e)
            {
                throw ExceptionHandler.HandleException(e, "");
            }
        }

        protected override async Task<IEnumerable<Plan>> GetPlansCore(User user, AccountType accountType)
        {
            try
            {
                var plans = await _context.Plans.ToListAsync();
                if (accountType == AccountType.Coach)
                {
                    plans = plans.Where(p => p.CoachId == user.UserId).ToList();
                }
                else
                {
                    plans = plans.Where(p => p.TraineeId == user.UserId).ToList();
                }
                plans.ForEach(p => p.Workouts = _context.Workouts.Where(w => w.PlanId == p.PlanId).ToList());
                return plans.Select(p => Mapper.map(p)).ToList();
            }
            catch (Exception e)
            {
                throw ExceptionHandler.HandleException(e, "");
            }
        }

        protected override async Task<Plan> UpdatePlanCore(Plan plan)
        {
            try
            {
                var planDao = Mapper.map(plan);
                _context.Entry(planDao).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                var workouts = _context.Workouts.Where(w => w.PlanId == planDao.PlanId).ToList();
                planDao.Workouts = workouts;
                return Mapper.map(planDao);
            }
            catch (Exception e)
            {
                throw ExceptionHandler.HandleException(e, "");
            }
        }
    }
}
