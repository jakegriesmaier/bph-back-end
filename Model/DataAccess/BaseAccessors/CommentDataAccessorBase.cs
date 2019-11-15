using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataAccess.BaseAccessors
{
    public abstract class CommentDataAccessorBase
    {

        public async Task<string> CreateComment(Comment comment)
        {
            return await CreateCommentCore(comment);
        }

        public async Task<Comment> GetComment(string commentId)
        {
            return await GetCommentCore(commentId);
        }

        public async Task<Comment> UpdateComment(Comment comment)
        {
            return await UpdateCommentCore(comment);
        }

        public async Task<bool> DeleteComment(string commentId)
        {
            return await DeleteCommentCore(commentId);
        }

        public async Task<IEnumerable<Comment>> GetComments(string ownerId)
        {
            return await GetCommentsCore(ownerId);
        }

        #region necessary implementations
        protected abstract Task<string> CreateCommentCore(Comment comment);
        protected abstract Task<Comment> GetCommentCore(string commentId);
        protected abstract Task<Comment> UpdateCommentCore(Comment comment);
        protected abstract Task<bool> DeleteCommentCore(string commentId);
        protected abstract Task<IEnumerable<Comment>> GetCommentsCore(string ownerId);
        #endregion
    }
}
