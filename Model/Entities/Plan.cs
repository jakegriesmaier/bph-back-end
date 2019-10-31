using Model.DataTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class Plan
    {

        public Plan()
        {
            Workouts = new List<Workout>();
        }

        public string PlanId { get; set; }
        public Status Status { get; set; }
        public User Trainee { get; set; }
        public User Coach { get; set; }
        
        public ICollection<Workout> Workouts { get; set; }
    }
}
