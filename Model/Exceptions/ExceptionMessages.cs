﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Exceptions
{
    public static class ExceptionMessages
    {
        #region Data Access

        #region Data Access User Friendly
        public static readonly string UNAUTHORIZED_ACCESS_ATTEMPT_USER_FRIENDLY =
            "Oops! You aren't supposed to do that!";
        #endregion Data Access User Friendly

        #region Data Access Dev
        public static readonly string UNAUTHORIZED_ACCESS_ATTEMPT_DEV =
            "Wrong type of user for this action.";
        #endregion Data Access Dev

        #endregion Data Access

        #region User Model

        #region User Model Dev
        public static readonly string INVALID_CREATE_ACCOUNT_PARAMS =
            "Unable to create account. The email or password you entered do not match the required format.";

        public static readonly string INVALID_LOG_IN_PARAMS =
            "Unable to log in. The email or password you entered was incorrect.";

        public static readonly string INVALID_UPDATE_USER_PARAMS =
            "Unable to update the user. Users email and userId must be specified";

        public static readonly string INVALID_UPDATE_PASSWORD_PARAMS =
            "Unable to update pasword. The password entered did not match the required format.";
        #endregion User Model Dev

        #region User Model User Friendly
        public static readonly string INVALID_CREATE_ACCOUNT_PARAMS_USER_FRIENDLY =
            "Your email or password do not match the required formats.";

        public static readonly string INVALID_LOG_IN_PARAMS_USER_FRIENDLY =
            "Incorrect email or password.";

        public static readonly string INVALID_UPDATE_USER_PARAMS_USER_FRIENDLY =
            "Unable to update the user.";

        public static readonly string INVALID_UPDATE_PASSWORD_PARAMS_USER_FRIENDLY =
            "Password must match required format.";
        #endregion

        #endregion User Model

        #region Coach Model

        #region Coach Model Dev

        #region Plans

        public static readonly string INVALID_CREATE_PLAN_PARAMS =
            "Unable to create the plan. The planId has to be unset and coach must be specified.";

        public static readonly string INVALID_GET_PLAN_PARAMS =
            "Unable to get the plan. The planId must be specified.";

        public static readonly string INVALID_UPDATE_PLAN_PARAMS =
            "Unable to update the plan. The planId and coach must be specified.";

        #endregion Plans

        #region Workouts
        public static readonly string INVALID_CREATE_WORKOUT_PARAMS =
            "Unable to create the workout. A planId must be specified and the workoutId has to be unset.";

        public static readonly string INVALID_GET_WORKOUT_PARAMS =
            "Unable to get the workout. The workoutId must be specified.";

        public static readonly string INVALID_GET_WORKOUTS_PARAMS =
            "Unable to get the workouts for this plan. The planId must be specified.";

        public static readonly string INVALID_UPDATE_WORKOUT_PARAMS =
            "Unable to update the workout. The workoutId must be specified.";
        #endregion Workouts

        #region Exercises

        public static readonly string INVALID_CREATE_EXERCISE_PARAMS =
            "Unable to create the exercise. A workoutId must be specified and the exerciseId has to be unset.";

        public static readonly string INVALID_GET_EXERCISE_PARAMS =
                "Unable to get the exercise. The exercise ID must not be null.";

        public static readonly string INVALID_GET_EXERCISES_PARAMS =
                "Unable to get the exercises for this workout. The workout ID must not be null.";

        public static readonly string INVALID_UPDATE_EXERCISE_PARAMS =
                "Unable to update the exercise. The exercise ID must not be null.";

        public static readonly string INVALID_DELETE_EXERCISE_PARAMS =
                "Unable to delete the exercise. The exercise ID must not be null.";

        #endregion Exercises

        #region Sets

        public static readonly string INVALID_CREATE_SET_PARAMS =
                "Unable to create the set. An exerciseId must be specified and the setId has to be unset.";

        public static readonly string INVALID_GET_SET_PARAMS =
                "Unable to get the set. The set ID must not be null.";

        public static readonly string INVALID_GET_SETS_PARAMS =
                "Unable to get the sets for this exercise. The exercise ID must not be null.";

        public static readonly string INVALID_UPDATE_SET_PARAMS =
                "Unable to update the set. The set ID must not be null.";

        public static readonly string INVALID_DELETE_SET_PARAMS =
                "Unable to delete the set. The set ID must not be null.";

        #endregion Sets

        #endregion Coach Model Dev

        #region Coach Model User Friendy

        #region Plans

        public static readonly string INVALID_CREATE_PLAN_PARAMS_USER_FRIENDLY =
                "There was trouble creating your plan.";

        public static readonly string INVALID_GET_PLAN_PARAMS_USER_FRIENDLY =
            "There was trouble retrieving your plan.";

        public static readonly string INVALID_UPDATE_PLAN_PARAMS_USER_FRIENDLY =
            "There was trouble updating your plan.";

        #endregion Plans

        #region Workouts

        public static readonly string INVALID_CREATE_WORKOUT_PARAMS_USER_FRIENDLY =
            "There was trouble creating your workout.";

        public static readonly string INVALID_GET_WORKOUT_PARAMS_USER_FRIENDLY =
            "There was trouble retrieving your workout.";

        public static readonly string INVALID_GET_WORKOUTS_PARAMS_USER_FRIENDLY =
            "There was trouble getting the workouts for this plan.";

        public static readonly string INVALID_UPDATE_WORKOUT_PARAMS_USER_FRIENDLY =
            "There was trouble updating your workout.";

        #endregion Workouts

        #region Exercises
        public static readonly string INVALID_CREATE_EXERCISE_PARAMS_USER_FRIENDLY =
            "There was trouble creating your exercise.";

        public static readonly string INVALID_GET_EXERCISE_PARAMS_USER_FRIENDLY =
            "There was trouble getting your exercise.";

        public static readonly string INVALID_GET_EXERCISES_PARAMS_USER_FRIENDLY =
            "There was trouble getting your exercises for this plan.";

        public static readonly string INVALID_UPDATE_EXERCISE_PARAMS_USER_FRIENDLY =
            "There was trouble updating your exercise.";

        public static readonly string INVALID_DELETE_EXERCISE_PARAMS_USER_FRIENDLY =
            "There was trouble deleting your exercise.";

        #endregion Exercises

        #region Sets

        public static readonly string INVALID_CREATE_SET_PARAMS_USER_FRIENDLY =
            "There was trouble creating your set.";

        public static readonly string INVALID_GET_SET_PARAMS_USER_FRIENDLY =
            "There was trouble getting your set.";

        public static readonly string INVALID_GET_SETS_PARAMS_USER_FRIENDLY =
            "There was trouble getting your sets for this exercise.";

        public static readonly string INVALID_UPDATE_SET_PARAMS_USER_FRIENDLY =
            "There was trouble updating your set.";

        public static readonly string INVALID_DELETE_SET_PARAMS_USER_FRIENDLY =
            "There was trouble deleting your set.";

        #endregion Sets

        #endregion Coach Model User Friendly



        #endregion Coach Model

    }
}
