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
            WorkoutIds = new List<string>();
        }

        public string PlanId { get; set; }
        public Status Status { get; set; }
        public string TraineeId { get; set; }
        public string CoachId { get; set; }
        
        public ICollection<string> WorkoutIds { get; set; }
    }
}
