using Model.Entities;
using Model.Exceptions;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Model.UnitTests.Tests.Coach
{
    public class CreatePlanTest
    {
        private CoachModel _coachModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _coachModel = new CoachModel(dataAccessLocator);
        }

        [Test]
        public void Test_CreatePlan_HappyPath()
        {
            var plan = new Plan();

            Assert.DoesNotThrowAsync(async () => {
                await _coachModel.CreatePlan(plan);
            }, "Threw an exception when trying to create a plan.");
        }

        [Test]
        public void Test_CreatePlan_PlanAlreadyExists()
        {
            var plan = MockPlans.Plan1();

            Assert.ThrowsAsync(Is.TypeOf<InvalidParametersException>(), async () => {
                await _coachModel.CreatePlan(plan);
            }, "Expected an error to be thrown when adding a plan that already exists.");
        }
    }
}
