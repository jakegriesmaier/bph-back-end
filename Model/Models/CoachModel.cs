﻿using Model.DataAccess;
using Model.Entities;
using Model.Exceptions;
using Model.Models.Validators;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public sealed class CoachModel : ModelBase
    {

        //Required Constructor in order to implement ModelBase
        public CoachModel(DataAccessLocatorBase dataAccessLocator) : base(dataAccessLocator) { }

        public async Task CreatePlan(Plan plan)
        {
            var coach = await UserDataAccessor.GetCurrentUser();
            plan.CoachId = coach.UserId;
            plan.Status = plan.TraineeId == null ? DataTypes.Status.Draft : DataTypes.Status.Created;
            if (!PlanValidator.ValidateCreatePlan(plan))
            {
                throw new InvalidParametersException(ExceptionMessages.INVALID_CREATE_PLAN_PARAMS,
                    ExceptionMessages.INVALID_CREATE_PLAN_PARAMS_USER_FRIENDLY);
            }
            await PlanDataAccessor.CreatePlan(plan);
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

        public async Task CreateWorkout(Workout workout, string planId)
        {
            workout.Status = DataTypes.Status.Created;
            if (!WorkoutValidator.ValidateCreateWorkout(workout, planId))
            {
                throw new InvalidParametersException(ExceptionMessages.INVALID_CREATE_WORKOUT_PARAMS,
                    ExceptionMessages.INVALID_CREATE_WORKOUT_PARAMS_USER_FRIENDLY);
            }
            await WorkoutDataAccessor.CreateWorkout(workout, planId);
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
            return await PlanDataAccessor.GetPlans(user,user.AccountType);
        }

        public async Task<Workout> UpdateWorkout(Workout workout)
        {
            //TODO VALIDATE
            return await WorkoutDataAccessor.UpdateWorkout(workout);
        }

        public async Task<IEnumerable<Workout>> GetWorkouts(string planId)
        {
            //TODO VALIDATE
            return await WorkoutDataAccessor.GetWorkouts(planId);
        }

        public async Task<string> CreateExercise(Exercise exercise, string workoutId)
        {
            //TODO VALIDATE
            return await ExerciseDataAccessor.CreateExercise(exercise, workoutId);

        }

        public async Task<Exercise> GetExercise(string exerciseId)
        {
            //TODO VALIDATE
            return await ExerciseDataAccessor.GetExercise(exerciseId);
        }

        public async Task<Exercise> UpdateExercise(Exercise exercise)
        {
            //TODO VALIDATE
            return await ExerciseDataAccessor.UpdateExercise(exercise);
        }

        public async Task<bool> DeleteExercise(string exerciseId)
        {
            //TODO VALIDATE
            return await ExerciseDataAccessor.DeleteExercise(exerciseId);
        }

        public async Task<IEnumerable<Exercise>> GetExercises(string workoutId)
        {
            //TODO VALIDATE
            return await ExerciseDataAccessor.GetExercises(workoutId);
        }

        public async Task<string> CreateSet(Set set, string exerciseId)
        {
            //TODO VALIDATE
            return await SetDataAccessor.CreateSet(set, exerciseId);
        }

        public async Task<Set> GetSet(string setId)
        {
            //TODO VALIDATE
            return await SetDataAccessor.GetSet(setId);
        }

        public async Task<Set> UpdateSet(Set set)
        {
            //TODO VALIDATE
            return await SetDataAccessor.UpdateSet(set);
        }

        public async Task<bool> DeleteSet(string setId)
        {
            //TODO VALIDATE
            return await SetDataAccessor.DeleteSet(setId);
        }

        public async Task<IEnumerable<Set>> GetSets(string exerciseId)
        {
            //TODO VALIDATE
            return await SetDataAccessor.GetSets(exerciseId);
        }

    }
}
