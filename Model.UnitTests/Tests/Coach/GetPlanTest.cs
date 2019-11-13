using Model.Exceptions;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Model.UnitTests.Tests.Coach
{
    public class GetPlanTest
    {
        private CoachModel _coachModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _coachModel = new CoachModel(dataAccessLocator);
        }

        [Test]
        public async Task Test_GetPlan_HappyPath()
        {
            var expected = MockPlans.Plan1();
            var actual = await _coachModel.GetPlan(expected.PlanId);

            Assert.AreEqual(expected.PlanId, actual.PlanId, "plan id does not match expected id");
            Assert.AreEqual(expected.Status, actual.Status, "plan id does not match expected id");
            Assert.AreEqual(expected.Coach.UserId, actual.Coach.UserId, "plan id does not match expected id");
        }

        [Test] 
        public void Test_GetPlan_NoPlanIdSpecified()
        {
            string planId = null;

            Assert.ThrowsAsync(Is.TypeOf<InsufficientInformationException>(), async () => {
                await _coachModel.GetPlan(planId);
            }, "Expected an error to be thrown when trying to get a plan without an id.");
        }
    }
}
