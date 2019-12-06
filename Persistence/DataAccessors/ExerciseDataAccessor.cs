﻿using Microsoft.EntityFrameworkCore;
using Model.DataAccess.BaseAccessors;
using Model.DataTypes;
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

        protected override async Task<Exercise> UpdateExerciseStatusCore(string exerciseId, Status status)
        {
            try
            {
                var exercise = await _context.Exercises.FindAsync(exerciseId);
                exercise.Status = status;
                _context.Entry(exercise).Property(ex => ex.Status).IsModified = true;
                await _context.SaveChangesAsync();
                await CheckWorkoutUpdateStatus(exercise.WorkoutId, status);
                return Mapper.map(exercise);
            }
            catch
            {
                throw;
            }
        }

        private async Task CheckWorkoutUpdateStatus(string workoutId, Status status)
        {
            try
            {
                var workout = await _context.Workouts.FindAsync(workoutId);
                if (workout == null)
                {
                    throw new HttpRequestException("Workout Does Not Exist.");
                }
                var exercises = _context.Exercises.Where(e => e.WorkoutId == workoutId).ToList();
                if(!exercises.Any(ex => ex.Status != status))
                {
                    // all of the exercises in the workout are at the same status
                    workout.Status = status;
                    _context.Entry(workout).Property(wo => wo.Status).IsModified = true;
                    await _context.SaveChangesAsync();
                    await CheckPlanUpdateStatus(workout.PlanId, status);
                    return; 
                }
            }
            catch
            {
                throw;
            }
        }

        private async Task CheckPlanUpdateStatus(string planId, Status status)
        {
            try
            {
                var plan = await _context.Plans.FindAsync(planId);
                if(plan == null)
                {
                    throw new HttpRequestException("Plan Does Not Exist.");
                }
                var workouts = _context.Workouts.Where(wo => wo.PlanId == planId).ToList();
                if(!workouts.Any(wo => wo.Status != status))
                {
                    // all of the workouts in the plan are the same status
                    plan.Status = status;
                    _context.Entry(plan).Property(p => p.Status).IsModified = true;
                    await _context.SaveChangesAsync();
                    return;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
