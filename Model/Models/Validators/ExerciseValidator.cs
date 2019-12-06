using System;
using Model.Entities;

namespace Model.Models.Validators
{
    public class ExerciseValidator
    {
        #region Validators
        public static bool ValidateCreateExercise(Exercise exercise, string workoutId)
        {
            if (ExerciseExists(exercise))
            {
                return false;
            }
            if (!WorkoutExists(workoutId))
            {
                return false;
            }
            return true;
        }

        public static bool ValidateGetExercise(string exerciseId)
        {
            if (!ExerciseExists(exerciseId))
            {
                return false;
            }
            return true;
        }

        public static bool ValidateUpdateExercise(Exercise exercise)
        {
            if (!ExerciseExists(exercise.ExerciseId))
            {
                return false;
            }
            return true;
        }

        public static bool ValidateDeleteExercise(string exerciseId)
        {
            if (!ExerciseExists(exerciseId))
            {
                return false;
            }
            return true;
        }

        public static bool ValidateGetSets(string exerciseId)
        {
            if (!ExerciseExists(exerciseId))
            {
                return false;
            }
            return true;
        }

        public static bool ValidateUpdateExerciseStatus(string exerciseId)
        {
            if (!ExerciseExists(exerciseId))
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Helper Functions
        private static bool ExerciseExists(Exercise exercise)
        {
            return (exercise.ExerciseId != null) && (exercise.ExerciseId != "");
        }
        private static bool ExerciseExists(string exerciseId)
        {
            return (exerciseId != null) && (exerciseId != "");
        }
        private static bool WorkoutExists(string workoutId)
        {
            return (workoutId != null) && (workoutId != "");
        }
        #endregion

    }
}
