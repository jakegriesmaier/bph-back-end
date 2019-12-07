using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.EntityFramework.Configurations
{
    internal class PrivateNoteConfiguration : IEntityTypeConfiguration<PrivateNoteDAO>
    {
        public void Configure(EntityTypeBuilder<PrivateNoteDAO> builder)
        {
        }
    }
}
