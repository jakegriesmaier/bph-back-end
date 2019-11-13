using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityFramework
{
    public class DatabaseInitializer
    {
        public async static Task Initialize(BphContext context, UserManager<ApplicationUser> userManager)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            await InitializeUsers(context,userManager);
        }

        public async static Task InitializeUsers(BphContext context, UserManager<ApplicationUser> userManager)
        {
            if (context.Users.Any())
            {
                return;// Database has already been seeded
            }

            // add coach to the database
            string coachPassword = "ClientBro123!";
            var coach = new ApplicationUser
            {
                FirstName = "Craig",
                LastName = "LeMieux",
                UserName = "clemieuxfit@gmail.com",
                AccountType = Model.DataTypes.AccountType.Coach
            };
            var result = await userManager.CreateAsync(coach,coachPassword);

            // add a trainee to the database
            string traineePassword = "TraineeBro123!";
            var trainee = new ApplicationUser
            {
                FirstName = "Small",
                LastName = "Fry",
                UserName = "smallfry@gmail.com",
                AccountType = Model.DataTypes.AccountType.Trainee,
                Height = 250,
                Weight = 99
            };
            var result2 = await userManager.CreateAsync(trainee, traineePassword);
        }

    }
}