using Microsoft.AspNetCore.Identity;
using Model.DataTypes;
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
    }
}
