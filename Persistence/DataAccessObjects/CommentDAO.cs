using Persistence.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DataAccessObjects
{
    public class CommentDAO
    {
        public string CommentId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }

        // foreign key
        public string CreatedById { get; set; }
        public ApplicationUser CreatedBy { get; set; }

        // foreign key
        public CommentOwner Owner { get; set; }
        public string OwnerId { get; set; }
    }
}
