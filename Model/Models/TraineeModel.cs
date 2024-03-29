﻿using System.Threading.Tasks;
using Model.DataAccess;
using Model.Entities;
using Model.Exceptions;
using System.Collections.Generic;
using Model.Models.Validators;
using Model.DataTypes;
using System.Linq;

namespace Model.Models
{
    public class TraineeModel : ModelBase
    {
        public TraineeModel(DataAccessLocatorBase dataAccessLocator) : base(dataAccessLocator)
        {
        }

        public async Task<Plan> GetPlan(string planId)
        {
            if (!PlanValidator.ValidateGetPlan(planId))
            {
                throw new InsufficientInformationException(ExceptionMessages.INVALID_GET_PLAN_PARAMS,
                    ExceptionMessages.INVALID_GET_PLAN_PARAMS_USER_FRIENDLY);
            }
            return await PlanDataAccessor.GetPlan(planId);
        }

        public async Task<Plan> UpdatePlan(Plan plan)
        {
            if (!PlanValidator.ValidateUpdatePlan(plan))
            {
                throw new InsufficientInformationException(ExceptionMessages.INVALID_UPDATE_PLAN_PARAMS,
                    ExceptionMessages.INVALID_UPDATE_PLAN_PARAMS_USER_FRIENDLY);
            }
            return await PlanDataAccessor.UpdatePlan(plan);
        }

        public async Task<Workout> GetWorkout(string workoutId)
        {
            if (!WorkoutValidator.ValidateGetWorkout(workoutId))
            {
                throw new InsufficientInformationException(ExceptionMessages.INVALID_GET_WORKOUT_PARAMS,
                    ExceptionMessages.INVALID_GET_WORKOUT_PARAMS_USER_FRIENDLY);
            }
            return await WorkoutDataAccessor.GetWorkout(workoutId);
        }

        public async Task<IEnumerable<Workout>> GetWorkouts(string planId)
        {
            if (!PlanValidator.ValidateGetWorkouts(planId))
            {
                throw new InsufficientInformationException(ExceptionMessages.INVALID_GET_WORKOUTS_PARAMS,
                   ExceptionMessages.INVALID_GET_WORKOUTS_PARAMS_USER_FRIENDLY);
            }
            return await WorkoutDataAccessor.GetWorkouts(planId);
        }

        public async Task<Exercise> GetExercise(string exerciseId)
        {
            if (!ExerciseValidator.ValidateGetExercise(exerciseId))
            {
                throw new InsufficientInformationException(ExceptionMessages.INVALID_GET_EXERCISE_PARAMS,
                   ExceptionMessages.INVALID_GET_EXERCISE_PARAMS_USER_FRIENDLY);
            }
            return await ExerciseDataAccessor.GetExercise(exerciseId);
        }

        public async Task<IEnumerable<Exercise>> GetExercises(string workoutId)
        {
            if (!WorkoutValidator.ValidateGetExercises(workoutId))
            {
                throw new InsufficientInformationException(ExceptionMessages.INVALID_GET_EXERCISES_PARAMS,
                  ExceptionMessages.INVALID_GET_EXERCISES_PARAMS_USER_FRIENDLY);
            }
            return await ExerciseDataAccessor.GetExercises(workoutId);
        }

        public async Task<Set> GetSet(string setId)
        {
            if (!SetValidator.ValidateGetSet(setId))
            {
                throw new InsufficientInformationException(ExceptionMessages.INVALID_GET_SET_PARAMS,
                    ExceptionMessages.INVALID_GET_SET_PARAMS_USER_FRIENDLY);
            }
            return await SetDataAccessor.GetSet(setId);
        }

        public async Task<IEnumerable<Set>> GetSets(string exerciseId)
        {
            if (!ExerciseValidator.ValidateGetSets(exerciseId))
            {
                throw new InsufficientInformationException(ExceptionMessages.INVALID_GET_SETS_PARAMS,
                    ExceptionMessages.INVALID_GET_SETS_PARAMS_USER_FRIENDLY);
            }
            return await SetDataAccessor.GetSets(exerciseId);
        }

        public async Task<User> GetCoach(string userId)
        {
            if (!UserValidator.ValidateGetUser(userId))
            {
                throw new InsufficientInformationException(ExceptionMessages.INVALID_GET_USER_PARAMS, ExceptionMessages.INVALID_GET_USER_PARAMS_USER_FRIENDLY);
            }
            return await UserDataAccessor.GetUser(userId);
        }

