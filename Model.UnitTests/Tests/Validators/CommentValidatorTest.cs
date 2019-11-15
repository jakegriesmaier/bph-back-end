using System;
using Model.Entities;
using Model.Models.Validators;
using Model.UnitTests.Mocks;
using NUnit.Framework;

namespace Model.UnitTests.Tests.Validators
{
    public class CommentValidatorTest
    {
        string withoutOwnerId = null;
        string withOwnerId = MockUsers.Coach().UserId;
        Comment updateHappyComment = MockComments.Comment1();
        Comment withoutId = MockComments.creationNullCommentId();
        Comment withoutDescription = MockComments.creationWithoutDescription();       
   
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ValidateCreateComment_HappyPath()
        {
            Assert.AreEqual(true, CommentValidator.ValidateCreateComment(withoutId, withOwnerId), "Marked a good comment as bad");
        }
        [Test]
        public void ValidateCreateComment_ExistingOwnerId()
        {
            Assert.AreEqual(false, CommentValidator.ValidateCreateComment(withoutId, withoutOwnerId), "Marked a bad Comment (existing ownerId) as good");
        }
        [Test]
        public void ValidateCreateComment_ExistingCommentId()
        {
            Assert.AreEqual(false, CommentValidator.ValidateCreateComment(updateHappyComment, withoutOwnerId), "Marked a bad Comment (existing commentId) as good");
        }
        [Test]
        public void ValidateCreateComment_NullDescription()
        {
            Assert.AreEqual(false, CommentValidator.ValidateCreateComment(withoutDescription, withoutOwnerId), "Marked a bad Comment (no description) as good");
        }
        [Test]
        public void ValidateGetComment_HappyPath()
        {
            Assert.AreEqual(true, CommentValidator.ValidateGetComment(withOwnerId), "Marked a good Comment (has CommentId) as good");
        }
        [Test]
        public void ValidateGetComment_NullCommentId()
        {
            Assert.AreEqual(false, CommentValidator.ValidateGetComment(withoutOwnerId), "Marked a bad Comment (no CommentId) as good");
        }
        [Test]
        public void ValidateUpdateComment_HappyPath()
        {
            Assert.AreEqual(true, CommentValidator.ValidateUpdateComment(updateHappyComment), "Marked a good Comment (has CommentId, Description) as bad");
        }
        [Test]
        public void ValidatUpdateComment_NullCommentId()
        {
            Assert.AreEqual(false, CommentValidator.ValidateUpdateComment(withoutId), "Marked a bad Comment (no CommentId) as good");
        }
        [Test]
        public void ValidateUpdateComment_NullDescription()
        {
            Assert.AreEqual(false, CommentValidator.ValidateUpdateComment(withoutDescription), "Marked a bad Comment (no description) as good");
        }
        [Test]
        public void ValidateDeleteComment_HappyPath()
        {
            Assert.AreEqual(true, CommentValidator.ValidateDeleteComment(withOwnerId), "Marked a good Comment (has CommentId) as bad");
        }
        [Test]
        public void ValidateDeleteComment_NullCommentId()
        {
            Assert.AreEqual(false, CommentValidator.ValidateDeleteComment(withoutOwnerId), "Marked a bad Comment (no CommentId) as good");
        }
        [Test]
        public void ValidateGetComments_HappyPath()
        {
            Assert.AreEqual(true, CommentValidator.ValidateGetComments(withOwnerId), "Marked a good Comment (has ownerId) as bad");
        }
        [Test]
        public void ValidateGetComments_NullCommentId()
        {
            Assert.AreEqual(false, CommentValidator.ValidateGetComments(withoutOwnerId), "Marked a bad Comment (no ownerId) as good");
        }

    }
}
