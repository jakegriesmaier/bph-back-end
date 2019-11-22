using System;
using Model.Exceptions;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Model.UnitTests.Tests.Trainee
{
    public class GetSetTest
    {
        private TraineeModel _traineeModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _traineeModel = new TraineeModel(dataAccessLocator);
        }

        [Test]
        public void GetSet_HappyPath()
        {
            string setId = "weee";
            Assert.DoesNotThrowAsync(async () => {
                await _traineeModel.GetSet(setId);
            }, "attempted to get an set but failed.");
        }

        [Test]
        public void GetSet_NullSetId()
        {
            string setId = null;
            Assert.ThrowsAsync(Is.TypeOf<InsufficientInformationException>(), async () => {
                await _traineeModel.GetSet(setId);
            }, "Expected an error to be thrown when getting set from a null set id");
        }
    }
}
