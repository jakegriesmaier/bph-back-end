using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.EntityFramework.Configurations
{
    internal class SetConfiguration : IEntityTypeConfiguration<SetDAO>
    {
        public void Configure(EntityTypeBuilder<SetDAO> builder)
        {
            builder.Property(e => e.Order).IsRequired(true);

            builder.Property(e => e.TargetReps);

            builder.Property(e => e.ActualReps);

            builder.Property(e => e.TargetRPE);

            builder.Property(e => e.ActualRPE);
        }
    }
}
