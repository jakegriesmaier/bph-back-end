using System;
using Model.Exceptions;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Model.UnitTests.Tests.Coach
{
    public class CreateCommentTest
    {
        private CoachModel _coachModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _coachModel = new CoachModel(dataAccessLocator);
        }

        [Test]
        public void CreateComment_HappyPath()
        {
            var comment = MockComments.creationNullCommentId();
            string ownerId = "weee";
            Assert.DoesNotThrowAsync(async () => {
                await _coachModel.CreateComment(comment, ownerId);
            }, "attempted to create a comment but failed.");
        }

        [Test]
        public void CreateComment_NullCommentId()
        {
            var comment = MockComments.creationNullCommentId();
            string ownerId = null;
            Assert.ThrowsAsync(Is.TypeOf<InsufficientInformationException>(), async () => {
                await _coachModel.CreateComment(comment, ownerId);
            }, "Expected an error to be thrown when creating comment from a null owner Id");
        }

        [Test]
        public void CreateComment_ExistingCommentId()
        {
            var comment = MockComments.Comment1();
            string ownerId = "weee";
            Assert.ThrowsAsync(Is.TypeOf<InsufficientInformationException>(), async () => {
                await _coachModel.CreateComment(comment, ownerId);
            }, "Expected an error to be thrown when creating comment with non null comment Id.");
        }

        [Test]
        public void CreateComment_NullDescription()
        {
            var comment = MockComments.creationWithoutDescription();
            string ownerId = "weee";
            Assert.ThrowsAsync(Is.TypeOf<InsufficientInformationException>(), async () => {
                await _coachModel.CreateComment(comment, ownerId);
            }, "Expected an error to be thrown when creating comment with null description.");
        }
    }
}
