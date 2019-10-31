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
            throw new NotImplementedException();
        }
    }
}