using Persistence.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DataAccessObjects
{
    internal class CommentDAO
    {
        public string CommentId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }

        public ApplicationUser CreatedBy { get; set; }
    }
}
