using Microsoft.AspNetCore.Identity;
using Model.DataTypes;
using Persistence.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.EntityFramework
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }
        public AccountType AccountType { get; set; }

        public virtual ICollection<CommentDAO> Comments { get; set; }

        //used for database configuration only
        public virtual ICollection<PlanDAO> CoachPlans { get; set; }
        public virtual ICollection<PlanDAO> TraineePlans { get; set; }
    }
}
