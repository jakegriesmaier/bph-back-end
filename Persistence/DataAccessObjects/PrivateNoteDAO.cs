using Persistence.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DataAccessObjects
{
    public class PrivateNoteDAO : CommentOwner
    {
        //foreign key
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
