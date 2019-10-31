using Model.DataTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class Workout
    {

        public Workout()
        {
            Comments = new List<Comment>();
            Exercises = new List<Exercise>();
        }

        public string WorkoutId { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public Status Status { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<Exercise> Exercises { get; set; }

    }
}
