using System;
using Model.Exceptions;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Model.UnitTests.Tests.Coach
{
    public class GetSetTest
    {
        private CoachModel _coachModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _coachModel = new CoachModel(dataAccessLocator);
        }

        [Test]
        public void GetSet_HappyPath()
        {
            string setId = "weee";
            Assert.DoesNotThrowAsync(async () => {
                await _coachModel.GetSet(setId);
            }, "attempted to get an set but failed.");
        }

        [Test]
        public void GetSet_NullSetId()
        {
            string setId = null;
            Assert.ThrowsAsync(Is.TypeOf<InsufficientInformationException>(), async () => {
                await _coachModel.GetSet(setId);
            }, "Expected an error to be thrown when getting set from a null set id");
        }
    }
}
