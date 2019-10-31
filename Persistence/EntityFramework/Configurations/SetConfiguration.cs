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
            throw new NotImplementedException();
        }
    }
}
