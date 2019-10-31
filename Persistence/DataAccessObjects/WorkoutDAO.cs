using Model.DataTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DataAccessObjects
{
    internal class WorkoutDAO
    {

        public WorkoutDAO()
        {
            Comments = new List<CommentDAO>();
            Exercises = new List<ExerciseDAO>();
        }

        public string WorkoutId { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public Status Status { get; set; }

        public ICollection<CommentDAO> Comments { get; set; }
        public ICollection<ExerciseDAO> Exercises { get; set; }

    }
}
