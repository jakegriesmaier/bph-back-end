using System;
using System.Collections.Generic;
using Model.Entities;

namespace Model.UnitTests.Mocks
{
    public class MockExercises
    {
        public static Exercise GetExercise(string id)
        {
            if (id == Exercise1().ExerciseId)
            {
                return Exercise1();
            }
            return new Exercise();
        }

        public static Exercise Exercise1()
        {
            return new Exercise
            {
                ExerciseId = "pizza",
                Name = "Sumo Deadlift",
                Order = 0,
                Status = DataTypes.Status.Created,
            };
        }
    }
}
