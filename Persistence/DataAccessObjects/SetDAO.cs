using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DataAccessObjects
{
    public class SetDAO : CommentOwner
    {
        public int Order { get; set; }
        public double? TargetRPE { get; set; }
        public double? ActualRPE { get; set; }
        public int? TargetReps { get; set; }
        public int? ActualReps { get; set; }
        public int? TargetWeight { get; set; }
        public int? ActualWeight { get; set; }

        //foreign key
        public string ExerciseId { get; set; }
        public ExerciseDAO Exercise { get; set; }
    }
}
