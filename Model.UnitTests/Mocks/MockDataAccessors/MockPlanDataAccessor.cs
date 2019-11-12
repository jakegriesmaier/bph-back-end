using Model.DataAccess.BaseAccessors;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Model.UnitTests.Mocks.MockDataAccessors
{
    public class MockPlanDataAccessor : PlanDataAccessorBase
    {
        protected override async Task CreatePlanCore(Plan plan)
        {
            await Task.CompletedTask;
        }

        protected override async Task<Plan> GetPlanCore(string planId)
        {
            var plan = MockPlans.GetPlan(planId);
            return await Task.FromResult(plan);
        }
        protected override async Task<Plan> UpdatePlanCore(Plan plan)
        {
            return await Task.FromResult(plan);
        }
    }
}
