using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.EntityFramework.Configurations
{
    internal class ExerciseConfiguration : IEntityTypeConfiguration<ExerciseDAO>
    {
        public void Configure(EntityTypeBuilder<ExerciseDAO> builder)
        {
            builder.Property(e => e.Name).IsRequired(true);

            builder.Property(e => e.Order).IsRequired(true);

            builder.Property(e => e.Status).IsRequired(true);

            builder.HasMany(e => e.Sets).WithOne(e => e.Exercise).HasForeignKey(e => e.ExerciseId);
        }
    }
}