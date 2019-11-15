using System;
using Model.Entities;

namespace Model.Models.Validators
{
    public class ExerciseValidator
    {
        public static bool ValidateCreateExercise(Exercise exercise, string workoutId)
        {
            if (exercise.ExerciseId != null || workoutId == null)
            {
                return false;
            }
            return true;
        }

        public static bool ValidateGetExercise(string exerciseId)
        {
            if (exerciseId == null)
            {
                return false;
            }
            return true;
        }

        public static bool ValidateUpdateExercise(Exercise exercise)
        {
            if (exercise.ExerciseId == null)
            {
                return false;
            }
            return true;
        }

        public static bool ValidateDeleteExercise(string exerciseId)
        {
            if (exerciseId == null)
            {
                return false;
            }
            return true;
        }

        public static bool ValidateGetSets(string exerciseId)
        {
            if (exerciseId == null)
            {
                return false;
            }
            return true;
        }

    }
}
