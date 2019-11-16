using Model.Exceptions;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Model.UnitTests.Tests.Trainee
{
    public class GetCoachTest
    {
        private TraineeModel _traineeModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _traineeModel = new TraineeModel(dataAccessLocator);
        }

        [Test]
        public void GetCoach_HappyPath()
        {
            string coachId = "Non Null Coach Id :)";
            Assert.DoesNotThrowAsync(async () =>
            {
                await _traineeModel.GetCoach(coachId);
            }, "Error thrown on good call to get coach");
        }

        [Test]
        public void GetCoach_NoCoachIdSpecified()
        {
            string coachId = null;

            Assert.ThrowsAsync(Is.TypeOf<InsufficientInformationException>(), async () => {
                await _traineeModel.GetCoach(coachId);
            }, "Expected an error to be thrown when trying to get a coach without an id.");
        }
    }
}
