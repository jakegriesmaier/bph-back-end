using System;
using Model.Exceptions;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Model.UnitTests.Tests.Trainee
{
    public class GetSetsTest
    {
        private TraineeModel _traineeModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _traineeModel = new TraineeModel(dataAccessLocator);
        }

        [Test]
        public void GetSets_HappyPath()
        {
            string exerciseId = "weee";
            Assert.DoesNotThrowAsync(async () => {
                await _traineeModel.GetSets(exerciseId);\
            }, "attempted to update a set but failed.");
        }

        [Test]
        public void GetSets_NullExerciseId()
        {
            string exerciseId = null;
            Assert.ThrowsAsync(Is.TypeOf<InsufficientInformationException>(), async () => {
                await _traineeModel.GetSets(exerciseId);
            }, "Expected an error to be thrown when getting sets from a null exercise id");
        }
    }
}
