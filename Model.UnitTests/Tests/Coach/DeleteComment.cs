using System;
using Model.Exceptions;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Model.UnitTests.Tests.Coach
{
    public class DeleteCommentTest
    {
        private CoachModel _coachModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _coachModel = new CoachModel(dataAccessLocator);
        }

        [Test]
        public void DeleteComment_HappyPath()
        {
            string commentId = "weee";
            Assert.DoesNotThrowAsync(async () => {
                await _coachModel.DeleteComment(commentId);
            }, "attempted to delete a comment but failed.");
        }

        [Test]
        public void DeleteComment_NullCommentId()
        {
            string commentId = null;
            Assert.ThrowsAsync(Is.TypeOf<InsufficientInformationException>(), async () => {
                await _coachModel.DeleteComment(commentId);
            }, "Expected an error to be thrown when deleting a comment with a null comment Id");
        }
    }
}
