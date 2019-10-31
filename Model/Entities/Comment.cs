using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class Comment
    {
        public string CommentId { get; set; }
        public DateTime CreatedDate { get; set; }
        public User CreatedBy { get; set; }
        public string Description { get; set; }
    }
}
