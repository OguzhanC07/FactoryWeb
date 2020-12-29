using FactoryWebAPI.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryWebAPI.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.UserName).HasMaxLength(100).IsRequired();
            builder.HasIndex(I => I.UserName).IsUnique();
            
            builder.Property(I => I.Password).HasMaxLength(100).IsRequired();
            
            builder.Property(I => I.Email).HasMaxLength(100).IsRequired();
            builder.HasIndex(I => I.Email).IsUnique();
            
            builder.Property(I => I.FullName).HasMaxLength(100);
            builder.Property(I => I.ImagePath);

            //builder.HasOne(I => I.Dealer).WithOne(I => I.AppUser).HasForeignKey<Dealer>(I => I.AppUserId);

            builder.HasMany(I => I.Dealers).WithOne(I => I.AppUser).HasForeignKey(I => I.AppUserId).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(I => I.AppUserRoles).WithOne(I => I.AppUser).HasForeignKey(I=>I.AppUserId).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(I => I.AppUserForgotPasswords).WithOne(I => I.AppUser).HasForeignKey(I => I.AppUserId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
