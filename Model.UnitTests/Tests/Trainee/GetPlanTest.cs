﻿using Model.Exceptions;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;

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
        public void Test_GetPlan_HappyPath()
        {
            string planId = "Non Null Plan Id :)";

            Assert.DoesNotThrowAsync(async () => {
                await _traineeModel.GetPlan(planId);
            }, "Marked a good GetPlan call as bad.");
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
