using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.UnitTests.Tests.Coach
{
    public class GetPlansTest
    {
        private CoachModel _coachModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _coachModel = new CoachModel(dataAccessLocator);
        }

        [Test]
        public async Task Test_GetPlans_HappyPath()
        {
            var expected = MockPlans.Plan1();
            var actual = await _coachModel.GetPlans();

            Assert.AreEqual(expected.PlanId,actual.FirstOrDefault(p => p.PlanId == MockPlans.Plan1().PlanId).PlanId,
                "Expected the plan to be in the list of plans when getting plans but no plan matched the planId.");

            Assert.AreEqual(2,actual.Count(),
                "Expected there to be a plan in the list when getting plans but did not contain the correct number of plans.");
        }
    }
}
