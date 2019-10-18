using Model.DataTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }// make this a formatted string or add validator for email
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }
        public AccountType AccountType { get; set; }
    }
}
