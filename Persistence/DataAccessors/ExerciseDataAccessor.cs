using Microsoft.EntityFrameworkCore;
using Model.DataAccess.BaseAccessors;
using Model.Entities;
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
    public class ExerciseDataAccessor : ExerciseDataAccessorBase
    {

        private BphContext _context;

        public ExerciseDataAccessor(BphContext context)
        {
            _context = context;
        }

        protected override async Task<string> CreateExerciseCore(Exercise exercise, string workoutId)
        {
            try
            {
                var workout = await _context.Workouts.FindAsync(workoutId);
                if(workout == null)
                {
                    throw new HttpRequestException("Workout Does Not Exist.");
                }
                var exerciseDao = Mapper.map(exercise);
                exerciseDao.WorkoutId = workoutId;

                _context.Exercises.Add(exerciseDao);
                await _context.SaveChangesAsync();
                return exerciseDao.Id;
            }
            catch
            {
                throw;
            }
        }

        protected override async Task<bool> DeleteExerciseCore(string exerciseId)
        {
            try
            {
                var exercise = await _context.Exercises.FindAsync(exerciseId);
                _context.Exercises.Remove(exercise);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        protected override async Task<Exercise> GetExerciseCore(string exerciseId)
        {
            try
            {
                var exercise = await _context.Exercises.FindAsync(exerciseId);
                exercise.Sets = _context.Sets.Where(s => s.ExerciseId == exercise.Id).ToList();
                exercise.Comments = _context.Comments.Where(c => c.OwnerId == exercise.Id).ToList();
                return Mapper.map(exercise);
            }
            catch
            {
                throw;
            }
        }

        protected override async Task<IEnumerable<Exercise>> GetExercisesCore(string workoutId)
        {
            try
            {
                var workout = await _context.Workouts.FindAsync(workoutId);
                if(workout == null)
                {
                    throw new HttpRequestException("Workout Does Not Exist.");
                }
                var exercises = _context.Exercises.Where(e => e.WorkoutId == workoutId).ToList();
                exercises.ForEach(e => e.Sets = _context.Sets.Where(s => s.ExerciseId == e.Id).ToList());
                exercises.ForEach(e => e.Comments = _context.Comments.Where(c => c.OwnerId == e.Id).ToList());
                return exercises.Select(e => Mapper.map(e)).ToList();
            }
            catch
            {
                throw;
            }
        }

        protected override async Task<Exercise> UpdateExerciseCore(Exercise exercise)
        {
            try
            {
                var exerciseDao = Mapper.map(exercise);
                _context.Entry(exerciseDao).State = EntityState.Modified;
                _context.Entry(exerciseDao).Property(e => e.WorkoutId).IsModified = false;
                await _context.SaveChangesAsync();
                exerciseDao.Sets = _context.Sets.Where(s => s.ExerciseId == exerciseDao.Id).ToList();
                exerciseDao.Comments = _context.Comments.Where(c => c.OwnerId == exerciseDao.Id).ToList();
                return Mapper.map(exerciseDao);
            }
            catch
            {
                throw;
            }
        }
    }
}
