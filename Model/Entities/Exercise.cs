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
            Sets = new List<Set>();
            Comments = new List<Comment>();
        }

        public string ExerciseId { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public Status Status { get; set; }

        public ICollection<Set> Sets { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
