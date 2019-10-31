using Microsoft.EntityFrameworkCore;
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
            throw new NotImplementedException();
        }
    }
}
