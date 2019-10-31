using Model.DataTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DataAccessObjects
{
    public class WorkoutDAO : CommentOwner
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public Status Status { get; set; }

        public virtual ICollection<ExerciseDAO> Exercises { get; set; }

        // foreign key
        public PlanDAO Plan { get; set; }
        public string PlanId { get; set; }
    }
}
