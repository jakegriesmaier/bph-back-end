using Model.DataTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class Exercise
    {

        public Exercise()
        {
            SetIds = new List<string>();
            CommentIds = new List<string>();
        }

        public string ExerciseId { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public Status Status { get; set; }

        public ICollection<string> SetIds { get; set; }
        public ICollection<string> CommentIds { get; set; }
    }
}
