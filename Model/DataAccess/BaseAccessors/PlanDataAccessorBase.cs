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
        public async Task<string> CreatePlan(Plan plan)
        {
            return await CreatePlanCore(plan);
        }

        public async Task<Plan> GetPlan(string planId)
        {
            return await GetPlanCore(planId);
        }

        public async Task<Plan> UpdatePlan(Plan plan)
        {
            return await UpdatePlanCore(plan);
        }

        public async Task<IEnumerable<Plan>> GetPlans(User user, AccountType accountType)
        {
            return await GetPlansCore(user, accountType);
        }

        public async Task<bool> DeletePlan(string planId)
        {
            return await DeletePlanCore(planId);
        }

        #region necessary implementations
        protected abstract Task<string> CreatePlanCore(Plan plan);
        protected abstract Task<Plan> GetPlanCore(string planId);
        protected abstract Task<Plan> UpdatePlanCore(Plan plan);
        protected abstract Task<IEnumerable<Plan>> GetPlansCore(User user, AccountType accountType);
        protected abstract Task<bool> DeletePlanCore(string planId);
        #endregion
    }
}
