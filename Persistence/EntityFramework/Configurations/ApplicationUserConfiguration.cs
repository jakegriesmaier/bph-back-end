using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.EntityFramework.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(e => e.FirstName);

            builder.Property(e => e.LastName);

            builder.Property(e => e.Height);

            builder.Property(e => e.Weight);

            builder.Property(e => e.AccountType);

            builder.HasMany(e => e.Comments).WithOne(e => e.CreatedBy).HasForeignKey(e => e.CreatedById);

            // for plan access to coach
            builder.HasMany(e => e.CoachPlans).WithOne(e => e.Coach).HasForeignKey(e => e.CoachId);

            // for plan access to trainee
            builder.HasMany(e => e.TraineePlans).WithOne(e => e.Trainee).HasForeignKey(e => e.TraineeId);

            // for private note access to user
            builder.HasOne(e => e.PrivateNote).WithOne(e => e.User).HasForeignKey<PrivateNoteDAO>(e => e.UserId);
        }
    }
}
