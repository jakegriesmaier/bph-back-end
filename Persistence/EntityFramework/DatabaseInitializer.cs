using Microsoft.AspNetCore.Identity;
using Model.DataTypes;
using Persistence.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityFramework
{
    public class DatabaseInitializer
    {
        private static string _coachId;
        private static string _traineeId;

        public async static Task Initialize(BphContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            await InitializeRoles(roleManager);
            await InitializeUsers(context, userManager);
            InitializePlans(context);
        }

        private async static Task InitializeRoles(RoleManager<IdentityRole> roleManager)
        {
            foreach (var ac in Enum.GetValues(typeof(AccountType)))
            {
                var role = new IdentityRole(ac.ToString());
                await roleManager.CreateAsync(role);
            }
        }

        private async static Task InitializeUsers(BphContext context, UserManager<ApplicationUser> userManager)
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
                Email = "clemieuxfit@gmail.com",
                AccountType = Model.DataTypes.AccountType.Coach
            };
            var result = await userManager.CreateAsync(coach,coachPassword);
            await userManager.AddToRoleAsync(coach, coach.AccountType.ToString());
            _coachId = coach.Id;

            // add a trainee to the database
            string traineePassword = "TraineeBro123!";
            var trainee = new ApplicationUser
            {
                FirstName = "Small",
                LastName = "Fry",
                UserName = "smallfry@gmail.com",
                Email = "smallfry@gmail.com",
                AccountType = Model.DataTypes.AccountType.Trainee,
                Height = 250,
                Weight = 99
            };
            var result2 = await userManager.CreateAsync(trainee, traineePassword);
            await userManager.AddToRoleAsync(trainee, trainee.AccountType.ToString());
            _traineeId = trainee.Id;

        }

        private static void InitializePlans(BphContext context)
        {
            // add a plan
            var plan = new PlanDAO
            {
                CoachId = _coachId,
                TraineeId = _traineeId,
                Status = Model.DataTypes.Status.Draft
            };
            context.Plans.Add(plan);

            // add workouts to the plan
            var workouts = new List<WorkoutDAO>();
            var numWorkouts = 4;
            for(int i = 0; i < numWorkouts; i++)
            {
                // add a workout to the plan
                var workout = new WorkoutDAO
                {
                    Date = DateTime.Now,
                    Title = $"Workout {i}",
                    Status = Model.DataTypes.Status.Draft,
                    PlanId = plan.PlanId,
                };
                workouts.Add(workout);
            }
            context.Workouts.AddRange(workouts);

            // add exercises to each workout
            var exercises = new List<ExerciseDAO>();
            var numExercisesPerWorkout = 4;
            for(int i = 0; i < numExercisesPerWorkout; i++)
            {
                workouts.ForEach(wo => {
                    // add an exercise to the workout
                    var exercise = new ExerciseDAO
                    {
                        Name = $"exercise {i} in workout named {wo.Title}",
                        Order = i,
                        WorkoutId = wo.Id,
                        Status = Model.DataTypes.Status.Draft,
                    };
                    exercises.Add(exercise);
                });
            }
            context.Exercises.AddRange(exercises);

            // add sets to each exercise
            var sets = new List<SetDAO>();
            var numSetsPerExercise = 4;
            for(int i = 0; i < numSetsPerExercise; i++)
            {
                exercises.ForEach(ex => {
                    // add a set to the exercise
                    var set = new SetDAO
                    {
                        ExerciseId = ex.Id,
                        Order = i,
                        TargetReps = i + 5,
                        TargetRPE = 8,
                    };
                    sets.Add(set);
                });
            }
            context.Sets.AddRange(sets);

            // add commments
            var comments = new List<CommentDAO>();
            // add comments to workouts
            workouts.ForEach(wo => {
                var comment = new CommentDAO
                {
                    CreatedById = _traineeId,
                    OwnerId = wo.Id,
                    Description = $"I am a comment on {wo.Title}"
                };
                comments.Add(comment);
            });
            // add comments to exercises
            exercises.ForEach(ex => {
                var comment = new CommentDAO
                {
                    CreatedById = _traineeId,
                    OwnerId = ex.Id,
                    Description = $"I am a comment on {ex.Name}"
                };
                comments.Add(comment);
            });
            // add comments to sets
            sets.ForEach(s => {
                var comment = new CommentDAO
                {
                    CreatedById = _coachId,
                    OwnerId = s.Id,
                    Description = $"I am a comment on {s.Id}"
                };
                comments.Add(comment);
            });
            context.Comments.AddRange(comments);
            // save the changes to the databases
            context.SaveChanges();
        }
    }
}