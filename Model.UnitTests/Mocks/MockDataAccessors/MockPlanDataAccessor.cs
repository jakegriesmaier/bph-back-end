using Model.DataAccess.BaseAccessors;
using Model.DataTypes;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Model.UnitTests.Mocks.MockDataAccessors
{
    public class MockPlanDataAccessor : PlanDataAccessorBase
    {
        protected override async Task<string> CreatePlanCore(Plan plan)
        {
            return await Task.FromResult(MockPlans.Plan1().PlanId);
        }

        protected override async Task<Plan> GetPlanCore(string planId)
        {
            var plan = MockPlans.GetPlan(planId);
            return await Task.FromResult(plan);
        }

        protected override async Task<IEnumerable<Plan>> GetPlansCore(User user, AccountType accountType)
        {
            var plan = MockPlans.Plan1();
            return await Task.FromResult(new List<Plan> { plan });
        }

        protected override async Task<Plan> UpdatePlanCore(Plan plan)
        {
            return await Task.FromResult(plan);
        }
    }
}
