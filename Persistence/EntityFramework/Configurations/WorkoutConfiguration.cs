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
            throw new NotImplementedException();
        }
    }
}
