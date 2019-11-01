using Model.DataTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class User
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }
        public AccountType AccountType { get; set; }
    }
}
