using Model.DataAccess.BaseAccessors;
using Model.Entities;
using Model.Interfaces;
using Persistence.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataAccessors
{
    public class CommentDataAccessor : CommentDataAccessorBase
    {

        private BphContext _context;
        private ICurrentUserService _currentUserService;

        public CommentDataAccessor(BphContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        protected override Task<string> CreateCommentCore(Comment comment, string ownerId)
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
