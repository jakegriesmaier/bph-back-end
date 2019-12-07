using Model.DataTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DataAccessObjects
{
    public class ExerciseDAO : CommentOwner
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public Status Status { get; set; }

        // foreign key
        public WorkoutDAO Workout { get; set; }
        public string WorkoutId { get; set; }

        public virtual ICollection<SetDAO> Sets { get; set; }
    }
}
