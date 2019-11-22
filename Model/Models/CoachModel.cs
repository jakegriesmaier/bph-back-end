using Model.DataAccess;
using Model.Entities;
using Model.Exceptions;
using Model.Models.Validators;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Model.Models
{
    public sealed class CoachModel : ModelBase
    {

        //Required Constructor in order to implement ModelBase
        public CoachModel(DataAccessLocatorBase dataAccessLocator) : base(dataAccessLocator) { }

        public async Task<string> CreatePlan(Plan plan)
        {
            var coach = await UserDataAccessor.GetCurrentUser();
            plan.CoachId = coach.UserId;
            plan.Status = plan.TraineeId == null ? DataTypes.Status.Draft : DataTypes.Status.Created;
            if (!PlanValidator.ValidateCreatePlan(plan))
            {
                throw new InvalidParametersException(ExceptionMessages.INVALID_CREATE_PLAN_PARAMS,
                    ExceptionMessages.INVALID_CREATE_PLAN_PARAMS_USER_FRIENDLY);
            }
            return await PlanDataAccessor.CreatePlan(plan);
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

        public async Task<string> CreateWorkout(Workout workout, string planId)
        {
            workout.Status = DataTypes.Status.Created;
            if (!WorkoutValidator.ValidateCreateWorkout(workout, planId))
            {
                throw new InvalidParametersException(ExceptionMessages.INVALID_CREATE_WORKOUT_PARAMS,
                    ExceptionMessages.INVALID_CREATE_WORKOUT_PARAMS_USER_FRIENDLY);
            }
            return await WorkoutDataAccessor.CreateWorkout(workout, planId);
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

        public async Task<IEnumerable<Plan>> GetPlans()
        {
            var user = await UserDataAccessor.GetCurrentUser();
            return await PlanDataAccessor.GetPlans(user, user.AccountType);
        }

        public async Task<Workout> UpdateWorkout(Workout workout)
        {
            if (!WorkoutValidator.ValidateUpdateWorkout(workout))
            {
                throw new InsufficientInformationException(ExceptionMessages.INVALID_UPDATE_WORKOUT_PARAMS,
                   ExceptionMessages.INVALID_UPDATE_WORKOUT_PARAMS_USER_FRIENDLY);
            }
            return await WorkoutDataAccessor.UpdateWorkout(workout);
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

        public async Task<string> CreateExercise(Exercise exercise, string workoutId)
        {
            if (!ExerciseValidator.ValidateCreateExercise(exercise, workoutId))
            {
                throw new InvalidParametersException(ExceptionMessages.INVALID_CREATE_EXERCISE_PARAMS,
                   ExceptionMessages.INVALID_CREATE_EXERCISE_PARAMS_USER_FRIENDLY);
            }
            return await ExerciseDataAccessor.CreateExercise(exercise, workoutId);

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

        public async Task<Exercise> UpdateExercise(Exercise exercise)
        {
            if (!ExerciseValidator.ValidateUpdateExercise(exercise))
            {
                throw new InsufficientInformationException(ExceptionMessages.INVALID_UPDATE_EXERCISE_PARAMS,
                  ExceptionMessages.INVALID_UPDATE_EXERCISE_PARAMS_USER_FRIENDLY);
            }
            return await ExerciseDataAccessor.UpdateExercise(exercise);
        }

        public async Task<bool> DeleteExercise(string exerciseId)
        {
            if (!ExerciseValidator.ValidateDeleteExercise(exerciseId))
            {
                throw new InsufficientInformationException(ExceptionMessages.INVALID_DELETE_EXERCISE_PARAMS,
                  ExceptionMessages.INVALID_DELETE_EXERCISE_PARAMS_USER_FRIENDLY);
            }
            return await ExerciseDataAccessor.DeleteExercise(exerciseId);
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

        public async Task<string> CreateSet(Set set, string exerciseId)
        {
            if (!SetValidator.ValidateCreateSet(set, exerciseId))
            {
                throw new InvalidParametersException(ExceptionMessages.INVALID_CREATE_SET_PARAMS,
                    ExceptionMessages.INVALID_CREATE_SET_PARAMS_USER_FRIENDLY);
            }
            return await SetDataAccessor.CreateSet(set, exerciseId);
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

        public async Task<Set> UpdateSet(Set set)
        {
            if (!SetValidator.ValidateUpdateSet(set))
            {
                throw new InsufficientInformationException(ExceptionMessages.INVALID_UPDATE_SET_PARAMS,
                    ExceptionMessages.INVALID_UPDATE_SET_PARAMS_USER_FRIENDLY);
            }
            return await SetDataAccessor.UpdateSet(set);
        }

        public async Task<bool> DeleteSet(string setId)
        {
            if (!SetValidator.ValidateDeleteSet(setId))
            {
                throw new InsufficientInformationException(ExceptionMessages.INVALID_DELETE_SET_PARAMS,
                    ExceptionMessages.INVALID_DELETE_SET_PARAMS_USER_FRIENDLY);
            }
            return await SetDataAccessor.DeleteSet(setId);
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

        public async Task<User> GetTrainee(string userId)
        {
            if (!UserValidator.ValidateGetUser(userId))
            {
                throw new InsufficientInformationException(ExceptionMessages.INVALID_GET_USER_PARAMS, ExceptionMessages.INVALID_GET_USER_PARAMS_USER_FRIENDLY);
            }
            return await UserDataAccessor.GetUser(userId);
        }
    }
}
