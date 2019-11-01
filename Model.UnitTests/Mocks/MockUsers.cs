using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.UnitTests.Mocks
{
    public static class MockUsers
    {
        public static User Coach()
        {
            return new User
            {
                UserId = "coach-1",
                FirstName = "Sponge",
                LastName = "Bob",
                Email = "spongebob@gmail.com",
                AccountType = DataTypes.AccountType.Coach,
                Height = 30,
                Weight = 50
            };
        }

        public static User Trainee()
        {
            return new User
            {
                UserId = "trainee-1",
                FirstName = "Bruce",
                LastName = "Wayne",
                Email = "batman@gmail.com",
                AccountType = DataTypes.AccountType.Trainee,
                Height = 72,
                Weight = 200
            };
        }
    }
}
