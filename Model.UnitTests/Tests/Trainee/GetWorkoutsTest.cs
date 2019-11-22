using Model.Exceptions;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Model.UnitTests.Tests.Trainee
{
    public class GetWorkoutsTest
    {
        private TraineeModel _traineeModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _traineeModel = new TraineeModel(dataAccessLocator);
        }

        [Test]
        public void GetWorkouts_HappyPath()
        {
            string planId = "weee";
            Assert.DoesNotThrowAsync(async () => {
                await _traineeModel.GetWorkouts(planId);
            }, "attempted to update a workout but failed.");
        }

        [Test]
        public void GetWorkouts_NullPlanId()
        {
            string planId = null;
            Assert.ThrowsAsync(Is.TypeOf<InsufficientInformationException>(), async () => {
                await _traineeModel.GetWorkouts(planId);
            }, "Expected an error to be thrown when getting workouts from a null plan id");
        }
    }
}
