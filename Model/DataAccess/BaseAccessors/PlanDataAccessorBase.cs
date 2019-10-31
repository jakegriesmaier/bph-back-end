﻿using Model.Entities;
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

        #region necessary implementations
        protected abstract Task CreatePlanCore(Plan plan);
        protected abstract Task<Plan> GetPlanCore(string planId);
        #endregion
    }
}