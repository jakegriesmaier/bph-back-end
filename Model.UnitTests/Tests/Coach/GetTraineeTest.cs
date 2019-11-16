using Model.Exceptions;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Model.UnitTests.Tests.Coach
{
    public class GetTraineeTest
    {
        private CoachModel _coachModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _coachModel = new CoachModel(dataAccessLocator);
        }

        [Test]
        public void GetTrainee_HappyPath()
        {
            string traineeId = "Non Null Trainee Id :)";
            Assert.DoesNotThrowAsync(async () =>
            {
                await _coachModel.GetTrainee(traineeId);
            }, "Error thrown on good call to getTrainee");
        }

        [Test]
        public void GetTrainee_NoTraineeIdSpecified()
        {
            string traineeId = null;

            Assert.ThrowsAsync(Is.TypeOf<InsufficientInformationException>(), async () => {
                await _coachModel.GetTrainee(traineeId);
            }, "Expected an error to be thrown when trying to get a trainee without an id.");
        }
    }
}
