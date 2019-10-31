using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DataAccessObjects
{
    internal class SetDAO
    {
        public string SetId { get; set; }
        public int Order { get; set; }
        public double? TargetRPE { get; set; }
        public double? ActualRPE { get; set; }
        public int? TargetReps { get; set; }
        public int? ActualReps { get; set; }
    }
}
