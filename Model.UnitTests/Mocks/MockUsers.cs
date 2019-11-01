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

        public static User NullEmail()
        {
            return new User
            {
                UserId = "good",
                FirstName = "Dog",
                LastName = "Cat",
                Email = null,
                AccountType = DataTypes.AccountType.Trainee,
                Height = 20,
                Weight = 183
            };
        }

        public static User BadUserId()
        {
            return new User
            {
                UserId = null,
                FirstName = "Dog",
                LastName = "Cat",
                Email = "peepee@peepee.com",
                AccountType = DataTypes.AccountType.Trainee,
                Height = 20,
                Weight = 183
            };
        }

        public static User BadEmail()
        {
            return new User
            {
                UserId = "good",
                FirstName = "Dog",
                LastName = "Cat",
                Email = "Test@Testmail@TestOhCrap",
                AccountType = DataTypes.AccountType.Trainee,
                Height = 20,
                Weight = 183
            };
        }
    }
}
