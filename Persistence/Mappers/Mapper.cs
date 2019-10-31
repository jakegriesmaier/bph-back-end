using Model.Entities;
using Persistence.DataAccessObjects;
using Persistence.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistence.Mappers
{
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

        //public static ApplicationUser map(User entity)
        //{
        //    throw new NotImplementedException();
        //}

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

        //public static CommentDAO map(Comment entity)
        //{
        //    var createdBy = map(entity.CreatedBy);
        //    return new CommentDAO
        //    {
        //        CommentId = entity.CommentId,
        //        CreatedDate = entity.CreatedDate,
        //        CreatedBy = createdBy,
        //        Description = entity.Description
        //    };
        //}

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

        //public static PlanDAO map(Plan entity)
        //{
        //    return new PlanDAO
        //    {
        //        PlanId = entity.PlanId,
        //        Status = entity.Status,
        //        Coach = entity.Coach,
        //        CoachId = entity.Coach.UserId,
        //        Trainee = entity.Trainee,
        //        TraineeId - entity.Trainee.UserId,
        //        Workouts = entity.Workouts
        //    };
        //}

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

        //public static WorkoutDAO map(Workout entity)
        //{
        //    return new WorkoutDAO
        //    {
        //        Id = entity.WorkoutId,
        //        Title = entity.Title,
        //        Date = entity.Date,
        //        Status = entity.Status,
        //        Plan = plan,

        //    };
        //}

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

        //public static ExerciseDAO map(Exercise entity)
        //{
        //    throw new NotImplementedException();
        //}

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

        //public static SetDAO map(Set entity)
        //{
        //    throw new NotImplementedException();
        //}

    }
}
