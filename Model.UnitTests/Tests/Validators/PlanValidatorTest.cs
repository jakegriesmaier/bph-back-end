using System;
using Model.Entities;
using Model.Models.Validators;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Model.UnitTests.Tests.Validators
{
    public class PlanValidatorTest
    {
        Plan mockPlan = MockPlans.creationGood();
        Plan withoutCoach = MockPlans.creationWithoutCoach();
        Plan withId = MockPlans.creationWithId();

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
        public void ValidateCreatePlan_NonNullPlanId()
        {
            Assert.AreEqual(false, PlanValidator.ValidateCreatePlan(withId), "Marked a bad Plan (Null Id) as good");
        }
        [Test]
        public void ValidateCreatePlan_NullCoach()
        {
            Assert.AreEqual(false, PlanValidator.ValidateCreatePlan(withoutCoach), "Marked a bad Plan (Null Coach) as good");
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
