using Microsoft.EntityFrameworkCore;
using Model.DataAccess.BaseAccessors;
using Model.Entities;
using Model.Interfaces;
using Persistence.DataExceptions;
using Persistence.EntityFramework;
using Persistence.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        protected override async Task<string> CreateCommentCore(Comment comment, string ownerId)
        {

            var owner = await _context.CommentOwners.FindAsync(ownerId);
            if (owner == null)
            {
                throw new ParentDoesNotExistException("Comment Owner Does Not Exist.", "tempUser");
            }
            var commentDao = Mapper.map(comment);
            commentDao.OwnerId = ownerId;
            commentDao.CreatedById = _currentUserService.UserId;
            commentDao.CreatedDate = DateTime.Now;

            _context.Comments.Add(commentDao);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new DatabaseException("tempDev", "tempUser", e);
            }
            return commentDao.CommentId;

        }

        protected override async Task<bool> DeleteCommentCore(string commentId)
        {

            var comment = await _context.Comments.FindAsync(commentId);
            _context.Comments.Remove(comment);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new DatabaseException("tempDev", "tempUser", e);
            }
            return true;

        }

        protected override async Task<Comment> GetCommentCore(string commentId)
        {
            try
            {
                var comment = await _context.Comments.FindAsync(commentId);
                return Mapper.map(comment);
            }
            catch (InvalidOperationException e)
            {
                throw new DatabaseException("tempDev", "tempUser", e);
            }


        }

        protected override async Task<IEnumerable<Comment>> GetCommentsCore(string ownerId)
        {

            try
            {
                var owner = await _context.CommentOwners.FindAsync(ownerId);
                if (owner == null)
                {
                    throw new ParentDoesNotExistException("Comment Owner Does Not Exist.", "tempUser");
                }

            }
            catch (InvalidOperationException e)
            {
                throw new DatabaseException("tempDev", "tempUser", e);
            }

            var comments = _context.Comments.Where(c => c.OwnerId == ownerId).ToList();
            return comments.Select(c => Mapper.map(c)).ToList();

        }

        protected override async Task<Comment> UpdateCommentCore(Comment comment)
        {

            var commentDao = Mapper.map(comment);
            _context.Entry(commentDao).State = EntityState.Modified;
            _context.Entry(commentDao).Property(c => c.OwnerId).IsModified = false;
            _context.Entry(commentDao).Property(c => c.CreatedById).IsModified = false;
            try
            {
                await _context.SaveChangesAsync();
                return Mapper.map(commentDao);
            }
            catch (DbUpdateException e)
            {
                throw new DatabaseException("tempDev", "tempUser", e);
            }
        }
    }
}
