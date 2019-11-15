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
        protected override Task<string> CreateCommentCore(Comment comment)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> DeleteCommentCore(string commentId)
        {
            throw new NotImplementedException();
        }

        protected override Task<Comment> GetCommentCore(string commentId)
        {
            throw new NotImplementedException();
        }

        protected override Task<IEnumerable<Comment>> GetCommentsCore(string ownerId)
        {
            throw new NotImplementedException();
        }

        protected override Task<Comment> UpdateCommentCore(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
