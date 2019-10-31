using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.EntityFramework.Configurations
{
    internal class WorkoutConfiguration : IEntityTypeConfiguration<WorkoutDAO>
    {
        public void Configure(EntityTypeBuilder<WorkoutDAO> builder)
        {
            builder.Property(e => e.Title).IsRequired(true);

            builder.Property(e => e.Status).IsRequired(true);

            builder.Property(e => e.Date).IsRequired(true);

            builder.HasMany(e => e.Exercises).WithOne(e => e.Workout).HasForeignKey(e => e.WorkoutId);


        }
    }
}
