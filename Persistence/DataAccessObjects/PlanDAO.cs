using Model.DataTypes;
using Persistence.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DataAccessObjects
{
    public class PlanDAO
    {
        public string PlanId { get; set; }
        public Status Status { get; set; }

        //foreign key
        public string TraineeId { get; set; }
        public virtual ApplicationUser Trainee { get; set; }

        //foreign key
        public string CoachId { get; set; }
        public virtual ApplicationUser Coach { get; set; }

        public virtual ICollection<WorkoutDAO> Workouts { get; set; }
    }
}
