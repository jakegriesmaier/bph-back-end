using System;
using Model.Entities;

namespace Model.Models.Validators
{
    public class WorkoutValidator
    {
        public static bool ValidateCreateWorkout(Workout workout, String planId)
        {
            if (workout.WorkoutId != null || planId == null)
            {
                return false;
            }
            return true;
        }


    }
}
