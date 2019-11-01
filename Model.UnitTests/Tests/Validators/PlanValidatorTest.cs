using System;
using Model.Entities;
using Model.Models.Validators;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Model.UnitTests.Tests.Validators
{
    public class PlanValidatorTest
    {
        Plan mockPlan = MockPlans.Plan1();
        Plan noCoach = MockPlans.NoCoach();
        Plan noId = MockPlans.NoId();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ValidateCreatePlan_HappyPath()
        {
            Assert.AreEqual(true, PlanValidator.ValidateCreatePlan(mockPlan), "Marked a good plan as bad");
        }
        [Test]
        public void ValidateCreatePlan_NullPlanId()
        {
            Assert.AreEqual(false, PlanValidator.ValidateCreatePlan(noId), "Marked a bad Plan (Null Id) as good");
        }
        [Test]
        public void ValidateCreatePlan_NoCoach()
        {
            Assert.AreEqual(false, PlanValidator.ValidateCreatePlan(noCoach), "Marked a bad Plan (Null Coach) as good");
        }

        [Test]
        public void ValidateGetPlan_HappyPath()
        {
            Assert.AreEqual(true, PlanValidator.ValidateGetPlan("Spaghetti1234"), "Marked a non-null planId call to ValidateGetPlan as bad");
        }
        [Test]
        public void ValidateGetPlan_NullPlanId()
        {
            Assert.AreEqual(false, PlanValidator.ValidateGetPlan(null), "Marked a null planId call to ValidateGetPlan as good");
        }

    }
}
