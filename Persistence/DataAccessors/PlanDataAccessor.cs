using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Model.DataAccess.BaseAccessors;
using Model.DataTypes;
using Model.Entities;
using Persistence.EntityFramework;
using Persistence.Mappers;
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
            catch
            {
                throw;
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
            catch
            {
                throw;
            }
        }

        protected override async Task<IEnumerable<Plan>> GetPlansCore(User user, AccountType accountType)
        {
            try
            {
                var plans = await _context.Plans.ToListAsync();
                plans.ForEach(p => p.Workouts = _context.Workouts.Where(w => w.PlanId == p.PlanId).ToList());
                return plans.Select(p => Mapper.map(p)).ToList();
            }
            catch
            {
                throw;
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
            catch
            {
                throw;
            }
        }
    }
}
