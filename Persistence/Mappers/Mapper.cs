using Model.Entities;
using Persistence.DataAccessObjects;
using Persistence.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Persistence.Mappers
{
    /// <summary>
    /// Maps DAO -> Entity and Entity -> DAO
    /// NOTE: When mapping Entity -> DAO only specify Ids, not the actual object or
    /// you will get duplicate key error in the database
    /// </summary>
    internal class Mapper
    {

        public static User map(ApplicationUser dao)
        {
            return new User
            {
                UserId = dao.Id,
                Email = dao.Email,
                FirstName = dao.FirstName,
                LastName = dao.LastName,
                Height = dao.Height,
                Weight = dao.Weight,
                AccountType = dao.AccountType
            };
        }

        public static ApplicationUser map(User entity)
        {
            return new ApplicationUser
            {
                Id = entity.UserId,
                UserName = entity.Email,
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                AccountType = entity.AccountType,
                Height = entity.Height,
                Weight = entity.Weight,
            };
        }

        public static Comment map(CommentDAO dao)
        {
            return new Comment
            {
                CommentId = dao.CommentId,
                CreatedById = dao.CreatedById,
                CreatedDate = dao.CreatedDate,
                Description = dao.Description
            };
        }

        //does not include owner, ownerId
        public static CommentDAO map(Comment entity)
        {
            return new CommentDAO
            {
                CommentId = entity.CommentId,
                CreatedDate = entity.CreatedDate,
                CreatedById = entity.CreatedById,
                Description = entity.Description
            };
        }

        public static Plan map(PlanDAO dao)
        {
            var workoutIds = (dao.Workouts != null) ? dao.Workouts.Select(w => w.Id).ToList() : new List<string>();
            return new Plan
            {
                PlanId = dao.PlanId,
                CoachId = dao.CoachId,
                Status = dao.Status,
                TraineeId = dao.TraineeId,
                WorkoutIds= workoutIds
            };
        }

        public static PlanDAO map(Plan entity)
        {
            return new PlanDAO
            {
                PlanId = entity.PlanId,
                Status = entity.Status,
                CoachId = entity.CoachId,
                TraineeId = entity.TraineeId
            };
        }

        public static Workout map(WorkoutDAO dao)
        {
            var commentIds = dao.Comments.Select(c => c.CommentId).ToList();
            var exerciseIds = dao.Exercises.Select(e => e.Id).ToList(); 
            return new Workout
            {
                WorkoutId = dao.Id,
                Date = dao.Date,
                Status = dao.Status,
                Title = dao.Title,
                CommentIds = commentIds,
                ExerciseIds = exerciseIds
            };
        }

        // does not inlcude Plan, PlanId
        public static WorkoutDAO map(Workout entity)
        {
            return new WorkoutDAO
            {
                Id = entity.WorkoutId,
                Title = entity.Title,
                Date = entity.Date,
                Status = entity.Status
            };
        }

        public static Exercise map(ExerciseDAO dao)
        {
            var setIds = dao.Sets.Select(s => s.Id).ToList();
            var commentIds = dao.Comments.Select(c => c.CommentId).ToList();
            return new Exercise
            {
                ExerciseId = dao.Id,
                Name = dao.Name,
                Order = dao.Order,
                Status = dao.Status,
                SetIds = setIds,
                CommentIds = commentIds
            };
        }

        // does not specify Workout, WorkoutId
        public static ExerciseDAO map(Exercise entity)
        {
            return new ExerciseDAO
            {
                Id = entity.ExerciseId,
                Name = entity.Name,
                Order = entity.Order,
                Status = entity.Status
            };
        }

        public static Set map(SetDAO dao)
        {
            var commentIds = dao.Comments.Select(c => c.CommentId).ToList();
            return new Set
            {
                SetId = dao.Id,
                Order = dao.Order,
                ActualReps = dao.ActualReps,
                ActualRPE = dao.ActualRPE,
                TargetReps = dao.TargetReps,
                TargetRPE = dao.TargetRPE,
                CommentIds = commentIds
            };
        }

        // does not map Exercise, ExerciseId
        public static SetDAO map(Set entity)
        {
            return new SetDAO
            {
                Id = entity.SetId,
                ActualReps = entity.ActualReps,
                ActualRPE = entity.ActualRPE,
                Order = entity.Order, 
                TargetReps = entity.TargetReps,
                TargetRPE = entity.TargetRPE
            };
        }

    }
}
