using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.UnitTests.Tests.Trainee
{
    public class GetPlansTest
    {
        private TraineeModel _traineeModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _traineeModel = new TraineeModel(dataAccessLocator);
        }

        [Test]
        public async Task Test_GetPlans_HappyPath()
        {
            var expected = MockPlans.Plan1();
            var actual = await _traineeModel.GetPlans();

            Assert.AreEqual(expected.PlanId, actual.FirstOrDefault(p => p.PlanId == MockPlans.Plan1().PlanId).PlanId,
                "Expected the plan to be in the list of plans when getting plans but no plan matched the planId.");
        }

        [Test]
        public async Task Test_GetPlans_NoDraftPlansReturned()
        {
            var badPlanId = MockPlans.DraftPlan().PlanId;
            var actual = await _traineeModel.GetPlans();

            Assert.AreEqual(false, actual.Any(p => p.PlanId == badPlanId),
                "Expected no plans to be returned with status of draft but a plan with status of draft was returned.");
        }



    }
}
