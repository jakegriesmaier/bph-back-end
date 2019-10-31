using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class Set
    {

        public Set()
        {
            Comments = new List<Comment>();
        }

        public string SetId { get; set; }
        public int Order { get; set; }
        public double? TargetRPE { get; set; }
        public double? ActualRPE { get; set; }
        public int? TargetReps { get; set; }
        public int? ActualReps { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
