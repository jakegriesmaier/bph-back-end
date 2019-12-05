using System;
using Model.Entities;

namespace Model.Models.Validators
{
    public class WorkoutValidator
    {
        #region Validators
        public static bool ValidateCreateWorkout(Workout workout, String planId)
        {
            if (WorkoutExists(workout))
            {
                return false;
            }
            if (!PlanExists(planId))
            {
                return false;
            }
            return true;
        }

        public static bool ValidateGetWorkout(string workoutId)
        {
            if (!WorkoutExists(workoutId))
            {
                return false;
            }
            return true;
        }

        public static bool ValidateUpdateWorkout(Workout workout)
        {
            if (!WorkoutExists(workout))
            {
                return false;
            }
            return true;
        }

        public static bool ValidateDeleteWorkout(string workoutId)
        {
            if (!WorkoutExists(workoutId))
            {
                return false;
            }
            return true;
        }

        public static bool ValidateGetExercises(string workoutId)
        {
            if (!WorkoutExists(workoutId))
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Helper Functions
        private static bool WorkoutExists(Workout workout)
        {
            return (workout.WorkoutId != null) && (workout.WorkoutId != "");
        }
        private static bool WorkoutExists(string workoutId)
        {
            return (workoutId != null) && (workoutId != "");
        }
        private static bool PlanExists(string planId)
        {
            return (planId != null) && (planId != "");
        }
        #endregion

    }
}
