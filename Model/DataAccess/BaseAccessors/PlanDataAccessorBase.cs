using Model.DataTypes;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataAccess.BaseAccessors
{
    public abstract class PlanDataAccessorBase
    {
        public async Task CreatePlan(Plan plan)
        {
            await CreatePlanCore(plan);
        }

        public async Task<Plan> GetPlan(string planId)
        {
            return await GetPlanCore(planId);
        }

        public async Task<Plan> UpdatePlan(Plan plan)
        {
            return await UpdatePlanCore(plan);
        }

        public async Task<IEnumerable<Plan>> GetPlans(string userId, AccountType accountType)
        {
            return await GetPlansCore(userId,accountType);
        }

        #region necessary implementations
        protected abstract Task CreatePlanCore(Plan plan);
        protected abstract Task<Plan> GetPlanCore(string planId);
        protected abstract Task<Plan> UpdatePlanCore(Plan plan);
        protected abstract Task<IEnumerable<Plan>> GetPlansCore(string userId, AccountType accountType);
        #endregion
    }
}
