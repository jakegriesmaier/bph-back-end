using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.EntityFramework.Configurations
{
    public class CommentOwnerConfiguration : IEntityTypeConfiguration<CommentOwner>
    {
        public void Configure(EntityTypeBuilder<CommentOwner> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.HasMany(e => e.Comments).WithOne(e => e.Owner).HasForeignKey(e => e.OwnerId);
        }
    }
}
