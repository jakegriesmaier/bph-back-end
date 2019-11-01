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
            var createdBy = map(dao.CreatedBy);
            return new Comment
            {
                CommentId = dao.CommentId,
                CreatedBy = createdBy,
                CreatedDate = dao.CreatedDate,
                Description = dao.Description
            };
        }

        //does not include owner, ownerId
        public static CommentDAO map(Comment entity)
        {
            if(entity.CreatedBy == null)
            {
                throw new HttpRequestException("CreatedBy must be specified");
            }
            var createdBy = map(entity.CreatedBy);
            return new CommentDAO
            {
                CommentId = entity.CommentId,
                CreatedDate = entity.CreatedDate,
                CreatedById = createdBy.Id,
                Description = entity.Description
            };
        }

        public static Plan map(PlanDAO dao)
        {
            var coach = map(dao.Coach);
            var trainee = map(dao.Trainee);
            var workouts = dao.Workouts.Select(w => map(w)).ToList();

            return new Plan
            {
                PlanId = dao.PlanId,
                Coach = coach,
                Status = dao.Status,
                Trainee = trainee,
                Workouts = workouts
            };
        }

        public static PlanDAO map(Plan entity)
        {
            if(entity.Coach == null)
            {
                throw new HttpRequestException("Coach must be specified");
            }
            var coach = map(entity.Coach);
            var dao = new PlanDAO
            {
                PlanId = entity.PlanId,
                Status = entity.Status,
                CoachId = coach.Id,
            };

            if (entity.Trainee != null)
            {
                dao.TraineeId = entity.Trainee.UserId;
            }
            dao.Workouts = entity.Workouts.Select(w => map(w)).ToList();
            return dao;
        }

        public static Workout map(WorkoutDAO dao)
        {
            var comments = dao.Comments.Select(c => map(c)).ToList();
            var exercises = dao.Exercises.Select(e => map(e)).ToList();
            return new Workout
            {
                WorkoutId = dao.Id,
                Date = dao.Date,
                Status = dao.Status,
                Title = dao.Title,
                Comments = comments,
                Exercises = exercises
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
            var sets = dao.Sets.Select(s => map(s)).ToList();
            var comments = dao.Comments.Select(c => map(c)).ToList();
            return new Exercise
            {
                ExerciseId = dao.Id,
                Name = dao.Name,
                Order = dao.Order,
                Status = dao.Status,
                Sets = sets,
                Comments = comments
            };
        }

        // does not specify Workout, WorkoutId
        public static ExerciseDAO map(Exercise entity)
        {
            var comments = entity.Comments.Select(c => map(c)).ToList();
            var sets = entity.Sets.Select(s => map(s)).ToList();
            return new ExerciseDAO
            {
                Id = entity.ExerciseId,
                Name = entity.Name,
                Order = entity.Order,
                Status = entity.Status,
                Comments = comments,
                Sets = sets
            };
        }

        public static Set map(SetDAO dao)
        {
            var comments = dao.Comments.Select(c => map(c)).ToList();
            return new Set
            {
                SetId = dao.Id,
                Order = dao.Order,
                ActualReps = dao.ActualReps,
                ActualRPE = dao.ActualRPE,
                TargetReps = dao.TargetReps,
                TargetRPE = dao.TargetRPE,
                Comments = comments
            };
        }

        // does not map Exercise, ExerciseId
        public static SetDAO map(Set entity)
        {
            var comments = entity.Comments.Select(c => map(c)).ToList();
            return new SetDAO
            {
                Id = entity.SetId,
                ActualReps = entity.ActualReps,
                ActualRPE = entity.ActualRPE,
                Order = entity.Order, 
                TargetReps = entity.TargetReps,
                TargetRPE = entity.TargetRPE,
                Comments = comments,
            };
        }

    }
}
