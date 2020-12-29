using FactoryWebAPI.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryWebAPI.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class ForgotPasswordMap : IEntityTypeConfiguration<ForgotPassword>
    {
        public void Configure(EntityTypeBuilder<ForgotPassword> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.isActive).HasDefaultValue(true);
        }
    }
}
