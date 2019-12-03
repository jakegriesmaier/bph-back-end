using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.UnitTests.Tests.Coach
{
    public class GetTraineesTest
    {
        private CoachModel _coachModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _coachModel = new CoachModel(dataAccessLocator);
        }

        [Test]
        public void Test_GetTrainees_HappyPath()
        {
            int numTrainees = 0;
            Assert.DoesNotThrowAsync(async () =>
            {
                var trainees = await _coachModel.GetTrainees();
                numTrainees = trainees.ToList().Count();
            }, "Threw an error when attempting to get the list of trainees when no error should have been thrown.");

            Assert.AreEqual(1, numTrainees, "expected the list of trainees to contain 1 trainee.");
        }

    }
}
