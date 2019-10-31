using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Persistence.DataAccessObjects
{
    public abstract class CommentOwner
    {
        public string Id { get; set; }
        public virtual ICollection<CommentDAO> Comments { get; set; }
    }
}
