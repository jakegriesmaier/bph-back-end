using Microsoft.EntityFrameworkCore;
using Model.DataAccess.BaseAccessors;
using Model.Entities;
using Model.Exceptions;
using Persistence.DataExceptions;
using Persistence.EntityFramework;
using Persistence.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.DataAccessors
{
    public class SetDataAccessor : SetDataAccessorBase
    {

        private BphContext _context;

        public SetDataAccessor(BphContext context)
        {
            _context = context;
        }

        protected override async Task<string> CreateSetCore(Set set, string exerciseId)
        {
            try
            {
                var exercise = await _context.Exercises.FindAsync(exerciseId);
                if (exercise == null)
                {
                    throw new ParentDoesNotExistException("", "");
                }
                var setDao = Mapper.map(set);
                setDao.ExerciseId = exerciseId;

                _context.Sets.Add(setDao);
                await _context.SaveChangesAsync();
                return setDao.Id;
            }
            catch (Exception e)
            {
                throw ExceptionHandler.HandleException(e, "");
            }
        }

        protected override async Task<bool> DeleteSetCore(string setId)
        {
            try
            {
                var set = await _context.Sets.FindAsync(setId);

                // get all of the comments associated with the set
                var comments = _context.Comments.Where(c => c.OwnerId == set.Id).ToList();

                // delete everything associated with the set
                _context.Comments.RemoveRange(comments);
                _context.Sets.Remove(set);

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                 throw ExceptionHandler.HandleException(e, "");
            }
        }

        protected override async Task<Set> GetSetCore(string setId)
        {
            try
            {
                var set = await _context.Sets.FindAsync(setId);
                set.Comments = _context.Comments.Where(c => c.OwnerId == set.Id).ToList();
                // set the set as Detached so that it is not tracked by the db context
                _context.Entry(set).State = EntityState.Detached;
                return Mapper.map(set);
            }
            catch (Exception e)
            {
                 throw ExceptionHandler.HandleException(e, "");
            }
        }

        protected override async Task<IEnumerable<Set>> GetSetsCore(string exerciseId)
        {
            try
            {
                var exercise = await _context.Exercises.FindAsync(exerciseId);
                if (exercise == null)
                {
                    throw new ParentDoesNotExistException("","");
                }
                var sets = _context.Sets.Where(s => s.ExerciseId == exerciseId).ToList();
                sets.ForEach(s => s.Comments = _context.Comments.Where(c => c.OwnerId == s.Id).ToList());
                return sets.Select(s => Mapper.map(s)).ToList();
            }
            catch (Exception e)
            {
                 throw ExceptionHandler.HandleException(e, "");
            }
        }

        protected override async Task<Set> UpdateSetCore(Set set)
        {
            try
            {
                var setDao = Mapper.map(set);
                _context.Entry(setDao).State = EntityState.Modified;
                _context.Entry(setDao).Property(s => s.ExerciseId).IsModified = false;
                await _context.SaveChangesAsync();
                setDao.Comments = _context.Comments.Where(c => c.OwnerId == setDao.Id).ToList();
                return Mapper.map(setDao);
            }
            catch (Exception e)
            {
                 throw ExceptionHandler.HandleException(e, "");
            }
        }
    }
}