        public async Task<string> CreateComment(Comment comment, string ownerId)
        {
            if (!CommentValidator.ValidateCreateComment(comment, ownerId))
            {
                throw new InsufficientInformationException(ExceptionMessages.INVALID_CREATE_COMMENT_PARAMS,
                    ExceptionMessages.INVALID_CREATE_COMMENT_PARAMS_USER_FRIENDLY);
            }
            return await CommentDataAccessor.CreateComment(comment, ownerId);
        }

        public async Task<Comment> GetComment(string commentId)
        {
            if (!CommentValidator.ValidateGetComment(commentId))
            {
                throw new InsufficientInformationException(ExceptionMessages.INVALID_GET_COMMENT_PARAMS,
                    ExceptionMessages.INVALID_GET_COMMENT_PARAMS_USER_FRIENDLY);
            }
            return await CommentDataAccessor.GetComment(commentId);
        }

        public async Task<Comment> UpdateComment(Comment comment)
        {
            if (!CommentValidator.ValidateUpdateComment(comment))
            {
                throw new InsufficientInformationException(ExceptionMessages.INVALID_UPDATE_COMMENT_PARAMS,
                    ExceptionMessages.INVALID_UPDATE_COMMENT_PARAMS_USER_FRIENDLY);
            }
            return await CommentDataAccessor.UpdateComment(comment);
        }

        public async Task<bool> DeleteComment(string commentId)
        {
            if (!CommentValidator.ValidateGetComment(commentId))
            {
                throw new InsufficientInformationException(ExceptionMessages.INVALID_DELETE_COMMENT_PARAMS,
                    ExceptionMessages.INVALID_DELETE_COMMENT_PARAMS_USER_FRIENDLY);
            }
            return await CommentDataAccessor.DeleteComment(commentId);
        }

        public async Task<IEnumerable<Comment>> GetComments(string ownerId)
        {
            if (!CommentValidator.ValidateGetComment(ownerId))
            {
                throw new InsufficientInformationException(ExceptionMessages.INVALID_GET_COMMENTS_PARAMS,
                    ExceptionMessages.INVALID_GET_COMMENTS_PARAMS_USER_FRIENDLY);
            }
            return await CommentDataAccessor.GetComments(ownerId);
        }

        public async Task<IEnumerable<Plan>> GetPlans()
        {
            var user = await UserDataAccessor.GetCurrentUser();
            var plans = await PlanDataAccessor.GetPlans(user, user.AccountType);
            return plans.Where(p => p.Status != Status.Draft);
        }

        public async Task<Set> UpdateSet(Set set)
        {
            if (!SetValidator.ValidateUpdateSet(set))
            {
                throw new InsufficientInformationException(ExceptionMessages.INVALID_UPDATE_SET_PARAMS,
                    ExceptionMessages.INVALID_UPDATE_SET_PARAMS_USER_FRIENDLY);
            }
            var outDatedSet = await SetDataAccessor.GetSet(set.SetId);
            outDatedSet.ActualReps = set.ActualReps;
            outDatedSet.ActualRPE = set.ActualRPE;
            outDatedSet.ActualWeight = set.ActualWeight;
            return await SetDataAccessor.UpdateSet(outDatedSet); 
        }

        public async Task<Exercise> UpdateExerciseStatus(string exerciseId, Status status)
        {
            if (!ExerciseValidator.ValidateUpdateExerciseStatus(exerciseId))
            {
                throw new InsufficientInformationException(ExceptionMessages.INVALID_UPDATE_EXERCISE_PARAMS,
                    ExceptionMessages.INVALID_UPDATE_EXERCISE_PARAMS_USER_FRIENDLY);
            }
            return await ExerciseDataAccessor.UpdateExerciseStatus(exerciseId, status);
        }

        public async Task<Workout> UpdateWorkoutStatus(string workoutId, Status status)
        {
            if (!WorkoutValidator.ValidateUpdateWorkoutStatus(workoutId))
            {
                throw new InsufficientInformationException(ExceptionMessages.INVALID_UPDATE_WORKOUT_PARAMS,
                    ExceptionMessages.INVALID_UPDATE_WORKOUT_PARAMS_USER_FRIENDLY);
            }
            return await WorkoutDataAccessor.UpdateWorkoutStatus(workoutId, status);
        }
    }
}
