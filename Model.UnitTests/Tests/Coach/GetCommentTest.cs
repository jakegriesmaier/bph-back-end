using System;
using Model.Exceptions;
using Model.Models;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Model.UnitTests.Tests.Coach
{
    public class GetCommentTest
    {
        private CoachModel _coachModel;

        [SetUp]
        public void Setup()
        {
            var dataAccessLocator = new MockDataAccessLocator();
            _coachModel = new CoachModel(dataAccessLocator);
        }

        [Test]
        public void GetComment_HappyPath()
        {
            string commentId = "weee";
            Assert.DoesNotThrowAsync(async () => {
                await _coachModel.GetComment(commentId);
            }, "attempted to get a comment but failed.");
        }

        [Test]
        public void GetComment_NullCommentId()
        {
            string commentId = null;
            Assert.ThrowsAsync(Is.TypeOf<InsufficientInformationException>(), async () => {
                await _coachModel.GetComment(commentId);
            }, "Expected an error to be thrown when gettting a comment with a null comment Id.");
        }
    }
}
