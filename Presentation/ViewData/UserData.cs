using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.ViewData
{
    public class UserData
    {
        public string Username { get; set; }
        public string Email { get; set; }// make this a formatted string or add validator for email
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }
        // public AccountType AccountType { get; set; }
    }
}
