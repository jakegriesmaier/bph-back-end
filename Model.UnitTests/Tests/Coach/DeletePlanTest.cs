using Model.Entities;
using Model.Exceptions;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.UnitTests.Tests.Coach
{
    public class DeletePlanTest
    {
        private CoachModel _coachModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _coachModel = new CoachModel(dataAccessLocator);
        }

        [Test]
        public void Test_DeletePlan_HappyPath()
        {
            var planId = "plan to delete";

            Assert.DoesNotThrowAsync(async () => {
                await _coachModel.DeletePlan(planId);
            }, "Threw an exception when trying to delete a plan.");
        }

        [Test]
        public void Test_DeletePlan_NoPlanId()
        {
            string planId = null;
            Assert.ThrowsAsync(Is.TypeOf<InsufficientInformationException>(), async () => {
                await _coachModel.DeletePlan(planId);
            }, "Expected an error to be thrown when deleting a plan without a plan id.");
        }

        [Test]
        public void Test_DeletePlan_PlanIdEmptyString()
        {
            string planId = "";
            Assert.ThrowsAsync(Is.TypeOf<InsufficientInformationException>(), async () => {
                await _coachModel.DeletePlan(planId);
            }, "Expected an error to be thrown when deleting a plan without an empty string plan id.");
        }
    }
}
