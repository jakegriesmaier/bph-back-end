﻿using Model.Exceptions;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Model.UnitTests.Tests.Trainee
{
    public class GetPlanTest
    {
        private TraineeModel _traineeModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _traineeModel = new TraineeModel(dataAccessLocator);
        }

        [Test]
        public async Task Test_GetPlan_HappyPath()
        {
            var expected = MockPlans.Plan1();
            var actual = await _traineeModel.GetPlan(expected.PlanId);

            Assert.AreEqual(expected.PlanId, actual.PlanId, "plan id does not match expected id");
            Assert.AreEqual(expected.Status, actual.Status, "plan id does not match expected id");
            Assert.AreEqual(expected.TraineeId, actual.TraineeId, "plan id does not match expected id");
        }

        [Test]
        public void Test_GetPlan_NoPlanIdSpecified()
        {
            string planId = null;

            Assert.ThrowsAsync(Is.TypeOf<InsufficientInformationException>(), async () => {
                await _traineeModel.GetPlan(planId);
            }, "Expected an error to be thrown when trying to get a plan without an id.");
        }
    }
}