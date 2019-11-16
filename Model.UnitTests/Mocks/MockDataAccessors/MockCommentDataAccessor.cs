using Model.DataAccess.BaseAccessors;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Model.UnitTests.Mocks.MockDataAccessors
{
    public class MockCommentDataAccessor : CommentDataAccessorBase
    {
        protected override async Task<string> CreateCommentCore(Comment comment, string ownerId)
        {
            return await Task.FromResult(comment.CommentId);
        }

        protected override async Task<bool> DeleteCommentCore(string commentId)
        {
            return await Task.FromResult(true);
        }

        protected override async Task<Comment> GetCommentCore(string commentId)
        {
            var comment = MockComments.GetComment(commentId);
            return await Task.FromResult(comment);
        }

        protected override async Task<IEnumerable<Comment>> GetCommentsCore(string ownerId)
        {
            var comments = new List<Comment> { MockComments.Comment1() };
            return await Task.FromResult(comments);
        }

        protected override async Task<Comment> UpdateCommentCore(Comment comment)
        {
            return await Task.FromResult(comment);
        }
    }
}
