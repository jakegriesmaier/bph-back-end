using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.EntityFramework.Configurations
{
    internal class CommentConfiguration : IEntityTypeConfiguration<CommentDAO>
    {
        public void Configure(EntityTypeBuilder<CommentDAO> builder)
        {
            builder.HasKey(e => e.CommentId);

            builder.Property(e => e.CommentId).ValueGeneratedOnAdd();

            builder.Property(e => e.CreatedDate).IsRequired(true);

            builder.Property(e => e.Description).IsRequired(true);
        }
    }
}
