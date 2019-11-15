using Microsoft.EntityFrameworkCore;
using Model.DataAccess.BaseAccessors;
using Model.Entities;
using Model.Interfaces;
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
            try
            {
                var owner = await _context.CommentOwners.FindAsync(ownerId);
                if(owner == null)
                {
                    throw new HttpRequestException("Comment Owner Does Not Exist.");
                }
                var commentDao = Mapper.map(comment);
                commentDao.OwnerId = ownerId;
                commentDao.CreatedById = _currentUserService.UserId;
                commentDao.CreatedDate = DateTime.Now;

                _context.Comments.Add(commentDao);
                await _context.SaveChangesAsync();
                return commentDao.CommentId;
            }
            catch
            {
                throw;
            }
        }

        protected override async Task<bool> DeleteCommentCore(string commentId)
        {
            try
            {
                var comment = await _context.Comments.FindAsync(commentId);
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        protected override async Task<Comment> GetCommentCore(string commentId)
        {
            try
            {
                var comment = await _context.Comments.FindAsync(commentId);
                return Mapper.map(comment);
            }
            catch
            {
                throw;
            }
        }

        protected override async Task<IEnumerable<Comment>> GetCommentsCore(string ownerId)
        {
            try
            {
                var owner = await _context.CommentOwners.FindAsync(ownerId);
                if (owner == null)
                {
                    throw new HttpRequestException("Comment Owner Does Not Exist.");
                }
                var comments = _context.Comments.Where(c => c.OwnerId == ownerId).ToList();
                return comments.Select(c => Mapper.map(c)).ToList();
            }
            catch
            {
                throw;
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
            catch
            {
                throw;
            }
        }
    }
}
