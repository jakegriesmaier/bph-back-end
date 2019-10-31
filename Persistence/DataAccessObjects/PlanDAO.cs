using Model.DataTypes;
using Persistence.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DataAccessObjects
{
    internal class PlanDAO
    {

        public PlanDAO()
        {
            Workouts = new List<WorkoutDAO>();
        }

        public string PlanId { get; set; }
        public Status Status { get; set; }

        public ApplicationUser Trainee { get; set; }
        public ApplicationUser Coach { get; set; }

        public ICollection<WorkoutDAO> Workouts { get; set; }
    }
}
}
