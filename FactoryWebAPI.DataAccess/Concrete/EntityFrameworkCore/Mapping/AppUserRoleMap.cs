using FactoryWebAPI.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryWebAPI.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class AppUserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.Property(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.HasIndex(I => new { I.AppUserId, I.AppRoleId }).IsUnique();
        }
    }
}
