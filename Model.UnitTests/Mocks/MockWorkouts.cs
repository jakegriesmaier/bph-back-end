using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.UnitTests.Mocks
{
    public static class MockWorkouts
    {

        public static Workout GetWorkout(string id)
        {
            if (id == Workout1().WorkoutId)
            {
                return Workout1(); 
            }
            return new Workout();
        }

        public static Workout Workout1()
        {
            return new Workout
            {
                WorkoutId = "workout-1",
                Date = new DateTime(2222, 11, 11),
                Status = DataTypes.Status.Created,
                Title = "Test Workout",
                CommentIds = new List<string>(),
                ExerciseIds = new List<string>()
            };
        }
    }
}
