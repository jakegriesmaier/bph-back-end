using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.DataAccessObjects;
using Persistence.EntityFramework.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.EntityFramework
{
    public partial class BphContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // custom configurations
            builder.ApplyConfiguration(new CommentConfiguration());
            builder.ApplyConfiguration(new ApplicationUserConfiguration());
            builder.ApplyConfiguration(new CommentOwnerConfiguration());
            builder.ApplyConfiguration(new ExerciseConfiguration());
            builder.ApplyConfiguration(new PlanConfiguration());
            builder.ApplyConfiguration(new SetConfiguration());
            builder.ApplyConfiguration(new WorkoutConfiguration());
        }

        // custom database tables
        public DbSet<CommentDAO> Comments { get; set; }
        public DbSet<CommentOwner> CommentOwners { get; set; }
        public DbSet<ExerciseDAO> Exercises { get; set; }
        public DbSet<PlanDAO> Plans { get; set; }
        public DbSet<SetDAO> Sets { get; set; }
        public DbSet<WorkoutDAO> Workouts { get; set; }
    }
}
