using Model.DataTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DataAccessObjects
{
    internal class ExerciseDAO
    {
        public ExerciseDAO()
        {
            Sets = new List<SetDAO>();
            Comments = new List<CommentDAO>();
        }

        public string ExerciseId { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public Status Status { get; set; }

        public ICollection<SetDAO> Sets { get; set; }
        public ICollection<CommentDAO> Comments { get; set; }
    }
}
