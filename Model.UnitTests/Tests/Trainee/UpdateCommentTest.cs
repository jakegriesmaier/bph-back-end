using System;
using Model.Exceptions;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Model.UnitTests.Tests.Trainee
{
    public class UpdateCommentTest
    {
        private TraineeModel _traineeModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _traineeModel = new TraineeModel(dataAccessLocator);
        }

        [Test]
        public void UpdateComment_HappyPath()
        {
            var comment = MockComments.Comment1();
            Assert.DoesNotThrowAsync(async () => {
                await _traineeModel.UpdateComment(comment);
            }, "attempted to update a comment but failed.");
        }

        [Test]
        public void UpdateComment_NullCommentId()
        {
            var comment = MockComments.creationNullCommentId();
            Assert.ThrowsAsync(Is.TypeOf<InsufficientInformationException>(), async () => {
                await _traineeModel.UpdateComment(comment);
            }, "Expected an error to be thrown when updating a comment with a null comment Id.");
        }

        [Test]
        public void UpdateComment_NullDescription()
        {
            var comment = MockComments.creationWithoutDescription();
            Assert.ThrowsAsync(Is.TypeOf<InsufficientInformationException>(), async () => {
                await _traineeModel.UpdateComment(comment);
            }, "Expected an error to be thrown when updating a comment without adding description.");
        }
    }
}
