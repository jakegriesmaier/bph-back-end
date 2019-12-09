using Microsoft.EntityFrameworkCore;
using Model.DataAccess.BaseAccessors;
using Model.Entities;
using Model.Exceptions;
using Model.Interfaces;
using Persistence.DataExceptions;
using Persistence.EntityFramework;
using Persistence.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
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
            try
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

                await _context.SaveChangesAsync();

                return commentDao.CommentId;
            }
            catch (Exception e)
            {
                throw ExceptionHandler.HandleException(e, "There was a problem creating your comment");
            }
        }

        protected override async Task<bool> DeleteCommentCore(string commentId)
        {
            try
            {
                var comment = await _context.Comments.FindAsync(commentId);
                _context.Comments.Remove(comment);
                return true;

            }
            catch (Exception e)
            {
                throw ExceptionHandler.HandleException(e, "");
            }


        }

        protected override async Task<Comment> GetCommentCore(string commentId)
        {
            try
            {
                var comment = await _context.Comments.FindAsync(commentId);
                return Mapper.map(comment);
            }
            catch (Exception e)
            {
                throw ExceptionHandler.HandleException(e, "");
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
                var comments = _context.Comments.Where(c => c.OwnerId == ownerId).ToList();
                return comments.Select(c => Mapper.map(c)).ToList();

            }
            catch (Exception e)
            {
                throw ExceptionHandler.HandleException(e, "");
            }

        }

        protected override async Task<Comment> UpdateCommentCore(Comment comment)
        {

            try
            {
                var commentDao = Mapper.map(comment);
                _context.Entry(commentDao).State = EntityState.Modified;
                _context.Entry(commentDao).Property(c => c.OwnerId).IsModified = false;
                _context.Entry(commentDao).Property(c => c.CreatedById).IsModified = false;

                await _context.SaveChangesAsync();
                return Mapper.map(commentDao);
            }
            catch (Exception e)
            {
                throw ExceptionHandler.HandleException(e, "");
            }

        }
    }
}
