using Model.Entities;
using Model.Exceptions;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Model.UnitTests.Tests.Trainee
{
    public class UpdateSetTest
    {
        private TraineeModel _traineeModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _traineeModel = new TraineeModel(dataAccessLocator);
        }

        [Test]
        public void UpdateSet_HappyPath()
        {
            var set = MockSets.Set1();

            Assert.DoesNotThrowAsync(async () =>
            {
                await _traineeModel.UpdateSet(set);
            }, "attempted to update a set but failed.");
        }

        [Test]
        public void UpdateSet_NoSetId()
        {
            var set = new Set();

            Assert.ThrowsAsync(Is.TypeOf<InsufficientInformationException>(), async () =>
            {
                await _traineeModel.UpdateSet(set);
            }, "Expected an error to be thrown when updating a set without a set id.");
        }

        [Test]
        public async Task UpdateSet_OnlyActualFields()
        {
            var set = MockSets.Set1();
            set.ActualReps = 999;
            set.TargetReps = 999;
            set.ActualRPE = 999;
            set.TargetRPE = 999;

            var updatedSet = await _traineeModel.UpdateSet(set);
            Assert.AreEqual(set.ActualReps, updatedSet.ActualReps, "Should be able to update Actual reps.");
            Assert.AreEqual(set.ActualRPE, updatedSet.ActualRPE, "Should be able to update Actual RPE.");
            Assert.AreNotEqual(set.TargetReps, updatedSet.TargetReps, "Should not be able to update Target reps.");
            Assert.AreNotEqual(set.TargetRPE, updatedSet.TargetRPE, "Should not be able to update Target RPE.");
        }
    }
}
