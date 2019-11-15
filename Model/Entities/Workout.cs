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
            CommentIds = new List<string>();
            ExerciseIds = new List<string>();
        }

        public string WorkoutId { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public Status Status { get; set; }

        public ICollection<string> CommentIds { get; set; }
        public ICollection<string> ExerciseIds { get; set; }

    }
}
