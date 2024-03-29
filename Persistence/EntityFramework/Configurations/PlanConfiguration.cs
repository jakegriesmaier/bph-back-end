﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.EntityFramework.Configurations
{
    internal class PlanConfiguration : IEntityTypeConfiguration<PlanDAO>
    {
        public void Configure(EntityTypeBuilder<PlanDAO> builder)
        {
            builder.HasKey(e => e.PlanId);

            builder.Property(e => e.PlanId).ValueGeneratedOnAdd();

            builder.Property(e => e.Status);

            builder.Property(e => e.Name);

            builder.HasMany(e => e.Workouts).WithOne(e => e.Plan).HasForeignKey(e => e.PlanId);
        }
    }
}
