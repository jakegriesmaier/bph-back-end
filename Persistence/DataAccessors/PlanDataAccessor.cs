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

        protected override async Task CreatePlanCore(Plan plan)
        {
            var planDao = Mapper.map(plan);
            try
            {
                _context.Plans.Add(planDao);
                var result = await _context.SaveChangesAsync();
                return;
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
                if (plan.CoachId != null)
                {
                    plan.Coach = await _userManager.FindByIdAsync(plan.CoachId);
                }
                if (plan.TraineeId != null)
                {
                    plan.Trainee = await _userManager.FindByIdAsync(plan.TraineeId);
                }
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
                var userDao = Mapper.map(user);
                plans.ForEach(async p => {
                    if(p.CoachId != null)
                    {
                        p.Coach = (p.CoachId == userDao.Id) ? userDao  
                        : await _userManager.FindByIdAsync(p.CoachId);
                    }
                    if(p.TraineeId != null)
                    {
                        p.Trainee = (p.TraineeId == userDao.Id) ? userDao
                        : await _userManager.FindByIdAsync(p.TraineeId);
                    }
                });
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
                if (planDao.CoachId != null)
                {
                    planDao.Coach = await _userManager.FindByIdAsync(planDao.CoachId);
                }
                if (planDao.TraineeId != null)
                {
                    planDao.Trainee = await _userManager.FindByIdAsync(planDao.TraineeId);
                }
                return Mapper.map(planDao);
            }
            catch
            {
                throw;
            }
        }
    }
}
