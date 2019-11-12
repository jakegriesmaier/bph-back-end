using Model.Entities;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Model.UnitTests.Tests.Coach
{
    public class UpdatePlanTest
    {
        private CoachModel _coachModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _coachModel = new CoachModel(dataAccessLocator);
        }

        [Test]
        public void Test_UpdatePlan_HappyPath()
        {
            var plan = MockPlans.Plan1();
            //Come back and fix both
            Assert.DoesNotThrowAsync(async () => {
                 await _coachModel.UpdatePlan(plan);
             }, "Threw an exception when trying to Update a plan.");
           
        }

        [Test]
        public void Test_UpdatePlan_PlanDoesNotExist()
        {
            var plan = new Plan();

            Assert.ThrowsAsync(Is.TypeOf<HttpRequestException>(), async () => {
                await _coachModel.UpdatePlan(plan);
            }, "Expected an error to be thrown when adding a plan that already exists.");
        }
    }
}
